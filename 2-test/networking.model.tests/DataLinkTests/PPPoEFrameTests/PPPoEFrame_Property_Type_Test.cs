using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.InternetTests.PPPoEFrameTests
{
    public class PPPoEFrame_Property_Type_Test
    {
        [Fact]
        public void Get()
        {
            var pppoeFrame = new PPPoEFrame
            {
                Bytes = new Byte[32]
            };
            pppoeFrame.SetByte(0, 0x21);

            pppoeFrame.Version.Should().Be(2);
            pppoeFrame.Type.Should().Be(1);
        }

        [Theory]
        [InlineData(0x01)]
        [InlineData(0x11)]
        [InlineData(0x21)]
        [InlineData(0x31)]
        [InlineData(0x41)]
        [InlineData(0x51)]
        [InlineData(0x61)]
        [InlineData(0x71)]
        [InlineData(0x81)]
        [InlineData(0x91)]
        [InlineData(0xA1)]
        [InlineData(0xB1)]
        [InlineData(0xC1)]
        [InlineData(0xD1)]
        [InlineData(0xE1)]
        [InlineData(0xF1)]
        public void Set(Byte input)
        {
            var pppoeFrame = new PPPoEFrame
            {
                Bytes = new Byte[32]
            };
            pppoeFrame.SetByte(0, 0x20);

            pppoeFrame.Type = input;

            pppoeFrame.GetByte(0).Should().Be(0x21);
            pppoeFrame.Version.Should().Be(2);
            pppoeFrame.Type.Should().Be(1);
        }
    }
}
