using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.ICMPv4PacketTests
{
    public class ICMPv4Packet_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            ICMPv4Packet.Layout.TypeCodeBegin.Should().Be(0);
            ICMPv4Packet.Layout.TypeCodeEnd.Should().Be(2);

            ICMPv4Packet.Layout.ChecksumBegin.Should().Be(2);
            ICMPv4Packet.Layout.ChecksumEnd.Should().Be(4);

            ICMPv4Packet.Layout.IdBegin.Should().Be(4);
            ICMPv4Packet.Layout.IdEnd.Should().Be(6);

            ICMPv4Packet.Layout.SequenceBegin.Should().Be(6);
            ICMPv4Packet.Layout.SequenceEnd.Should().Be(8);
        }
    }
}
