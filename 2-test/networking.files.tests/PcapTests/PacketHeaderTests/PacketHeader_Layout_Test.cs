using FluentAssertions;
using Networking.Files.Pcap;
using Xunit;

namespace Networking.Files.Tests.PcapTests.PacketHeaderTests
{
    public class PacketHeader_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            PacketHeader.Layout.TimestampSecondPartBegin.Should().Be(0);
            PacketHeader.Layout.TimestampSecondPartEnd.Should().Be(4);

            PacketHeader.Layout.TimestampMicrosecondPartBegin.Should().Be(4);
            PacketHeader.Layout.TimestampMicrosecondPartEnd.Should().Be(8);

            PacketHeader.Layout.CapturedLengthBegin.Should().Be(8);
            PacketHeader.Layout.CapturedLengthEnd.Should().Be(12);

            PacketHeader.Layout.OriginalLengthBegin.Should().Be(12);
            PacketHeader.Layout.OriginalLengthEnd.Should().Be(16);

            PacketHeader.Layout.HeaderLength.Should().Be(16);
        }
    }
}
