using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.CoAPTests
{
    public class CoAP_Property_TokenLength_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { 0b_0000_0000, 00 },
            new Object[] { 0b_0000_0001, 01 },
            new Object[] { 0b_0000_0010, 02 },
            new Object[] { 0b_0000_0011, 03 },
            new Object[] { 0b_0000_0100, 04 },
            new Object[] { 0b_0000_0101, 05 },
            new Object[] { 0b_0000_0110, 06 },
            new Object[] { 0b_0000_0111, 07 },
            new Object[] { 0b_0000_1000, 08 },
            new Object[] { 0b_0000_1001, 09 },
            new Object[] { 0b_0000_1010, 10 },
            new Object[] { 0b_0000_1011, 11 },
            new Object[] { 0b_0000_1100, 12 },
            new Object[] { 0b_0000_1101, 13 },
            new Object[] { 0b_0000_1110, 14 },
            new Object[] { 0b_0000_1111, 15 },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte input, Byte expected)
        {
            var coap = new CoAP
            {
                Bytes = new Byte[32]
            };

            coap.SetByte(0, input);

            coap.TokenLength.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte expected, Byte input)
        {
            var coap = new CoAP
            {
                Bytes = new Byte[32]
            };

            coap.TokenLength = input;
            coap.GetByte(0).Should().Be(expected);
            coap.TokenLength.Should().Be(input);
        }
    }
}
