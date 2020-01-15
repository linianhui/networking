using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.EnhancedPacketBlockTests
{
    public class EnhancedPacketBlock_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            EnhancedPacketBlock.Layout.InterfaceIdBegin.Should().Be(8);
            EnhancedPacketBlock.Layout.InterfaceIdEnd.Should().Be(12);

            EnhancedPacketBlock.Layout.TimestampHighBegin.Should().Be(12);
            EnhancedPacketBlock.Layout.TimestampHighEnd.Should().Be(16);

            EnhancedPacketBlock.Layout.TimestampLowBegin.Should().Be(16);
            EnhancedPacketBlock.Layout.TimestampLowEnd.Should().Be(20);

            EnhancedPacketBlock.Layout.CapturedLengthBegin.Should().Be(20);
            EnhancedPacketBlock.Layout.CapturedLengthEnd.Should().Be(24);

            EnhancedPacketBlock.Layout.OriginalLengthBegin.Should().Be(24);
            EnhancedPacketBlock.Layout.OriginalLengthEnd.Should().Be(28);

            EnhancedPacketBlock.Layout.HeaderLength.Should().Be(28);
            EnhancedPacketBlock.Layout.HeaderTotalLength.Should().Be(32);
        }
    }
}
