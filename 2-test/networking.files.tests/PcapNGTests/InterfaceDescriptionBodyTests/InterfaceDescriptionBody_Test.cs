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
                    0x00,0x01
                }
            };

            interfaceDescriptionBody.Type.Should().Be(DataLinkType.Ethernet);
        }
    }
}
