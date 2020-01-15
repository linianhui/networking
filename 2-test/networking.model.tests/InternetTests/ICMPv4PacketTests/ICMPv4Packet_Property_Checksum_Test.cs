using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.ICMPv4PacketTests
{
    public class ICMPv4Packet_Property_Checksum_Test
    {
        [Fact]
        public void Get()
        {
            var icmpv4Packet = new ICMPv4Packet
            {
                Bytes = new Byte[32]
            };

            icmpv4Packet.SetBytes(2, 2, new Byte[] { 0x4d, 0x4a });

            icmpv4Packet.Checksum.Should().Be(19786);
        }

        [Fact]
        public void Set()
        {
            var icmpv4Packet = new ICMPv4Packet
            {
                Bytes = new Byte[32]
            };

            icmpv4Packet.Checksum = 19786;

            icmpv4Packet.Checksum.Should().Be(19786);
        }
    }
}
