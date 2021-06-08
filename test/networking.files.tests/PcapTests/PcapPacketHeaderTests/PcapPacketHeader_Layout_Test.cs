using FluentAssertions;
using Networking.Files.Pcap;
using Xunit;

namespace Networking.Files.Tests.PcapTests.PcapPacketHeaderTests
{
    public class PcapPacketHeader_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            PcapPacketHeader.Layout.TimestampSecondPartBegin.Should().Be(0);
            PcapPacketHeader.Layout.TimestampSecondPartEnd.Should().Be(4);

            PcapPacketHeader.Layout.TimestampMicrosecondPartBegin.Should().Be(4);
            PcapPacketHeader.Layout.TimestampMicrosecondPartEnd.Should().Be(8);

            PcapPacketHeader.Layout.CapturedLengthBegin.Should().Be(8);
            PcapPacketHeader.Layout.CapturedLengthEnd.Should().Be(12);

            PcapPacketHeader.Layout.OriginalLengthBegin.Should().Be(12);
            PcapPacketHeader.Layout.OriginalLengthEnd.Should().Be(16);

            PcapPacketHeader.Layout.HeaderLength.Should().Be(16);
        }
    }
}
