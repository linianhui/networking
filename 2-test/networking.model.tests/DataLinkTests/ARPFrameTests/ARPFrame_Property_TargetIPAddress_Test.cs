using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.ARPFrameTests
{
    public class ARPFrame_Property_TargetIPAddress_Test
    {

        [Fact]
        public void Get()
        {
            var arpFrame = new ARPFrame
            {
                Bytes = new Byte[28]
            };

            arpFrame.SetBytes(24, 4, new Byte[] { 0xC0, 0xA8, 0x01, 0x01 });

            arpFrame.TargetIPAddress.ToString().Should().Be("192.168.1.1");
        }

        [Fact]
        public void Set()
        {
            var arpFrame = new ARPFrame
            {
                Bytes = new Byte[28]
            };

            arpFrame.TargetIPAddress = new IPAddress
            {
                Bytes = new Byte[] { 0xC0, 0xA8, 0x01, 0x01 }
            };

            arpFrame.TargetIPAddress.ToString().Should().Be("192.168.1.1");
        }
    }
}
