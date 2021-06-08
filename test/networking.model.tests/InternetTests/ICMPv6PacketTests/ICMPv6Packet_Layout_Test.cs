using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.ICMPv6PacketTests
{
    public class ICMPv6Packet_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            ICMPv6Packet.Layout.TypeBegin.Should().Be(0);
            ICMPv6Packet.Layout.TypeEnd.Should().Be(1);

            ICMPv6Packet.Layout.CodeBegin.Should().Be(1);
            ICMPv6Packet.Layout.CodeEnd.Should().Be(2);

            ICMPv6Packet.Layout.TypeCodeBegin.Should().Be(0);
            ICMPv6Packet.Layout.TypeCodeEnd.Should().Be(2);

            ICMPv6Packet.Layout.ChecksumBegin.Should().Be(2);
            ICMPv6Packet.Layout.ChecksumEnd.Should().Be(4);

            ICMPv6Packet.Layout.IdBegin.Should().Be(4);
            ICMPv6Packet.Layout.IdEnd.Should().Be(6);

            ICMPv6Packet.Layout.SequenceBegin.Should().Be(6);
            ICMPv6Packet.Layout.SequenceEnd.Should().Be(8);
        }
    }
}
