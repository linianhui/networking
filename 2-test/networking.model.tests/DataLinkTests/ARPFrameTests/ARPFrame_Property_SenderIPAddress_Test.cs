using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.ARPFrameTests
{
    public class ARPFrame_Property_SenderIPAddress_Test
    {

        [Fact]
        public void Get()
        {
            var arpFrame = new ARPFrame(new Byte[28]);
            arpFrame[14, 4] = new Byte[] { 0xC0, 0xA8, 0x01, 0x02 };


            arpFrame.SenderIPAddress.ToString().Should().Be("192.168.1.2");
        }

        [Fact]
        public void Set()
        {
            var arpFrame = new ARPFrame(new Byte[28]);

            arpFrame.SenderIPAddress = new IPAddress
            (
                new Byte[] { 0xC0, 0xA8, 0x01, 0x02 }
            );

            arpFrame.SenderIPAddress.ToString().Should().Be("192.168.1.2");
        }
    }
}
