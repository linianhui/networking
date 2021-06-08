using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.ICMPv6PacketTests
{
    public class ICMPv6Packet_Property_Sequence_Test
    {
        [Fact]
        public void Get()
        {
            var icmpv6Packet = new ICMPv6Packet
            {
                Bytes = new Byte[32]
            };

            icmpv6Packet.SetBytes(6, 2, new Byte[] { 0x00, 0x11 });

            icmpv6Packet.Sequence.Should().Be(17);
        }

        [Fact]
        public void Set()
        {
            var icmpv6Packet = new ICMPv6Packet
            {
                Bytes = new Byte[32]
            };

            icmpv6Packet.Sequence = 17;

            icmpv6Packet.Sequence.Should().Be(17);
        }
    }
}
