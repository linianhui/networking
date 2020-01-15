using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;
using Xunit.Abstractions;

namespace Networking.Model.Tests.DataLinkTests.VLANFrameTests
{
    public class VLANFrame_Test : BaseTest
    {
        public VLANFrame_Test(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
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
            this.GetPcapPacketReader("vlan.pcap").ForEach(bytes =>
            {
                var ethernetFrame = new EthernetFrame { Bytes = bytes };
                TestOutput.Display(ethernetFrame);
            });
        }
    }
}
