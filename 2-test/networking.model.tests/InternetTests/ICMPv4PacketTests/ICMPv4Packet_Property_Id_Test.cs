using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.ICMPv4PacketTests
{
    public class ICMPv4Packet_Property_Id_Test
    {
        [Fact]
        public void Get()
        {
            var icmpv4Packet = new ICMPv4Packet
            {
                Bytes = new Byte[32]
            };

            icmpv4Packet.SetBytes(4, 2, new Byte[] { 0x00, 0x01 });

            icmpv4Packet.Id.Should().Be(1);
        }

        [Fact]
        public void Set()
        {
            var icmpv4Packet = new ICMPv4Packet
            {
                Bytes = new Byte[32]
            };

            icmpv4Packet.Id = 1;

            icmpv4Packet.Id.Should().Be(1);
        }
    }
}
