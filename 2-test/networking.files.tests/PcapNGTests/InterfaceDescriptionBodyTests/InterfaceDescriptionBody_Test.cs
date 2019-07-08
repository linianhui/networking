using System;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.InterfaceDescriptionBodyTests
{
    public class InterfaceDescriptionBody_Test
    {
        [Fact]
        public void Get()
        {
            var interfaceDescriptionBody = new InterfaceDescriptionBody
            {
                Bytes = new Byte[] {
                    0x00,0x01,0x00,0x00,
                    0x12,0x34,0x56,0x78
                }
            };

            interfaceDescriptionBody.Should().NotBeAssignableTo<IPacket>();
            interfaceDescriptionBody.IsPacket.Should().Be(false);
            interfaceDescriptionBody.Type.Should().Be(DataLinkType.Ethernet);
            interfaceDescriptionBody.MaxCapturedLength.Should().Be(0x12345678);
        }
    }
}
