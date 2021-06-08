using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.ICMPv6PacketTests
{
    public class ICMPv6Packet_Property_Checksum_Test
    {
        [Fact]
        public void Get()
        {
            var icmpv6Packet = new ICMPv6Packet
            {
                Bytes = new Byte[32]
            };

            icmpv6Packet.SetBytes(2, 2, new Byte[] { 0x4d, 0x4a });

            icmpv6Packet.Checksum.Should().Be(19786);
        }

        [Fact]
        public void Set()
        {
            var icmpv6Packet = new ICMPv6Packet
            {
                Bytes = new Byte[32]
            };

            icmpv6Packet.Checksum = 19786;

            icmpv6Packet.Checksum.Should().Be(19786);
        }
    }
}
