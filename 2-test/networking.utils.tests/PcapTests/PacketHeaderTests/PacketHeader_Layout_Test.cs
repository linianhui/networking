using FluentAssertions;
using Networking.Utils.Pcap;
using Xunit;

namespace Networking.Utils.Tests.PcapTests.PacketHeaderTests
{
    public class PacketHeader_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            PacketHeader.Layout.TimestampSecondsBegin.Should().Be(0);
            PacketHeader.Layout.TimestampSecondsEnd.Should().Be(4);

            PacketHeader.Layout.TimestampMicrosecondsBegin.Should().Be(4);
            PacketHeader.Layout.TimestampMicrosecondsEnd.Should().Be(8);

            PacketHeader.Layout.SavedLengthBegin.Should().Be(8);
            PacketHeader.Layout.SavedLengthEnd.Should().Be(12);

            PacketHeader.Layout.OriginalLengthBegin.Should().Be(12);
            PacketHeader.Layout.OriginalLengthEnd.Should().Be(16);

            PacketHeader.Layout.HeaderLength.Should().Be(16);
        }
    }
}
