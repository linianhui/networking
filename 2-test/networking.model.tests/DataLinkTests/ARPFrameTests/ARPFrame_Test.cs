using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.ARPFrameTests
{
    public class ARPFrame_Test
    {
        [Fact]
        public void arp_request_frame()
        {
            var arpFrame = new ARPFrame
            {
                Bytes = buildARPBytes()
            };


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

        private Byte[] buildARPBytes()
        {
            return new Byte[]
            {
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
