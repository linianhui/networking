using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;
using System;

namespace Networking.Model.Test.DataLink
{
    public class EthernetFrameTest
    {
        [Fact]
        public void target_mac_address_get()
        {
            var ethernetFrame = new EthernetFrame
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC }
            };

            ethernetFrame.ToString().Should().Be("12-34-56-78-9A-BC");
            ethernetFrame.TargetMACAddress.ToString().Should().Be("12-34-56-78-9A-BC");
        }

        [Fact]
        public void target_mac_address_set()
        {
            var ethernetFrame = new EthernetFrame
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC }
            };

            ethernetFrame.TargetMACAddress = new MACAddress
            {
                Bytes = new Byte[] { 0x21, 0x43, 0x65, 0x87, 0xA9, 0xCB }
            };

            ethernetFrame.ToString().Should().Be("21-43-65-87-A9-CB");
            ethernetFrame.TargetMACAddress.ToString().Should().Be("21-43-65-87-A9-CB");
        }

        [Fact]
        public void source_mac_address_get()
        {
            var ethernetFrame = new EthernetFrame
            {
                Bytes = new Byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC }
            };

            ethernetFrame.ToString().Should().Be("FF-FF-FF-FF-FF-FF-12-34-56-78-9A-BC");
            ethernetFrame.SourceMACAddress.ToString().Should().Be("12-34-56-78-9A-BC");
        }

        [Fact]
        public void source_mac_address_set()
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
            ethernetFrame.TargetMACAddress.ToString().Should().Be("FF-FF-FF-FF-FF-FF");
            ethernetFrame.SourceMACAddress.ToString().Should().Be("21-43-65-87-A9-CB");
        }

    }
}
