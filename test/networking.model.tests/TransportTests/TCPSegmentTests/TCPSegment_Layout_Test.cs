using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.TCPSegmentTests
{
    public class TCPSegment_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            TCPSegment.Layout.SourcePortBegin.Should().Be(0);
            TCPSegment.Layout.SourcePortEnd.Should().Be(2);

            TCPSegment.Layout.DestinationPortBegin.Should().Be(2);
            TCPSegment.Layout.DestinationPortEnd.Should().Be(4);

            TCPSegment.Layout.SequenceNumberBegin.Should().Be(4);
            TCPSegment.Layout.SequenceNumberEnd.Should().Be(8);

            TCPSegment.Layout.AcknowledgmentNumberBegin.Should().Be(8);
            TCPSegment.Layout.AcknowledgmentNumberEnd.Should().Be(12);

            TCPSegment.Layout.HeaderLengthBegin.Should().Be(12);
            TCPSegment.Layout.HeaderLengthEnd.Should().Be(13);

            TCPSegment.Layout.FlagsBegin.Should().Be(13);
            TCPSegment.Layout.FlagsEnd.Should().Be(14);
            TCPSegment.Layout.FlagsNSBitIndex.Should().Be(7);
            TCPSegment.Layout.FlagsCWRBitIndex.Should().Be(0);
            TCPSegment.Layout.FlagsECEBitIndex.Should().Be(1);
            TCPSegment.Layout.FlagsURGBitIndex.Should().Be(2);
            TCPSegment.Layout.FlagsACKBitIndex.Should().Be(3);
            TCPSegment.Layout.FlagsPSHBitIndex.Should().Be(4);
            TCPSegment.Layout.FlagsRSTBitIndex.Should().Be(5);
            TCPSegment.Layout.FlagsSYNBitIndex.Should().Be(6);
            TCPSegment.Layout.FlagsFINBitIndex.Should().Be(7);

            TCPSegment.Layout.WindowsSizeBegin.Should().Be(14);
            TCPSegment.Layout.WindowsSizeEnd.Should().Be(16);

            TCPSegment.Layout.ChecksumBegin.Should().Be(16);
            TCPSegment.Layout.ChecksumEnd.Should().Be(18);

            TCPSegment.Layout.UrgentPointerBegin.Should().Be(18);
            TCPSegment.Layout.UrgentPointerEnd.Should().Be(20);
        }
    }
}
