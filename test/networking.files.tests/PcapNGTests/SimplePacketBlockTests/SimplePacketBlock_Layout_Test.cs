using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.SimplePacketBlockTests
{
    public class SimplePacketBlock_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            SimplePacketBlock.Layout.OriginalLengthBegin.Should().Be(8);
            SimplePacketBlock.Layout.OriginalLengthEnd.Should().Be(12);

            SimplePacketBlock.Layout.HeaderLength.Should().Be(12);
        }
    }
}
