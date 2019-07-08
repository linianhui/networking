using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.BlockHeaderTests
{
    public class BlockHeader_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            BlockHeader.Layout.TypeBegin.Should().Be(0);
            BlockHeader.Layout.TypeEnd.Should().Be(4);

            BlockHeader.Layout.TotalLengthBegin.Should().Be(4);
            BlockHeader.Layout.TotalLengthEnd.Should().Be(8);

            BlockHeader.Layout.HeaderLength.Should().Be(8);
        }
    }
}
