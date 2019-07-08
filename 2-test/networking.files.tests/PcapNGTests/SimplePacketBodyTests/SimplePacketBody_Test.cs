using System;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.SimplePacketBodyTests
{
    public class SimplePacketBody_Test
    {
        [Fact]
        public void Get()
        {
            var simplePacketBody = new SimplePacketBody
            {
                Bytes = new Byte[] {
                    0x00,0x00,0x00,0x80,
                    0x12,0x34,0x56,0x78
                }
            };

            simplePacketBody.Should().BeAssignableTo<IPacket>();
            simplePacketBody.IsPacket.Should().Be(true);
            simplePacketBody.OriginalLength.Should().Be(0x80);
            simplePacketBody.Payload.ToArray().Should().Equal(0x12, 0x34, 0x56, 0x78);
        }
    }
}
