using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.CoAPTests
{
    public class CoAP_Property_Version_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { 0b_00_000000, 0 },
            new Object[] { 0b_01_000000, 1 },
            new Object[] { 0b_10_000000, 2 },
            new Object[] { 0b_11_000000, 3 }
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

            coap.Version.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte expected, Byte input)
        {
            var coap = new CoAP
            {
                Bytes = new Byte[32]
            };

            coap.Version = input;
            coap.GetByte(0).Should().Be(expected);
            coap.Version.Should().Be(input);
        }
    }
}
