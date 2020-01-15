using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.NameResolutionBlockTests
{
    public class NameResolutionBlock_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            NameResolutionBlock.Layout.RecordTypeBegin.Should().Be(0);
            NameResolutionBlock.Layout.RecordTypeEnd.Should().Be(2);

            NameResolutionBlock.Layout.RecordValueBegin.Should().Be(2);
            NameResolutionBlock.Layout.RecordValueEnd.Should().Be(4);

            NameResolutionBlock.Layout.RecordHeaderLength.Should().Be(4);
        }
    }
}
