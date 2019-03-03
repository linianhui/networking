using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;
using Xunit.Abstractions;

namespace Networking.Model.Tests.DataLinkTests.VLANFrameTests
{
    public class VLANFrame_Test
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public VLANFrame_Test(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ipv4()
        {
            var vlanFrame = new VLANFrame
            {
                Bytes = new Byte[]
                {
                    0b_101_1_1010, 0b_1100_0011,
                    0x08, 0x00
                }
            };


            vlanFrame.PCP.Should().Be(0b_101);
            vlanFrame.DEI.Should().Be(true);
            vlanFrame.VID.Should().Be(0b_1010_1100_0011);
            vlanFrame.Type.Should().Be(EthernetFrameType.IPv4);
        }

        [Fact]
        public void vlan()
        {
            this.PcapFileForEach("vlan.pcap", bytes =>
            {
                var ethernetFrame = new EthernetFrame { Bytes = bytes };

                _testOutputHelper.WriteLine(
                    $"\r\n{ethernetFrame.SourceMACAddress} > {ethernetFrame.DestinationMACAddress} {ethernetFrame.Type}"
                );

                if (ethernetFrame.Type == EthernetFrameType.VLAN)
                {
                    var vlan = (VLANFrame)ethernetFrame.Payload;
                    vlan.GetType().Should().Be<VLANFrame>();
                    _testOutputHelper.WriteLine($"\r\n{vlan.VID} {vlan.Type}");
                }
            });
        }
    }
}
