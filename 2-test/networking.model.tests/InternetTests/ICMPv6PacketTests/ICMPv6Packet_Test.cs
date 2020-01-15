using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.ICMPv6PacketTests
{
    public class ICMPv6Packet_Test
    {
        [Fact]
        public void echo_request()
        {
            var icmpv6 = new ICMPv6Packet
            {
                Bytes = new Byte[]
                {
                    0x80, 0x00,
                    0x4d, 0x4a,
                    0x00, 0x01, 0x00, 0x11,
                    0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68,
                    0x69, 0x6a, 0x6b, 0x6c, 0x6d, 0x6e, 0x6f, 0x70,
                    0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x61,
                    0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69
                }
            };

            icmpv6.Type.Should().Be(ICMPv6Type.EchoRequest);
            icmpv6.Code.Should().Be(0);
            icmpv6.TypeCode.Should().Be(ICMPv6TypeCode.EchoRequest);
            icmpv6.Checksum.Should().Be(19786);
            icmpv6.Id.Should().Be(1);
            icmpv6.Sequence.Should().Be(17);

        }
    }
}
