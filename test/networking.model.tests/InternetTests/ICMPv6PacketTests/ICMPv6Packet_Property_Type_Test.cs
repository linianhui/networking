using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.ICMPv6PacketTests
{
    public class ICMPv6Packet_Property_Type_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { 1, ICMPv6Type.DestinationUnreachable },
            new Object[] { 3, ICMPv6Type.TimeExceeded },
            new Object[] { 128, ICMPv6Type.EchoRequest },
            new Object[] { 129, ICMPv6Type.EchoResponse },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte input, ICMPv6Type expected)
        {
            var icmpv6Packet = new ICMPv6Packet
            {
                Bytes = new Byte[32]
            };

            icmpv6Packet.SetByte(0, input);

            icmpv6Packet.Type.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte expected, ICMPv6Type input)
        {
            var icmpv6Packet = new ICMPv6Packet
            {
                Bytes = new Byte[32]
            };

            icmpv6Packet.Type = input;

            icmpv6Packet.GetByte(0).Should().Be(expected);
            icmpv6Packet.Type.Should().Be(input);
        }
    }
}
