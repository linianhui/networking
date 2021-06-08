using FluentAssertions;
using Networking.Files.Pcap;
using Xunit;

namespace Networking.Files.Tests.PcapTests.PcapFileHeaderTests
{
    public class PcapFileHeader_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            PcapFileHeader.Layout.MagicNumberBegin.Should().Be(0);
            PcapFileHeader.Layout.MagicNumberEnd.Should().Be(4);

            PcapFileHeader.Layout.MajorVersionBegin.Should().Be(4);
            PcapFileHeader.Layout.MajorVersionEnd.Should().Be(6);

            PcapFileHeader.Layout.MinorVersionBegin.Should().Be(6);
            PcapFileHeader.Layout.MinorVersionEnd.Should().Be(8);

            PcapFileHeader.Layout.MaxCapturedLengthBegin.Should().Be(16);
            PcapFileHeader.Layout.MaxCapturedLengthEnd.Should().Be(20);

            PcapFileHeader.Layout.DataLinkTypeBegin.Should().Be(20);
            PcapFileHeader.Layout.DataLinkTypeEnd.Should().Be(24);

            PcapFileHeader.Layout.HeaderLength.Should().Be(24);
        }
    }
}
