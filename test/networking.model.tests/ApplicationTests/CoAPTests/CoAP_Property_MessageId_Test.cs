using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.CoAPTests
{
    public class CoAP_Property_MessageId_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { 0x12,0x34, 0x1234 },
            new Object[] { 0xAB,0xCD, 0xABCD }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte input1, Byte input2, UInt16 expected)
        {
            var coap = new CoAP
            {
                Bytes = new Byte[32]
            };

            coap.SetByte(2, input1);
            coap.SetByte(3, input2);

            coap.MessageId.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte expected1, Byte expected2, UInt16 input)
        {
            var coap = new CoAP
            {
                Bytes = new Byte[32]
            };

            coap.MessageId = input;

            coap.GetByte(2).Should().Be(expected1);
            coap.GetByte(3).Should().Be(expected2);
            coap.MessageId.Should().Be(input);
        }
    }
}
