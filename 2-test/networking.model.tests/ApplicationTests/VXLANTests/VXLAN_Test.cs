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
    public class VXLAN_Test
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public VXLAN_Test(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
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
            this.GetPcapFileReader("vxlan.pcap").ForEach(bytes =>
            {
                var ethernetFrame = new EthernetFrame { Bytes = bytes };

                var ipv4 = (IPv4Packet)ethernetFrame.Payload;
                var udp = (UDPDatagram)ipv4.Payload;
                var udpPayload = udp.Payload;
                var vxlan = (VXLAN)udp.Payload;

                _testOutputHelper.WriteLine(
                    $"\r\n{ethernetFrame.SourceMACAddress} > {ethernetFrame.DestinationMACAddress} {ethernetFrame.Type}" +
                    $"\r\n{ipv4.SourceIPAddress} > {ipv4.DestinationIPAddress} {ipv4.Type}" +
                    $"\r\n{udp.SourcePort} > {udp.DestinationPort}" +
                    $"\r\n{vxlan.I}  {vxlan.VNI}"
                );

                udpPayload.GetType().Should().Be(typeof(VXLAN));
            });
        }
    }
}
