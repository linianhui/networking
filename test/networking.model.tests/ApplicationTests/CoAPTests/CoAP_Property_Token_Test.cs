using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.CoAPTests
{
    public class CoAP_Property_Token_Test
    {
        [Fact]
        public void Get()
        {
            var coap = new CoAP
            {
                Bytes = new Byte[]
                {
                    0b_00_00_0100, 0x00, 0x12, 0x34,
                    0x12, 0x34, 0x56, 0x78
                }
            };


            coap.TokenLength.Should().Be(4);
            coap.Token.ToString().Should().Be("12-34-56-78");
        }
    }
}
