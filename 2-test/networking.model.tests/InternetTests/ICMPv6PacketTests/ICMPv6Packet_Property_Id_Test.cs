using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.ICMPv6PacketTests
{
    public class ICMPv6Packet_Property_Id_Test
    {
        [Fact]
        public void Get()
        {
            var icmpv6Packet = new ICMPv6Packet
            {
                Bytes = new Byte[32]
            };

            icmpv6Packet.SetBytes(4, 2, new Byte[] { 0x00, 0x01 });

            icmpv6Packet.Id.Should().Be(1);
        }

        [Fact]
        public void Set()
        {
            var icmpv6Packet = new ICMPv6Packet
            {
                Bytes = new Byte[32]
            };

            icmpv6Packet.Id = 1;

            icmpv6Packet.Id.Should().Be(1);
        }
    }
}
