using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.EthernetFrameTests
{
    public class EthernetFrame_Test
    {
        [Fact]
        public void ipv4()
        {
            var ethernetFrame = new EthernetFrame
            {
                Bytes = new Byte[]
                {
                    0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC,
                    0x21, 0x43, 0x65, 0x87, 0xA9, 0xCB,
                    0x08, 0x00
                }
            };


            ethernetFrame.DestinationMACAddress.ToString().Should().Be("12:34:56:78:9A:BC");
            ethernetFrame.SourceMACAddress.ToString().Should().Be("21:43:65:87:A9:CB");
            ethernetFrame.Type.Should().Be(EthernetFrameType.IPv4);
        }
    }
}
