using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.InterfaceStatisticsBlockTests
{
    public class InterfaceStatisticsBlock_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            InterfaceStatisticsBlock.Layout.InterfaceIdBegin.Should().Be(8);
            InterfaceStatisticsBlock.Layout.InterfaceIdEnd.Should().Be(12);

            InterfaceStatisticsBlock.Layout.TimestampHighBegin.Should().Be(12);
            InterfaceStatisticsBlock.Layout.TimestampHighEnd.Should().Be(16);

            InterfaceStatisticsBlock.Layout.TimestampLowBegin.Should().Be(16);
            InterfaceStatisticsBlock.Layout.TimestampLowEnd.Should().Be(20);

            InterfaceStatisticsBlock.Layout.HeaderLength.Should().Be(20);
            InterfaceStatisticsBlock.Layout.HeaderTotalLength.Should().Be(24);
        }
    }
}
