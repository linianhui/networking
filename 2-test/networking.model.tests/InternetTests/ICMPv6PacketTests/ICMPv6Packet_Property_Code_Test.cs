using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.ICMPv6PacketTests
{
    public class ICMPv6Packet_Property_Code_Test
    {
        [Fact]
        public void Get()
        {
            var icmpv6Packet = new ICMPv6Packet
            {
                Bytes = new Byte[32]
            };

            icmpv6Packet.SetByte(1, 1);

            icmpv6Packet.Code.Should().Be(1);
        }

        [Fact]
        public void Set()
        {
            var icmpv6Packet = new ICMPv6Packet
            {
                Bytes = new Byte[32]
            };

            icmpv6Packet.Code = 1;

            icmpv6Packet.GetByte(1).Should().Be(1);
            icmpv6Packet.Code.Should().Be(1);
        }
    }
}
