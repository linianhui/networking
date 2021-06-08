using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.ICMPv4PacketTests
{
    public class ICMPv4Packet_Property_Sequence_Test
    {
        [Fact]
        public void Get()
        {
            var icmpv4Packet = new ICMPv4Packet
            {
                Bytes = new Byte[32]
            };

            icmpv4Packet.SetBytes(6, 2, new Byte[] { 0x00, 0x11 });

            icmpv4Packet.Sequence.Should().Be(17);
        }

        [Fact]
        public void Set()
        {
            var icmpv4Packet = new ICMPv4Packet
            {
                Bytes = new Byte[32]
            };

            icmpv4Packet.Sequence = 17;

            icmpv4Packet.Sequence.Should().Be(17);
        }
    }
}
