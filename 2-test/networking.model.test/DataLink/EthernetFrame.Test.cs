using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.DataLink
{
    public class EthernetFrameTest
    {
        [Fact]
        public void DestinationMACAddress_Get()
        {
            var ethernetFrame = new EthernetFrame
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC }
            };

            ethernetFrame.ToString().Should().Be("12-34-56-78-9A-BC");
            ethernetFrame.DestinationMACAddress.ToString().Should().Be("12:34:56:78:9A:BC");
        }

        [Fact]
        public void DestinationMACAddress_Set()
        {
            var ethernetFrame = new EthernetFrame
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC }
            };

            ethernetFrame.DestinationMACAddress = new MACAddress
            {
                Bytes = new Byte[] { 0x21, 0x43, 0x65, 0x87, 0xA9, 0xCB }
            };

            ethernetFrame.ToString().Should().Be("21-43-65-87-A9-CB");
            ethernetFrame.DestinationMACAddress.ToString().Should().Be("21:43:65:87:A9:CB");
        }

        [Fact]
        public void SourceMACAddress_Get()
        {
            var ethernetFrame = new EthernetFrame
            {
                Bytes = new Byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC }
            };

            ethernetFrame.ToString().Should().Be("FF-FF-FF-FF-FF-FF-12-34-56-78-9A-BC");
            ethernetFrame.SourceMACAddress.ToString().Should().Be("12:34:56:78:9A:BC");
        }

        [Fact]
        public void SourceMACAddress_Set()
        {
            var ethernetFrame = new EthernetFrame
            {
                Bytes = new Byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC }
            };

            ethernetFrame.SourceMACAddress = new MACAddress
            {
                Bytes = new Byte[] { 0x21, 0x43, 0x65, 0x87, 0xA9, 0xCB }
            };

            ethernetFrame.ToString().Should().Be("FF-FF-FF-FF-FF-FF-21-43-65-87-A9-CB");
            ethernetFrame.DestinationMACAddress.ToString().Should().Be("FF:FF:FF:FF:FF:FF");
            ethernetFrame.SourceMACAddress.ToString().Should().Be("21:43:65:87:A9:CB");
        }

        [Fact]
        public void Payload_Get_ARP()
        {
            var ethernetFrame = new EthernetFrame
            {
                Bytes = buildARPBytes()
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

        private Byte[] buildARPBytes()
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
