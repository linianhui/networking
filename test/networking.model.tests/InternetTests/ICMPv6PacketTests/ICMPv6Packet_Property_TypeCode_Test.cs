using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.ICMPv6PacketTests
{
    public class ICMPv6Packet_Property_TypeCode_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { new Byte[]{ 0x01, 0x00 }, ICMPv6TypeCode.DestinationUnreachableOfNoRoute },
            new Object[] { new Byte[]{ 0x03, 0x00 }, ICMPv6TypeCode.TimeExceededOfHopLimitExceededInTransit },
            new Object[] { new Byte[]{ 0x03, 0x01 }, ICMPv6TypeCode.TimeExceededOfFragmentReassembly },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte[] input, ICMPv6TypeCode expected)
        {
            var icmpv6Packet = new ICMPv6Packet
            {
                Bytes = new Byte[32]
            };

            icmpv6Packet.SetBytes(0, 2, input);

            ((Byte)(icmpv6Packet.Type)).Should().Be(input[0]);
            icmpv6Packet.Code.Should().Be(input[1]);
            icmpv6Packet.TypeCode.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte[] expected, ICMPv6TypeCode input)
        {
            var icmpv6Packet = new ICMPv6Packet
            {
                Bytes = new Byte[32]
            };

            icmpv6Packet.TypeCode = input;
            icmpv6Packet.GetBytes(0, 2).ToArray().Should().Equal(expected);
            ((Byte)(icmpv6Packet.Type)).Should().Be(expected[0]);
            icmpv6Packet.Code.Should().Be(expected[1]);
            icmpv6Packet.TypeCode.Should().Be(input);
        }
    }
}
