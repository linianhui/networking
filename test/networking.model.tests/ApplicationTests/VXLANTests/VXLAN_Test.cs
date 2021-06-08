using System;
using FluentAssertions;
using Networking.Model.Application;
using Networking.Model.DataLink;
using Networking.Model.Internet;
using Networking.Model.Transport;
using Xunit;
using Xunit.Abstractions;

namespace Networking.Model.Tests.ApplicationTests.VXLANTests
{
    public class VXLAN_Test : BaseTest
    {
        public VXLAN_Test(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        [Fact]
        public void EthernetFrame()
        {
            var vxlan = new VXLAN
            {
                Bytes = new Byte[]
                {
                    0b_0000_1000, 0, 0, 0,
                    0b_1001_0110, 0b_1010_0101, 0b_0100_1111, 0, 0
                }
            };

            vxlan.I.Should().Be(true);
            vxlan.VNI.Should().Be(0b_1001_0110_1010_0101_0100_1111);
            vxlan.Payload.GetType().Should().Be(typeof(EthernetFrame));
        }

        [Fact]
        public void vxlan()
        {
            this.GetPcapPacketReader("vxlan.pcap").ForEach(bytes =>
            {
                var ethernetFrame = new EthernetFrame { Bytes = bytes };

                var ipv4 = (IPv4Packet)ethernetFrame.Payload;
                var udp = (UDPDatagram)ipv4.Payload;
                var udpPayload = udp.Payload;
                udpPayload.GetType().Should().Be(typeof(VXLAN));

                TestOutput.NewLine();
                TestOutput.Display(ethernetFrame);
            });
        }
    }
}
