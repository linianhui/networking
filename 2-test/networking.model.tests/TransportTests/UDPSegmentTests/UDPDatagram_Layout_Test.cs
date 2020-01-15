using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.UDPDatagramTests
{
    public class UDPDatagram_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            UDPDatagram.Layout.SourcePortBegin.Should().Be(0);
            UDPDatagram.Layout.SourcePortEnd.Should().Be(2);

            UDPDatagram.Layout.DestinationPortBegin.Should().Be(2);
            UDPDatagram.Layout.DestinationPortEnd.Should().Be(4);

            UDPDatagram.Layout.TotalLengthBegin.Should().Be(4);
            UDPDatagram.Layout.TotalLengthEnd.Should().Be(6);

            UDPDatagram.Layout.ChecksumBegin.Should().Be(6);
            UDPDatagram.Layout.ChecksumEnd.Should().Be(8);

            UDPDatagram.Layout.HeaderLength.Should().Be(8);
        }
    }
}
