using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.ARPFrameTests
{
    public class ARPFrame_Property_TargetMACAddress_Test
    {

        [Fact]
        public void Get()
        {
            var arpFrame = new ARPFrame
            {
                Bytes = new Byte[28]
            };

            arpFrame.SetBytes(18, 6, new Byte[] { 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC });

            arpFrame.TargetMACAddress.ToString().Should().Be("12:34:56:78:9A:BC");
        }

        [Fact]
        public void Set()
        {
            var arpFrame = new ARPFrame
            {
                Bytes = new Byte[28]
            };

            arpFrame.TargetMACAddress = new MACAddress
            {
                Bytes = new Byte[] { 0x21, 0x43, 0x65, 0x87, 0xA9, 0xCB }
            };

            arpFrame.TargetMACAddress.ToString().Should().Be("21:43:65:87:A9:CB");
        }
    }
}
