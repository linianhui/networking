using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.BlockTests
{
    public class Block_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            Block.Layout.TypeBegin.Should().Be(0);
            Block.Layout.TypeEnd.Should().Be(4);

            Block.Layout.TotalLengthBegin.Should().Be(4);
            Block.Layout.TotalLengthEnd.Should().Be(8);

            Block.Layout.HeaderLength.Should().Be(8);
        }
    }
}
