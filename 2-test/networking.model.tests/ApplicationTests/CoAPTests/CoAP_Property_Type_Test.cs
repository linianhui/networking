using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.CoAPTests
{
    public class CoAP_Property_Type_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { 0b_00_00_0000, CoAPType.Confirmable },
            new Object[] { 0b_00_01_0000, CoAPType.NonConfirmable },
            new Object[] { 0b_00_10_0000, CoAPType.Acknowledgement },
            new Object[] { 0b_00_11_0000, CoAPType.Reset }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte input, CoAPType expected)
        {
            var coap = new CoAP
            {
                Bytes = new Byte[32]
            };

            coap.SetByte(0, input);

            coap.Type.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte expected, CoAPType input)
        {
            var coap = new CoAP
            {
                Bytes = new Byte[32]
            };

            coap.Type = input;
            coap.GetByte(0).Should().Be(expected);
            coap.Type.Should().Be(input);
        }
    }
}
