using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.UDPSegmentTests
{
    public class UDPSegment_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            UDPSegment.Layout.SourcePortBegin.Should().Be(0);
            UDPSegment.Layout.SourcePortEnd.Should().Be(2);

            UDPSegment.Layout.DestinationPortBegin.Should().Be(2);
            UDPSegment.Layout.DestinationPortEnd.Should().Be(4);

            UDPSegment.Layout.TotalLengthBegin.Should().Be(4);
            UDPSegment.Layout.TotalLengthEnd.Should().Be(6);

            UDPSegment.Layout.ChecksumBegin.Should().Be(6);
            UDPSegment.Layout.ChecksumEnd.Should().Be(8);

            UDPSegment.Layout.HeaderLength.Should().Be(8);
        }
    }
}
