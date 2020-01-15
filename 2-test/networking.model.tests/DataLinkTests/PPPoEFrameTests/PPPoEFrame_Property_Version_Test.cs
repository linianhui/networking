using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.InternetTests.PPPoEFrameTests
{
    public class PPPoEFrame_Property_Version_Test
    {
        [Fact]
        public void Get()
        {
            var pppoeFrame = new PPPoEFrame
            {
                Bytes = new Byte[32]
            };
            pppoeFrame.SetByte(0, 0x12);

            pppoeFrame.Version.Should().Be(1);
            pppoeFrame.Type.Should().Be(2);
        }

        [Theory]
        [InlineData(0x02)]
        [InlineData(0x12)]
        [InlineData(0x22)]
        [InlineData(0x32)]
        [InlineData(0x42)]
        [InlineData(0x52)]
        [InlineData(0x62)]
        [InlineData(0x72)]
        [InlineData(0x82)]
        [InlineData(0x92)]
        [InlineData(0xA2)]
        [InlineData(0xB2)]
        [InlineData(0xC2)]
        [InlineData(0xD2)]
        [InlineData(0xE2)]
        [InlineData(0xF2)]
        public void Set(Byte input)
        {
            var pppoeFrame = new PPPoEFrame
            {
                Bytes = new Byte[32]
            };
            pppoeFrame.SetByte(0, 0x01);

            pppoeFrame.Version = input;

            pppoeFrame.GetByte(0).Should().Be(0x21);
            pppoeFrame.Version.Should().Be(2);
            pppoeFrame.Type.Should().Be(1);
        }
    }
}
