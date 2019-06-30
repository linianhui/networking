using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.SectionHeaderBodyTests
{
    public class SectionHeaderBody_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            SectionHeaderBody.Layout.ByteOrderMagicBegin.Should().Be(0);
            SectionHeaderBody.Layout.ByteOrderMagicEnd.Should().Be(4);

            SectionHeaderBody.Layout.MajorVersionBegin.Should().Be(4);
            SectionHeaderBody.Layout.MajorVersionEnd.Should().Be(6);

            SectionHeaderBody.Layout.MinorVersionBegin.Should().Be(6);
            SectionHeaderBody.Layout.MinorVersionEnd.Should().Be(8);

            SectionHeaderBody.Layout.SectionLengthBegin.Should().Be(8);
            SectionHeaderBody.Layout.SectionLengthEnd.Should().Be(12);

            SectionHeaderBody.Layout.HeaderLength.Should().Be(12);
        }
    }
}
