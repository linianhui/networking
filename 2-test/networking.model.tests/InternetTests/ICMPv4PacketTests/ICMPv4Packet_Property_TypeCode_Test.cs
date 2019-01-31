using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.ICMPv4PacketTests
{
    public class ICMPv4Packet_Property_TypeCode_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { new Byte[]{ 0x08, 0x00 }, ICMPv4TypeCode.EchoRequest },
            new Object[] { new Byte[]{ 0x00, 0x00 }, ICMPv4TypeCode.EchoResponse }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte[] input, ICMPv4TypeCode expected)
        {
            var icmpv4Packet = new ICMPv4Packet
            {
                Bytes = new Byte[32]
            };

            icmpv4Packet[0, 2] = input;

            icmpv4Packet.TypeCode.Should().Be(expected);
        }

        [Theory]
        [InlineData(ICMPv4TypeCode.EchoRequest)]
        [InlineData(ICMPv4TypeCode.EchoResponse)]
        public void Set(ICMPv4TypeCode input)
        {
            var icmpv4Packet = new ICMPv4Packet
            {
                Bytes = new Byte[32]
            };

            icmpv4Packet.TypeCode = input;

            icmpv4Packet.TypeCode.Should().Be(input);
        }
    }
}
