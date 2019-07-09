using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.SectionHeaderBlockTests
{
    public class SectionHeaderBlock_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            SectionHeaderBlock.Layout.MagicNumberBegin.Should().Be(0);
            SectionHeaderBlock.Layout.MagicNumberEnd.Should().Be(4);

            SectionHeaderBlock.Layout.MajorVersionBegin.Should().Be(4);
            SectionHeaderBlock.Layout.MajorVersionEnd.Should().Be(6);

            SectionHeaderBlock.Layout.MinorVersionBegin.Should().Be(6);
            SectionHeaderBlock.Layout.MinorVersionEnd.Should().Be(8);

            SectionHeaderBlock.Layout.SectionLengthBegin.Should().Be(8);
            SectionHeaderBlock.Layout.SectionLengthEnd.Should().Be(12);

            SectionHeaderBlock.Layout.HeaderLength.Should().Be(12);
        }
    }
}
