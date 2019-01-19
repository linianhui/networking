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

    }
}
