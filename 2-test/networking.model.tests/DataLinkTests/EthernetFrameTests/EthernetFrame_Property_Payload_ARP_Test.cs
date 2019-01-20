using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.EthernetFrameTests
{
    public class EthernetFrame_Property_Payload_ARP_Test
    {
        [Fact]
        public void Get()
        {
            var ethernetFrame = new EthernetFrame
            {
                Bytes = buildARPFrameBytes()
            };

            var arpFrame = ethernetFrame.Payload as ARPFrame;


            arpFrame.HardwareType.Should().Be(HardwareType.Ethernet);
            arpFrame.ProtocolType.Should().Be(EthernetFrameType.IPv4);
            arpFrame.HardwareAddressLength.Should().Be(6);
            arpFrame.ProtocolAddressLength.Should().Be(4);
            arpFrame.OperationCode.Should().Be(ARPOperationCode.Request);
            arpFrame.SenderMACAddress.ToString().Should().Be("12:34:56:78:9A:BC");
            arpFrame.SenderIPAddress.ToString().Should().Be("192.168.1.2");
            arpFrame.TargetMACAddress.ToString().Should().Be("00:00:00:00:00:00");
            arpFrame.TargetIPAddress.ToString().Should().Be("192.168.1.1");
        }

        private Byte[] buildARPFrameBytes()
        {
            return new Byte[]
            {
                0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
                0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC,
                0x08, 0x06,
                0x00, 0x01,
                0x08, 0x00,
                0x06,
                0x04,
                0x00, 0x01,
                0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC,
                0xC0, 0xA8, 0x01, 0x02,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0xC0, 0xA8, 0x01, 0x01,
            };
        }
    }
}