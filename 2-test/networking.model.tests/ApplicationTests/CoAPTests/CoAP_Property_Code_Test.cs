using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.CoAPTests
{
    public class CoAP_Property_Code_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { 0b_000_00001, 0, 01, CoAPCode.GET },
            new Object[] { 0b_000_00010, 0, 02, CoAPCode.POST },
            new Object[] { 0b_000_00011, 0, 03, CoAPCode.PUT },
            new Object[] { 0b_000_00100, 0, 04, CoAPCode.DELETE },

            new Object[] { 0b_010_00001, 2, 01, CoAPCode.Created },
            new Object[] { 0b_010_00010, 2, 02, CoAPCode.Deleted },
            new Object[] { 0b_010_00011, 2, 03, CoAPCode.Valid },
            new Object[] { 0b_010_00100, 2, 04, CoAPCode.Changed },
            new Object[] { 0b_010_00101, 2, 05, CoAPCode.Content },

            new Object[] { 0b_100_00000, 4, 00, CoAPCode.BadRequest },
            new Object[] { 0b_100_00001, 4, 01, CoAPCode.Unauthorized },
            new Object[] { 0b_100_00010, 4, 02, CoAPCode.BadOption },
            new Object[] { 0b_100_00011, 4, 03, CoAPCode.Forbidden },
            new Object[] { 0b_100_00100, 4, 04, CoAPCode.NotFound },
            new Object[] { 0b_100_00101, 4, 05, CoAPCode.MethodNotAllowed },
            new Object[] { 0b_100_00110, 4, 06, CoAPCode.NotAcceptable },
            new Object[] { 0b_100_01100, 4, 12, CoAPCode.PreconditionFailed },
            new Object[] { 0b_100_01101, 4, 13, CoAPCode.RequestEntityTooLarge },
            new Object[] { 0b_100_01111, 4, 15, CoAPCode.UnsupportedContentFormat },

            new Object[] { 0b_101_00000, 5, 00, CoAPCode.InternalServerError },
            new Object[] { 0b_101_00001, 5, 01, CoAPCode.NotImplemented },
            new Object[] { 0b_101_00010, 5, 02, CoAPCode.BadGateway },
            new Object[] { 0b_101_00011, 5, 03, CoAPCode.ServiceUnavailable },
            new Object[] { 0b_101_00100, 5, 04, CoAPCode.GatewayTimeout },
            new Object[] { 0b_101_00101, 5, 05, CoAPCode.ProxyNotSupported },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte input, Byte c, Byte dd, CoAPCode expected)
        {
            var coap = new CoAP
            {
                Bytes = new Byte[32]
            };

            coap.SetByte(1, input);

            coap.Code.Should().Be(expected);
            coap.CodeC.Should().Be(c);
            coap.CodeDD.Should().Be(dd);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte expected, Byte c, Byte dd, CoAPCode input)
        {
            var coap = new CoAP
            {
                Bytes = new Byte[32]
            };

            coap.Code = input;

            coap.GetByte(1).Should().Be(expected);
            coap.Code.Should().Be(input);
            coap.CodeC.Should().Be(c);
            coap.CodeDD.Should().Be(dd);
        }
    }
}
