using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.InterfaceDescriptionBlockTests
{
    public class InterfaceDescriptionBlock_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            InterfaceDescriptionBlock.Layout.DataLinkTypeBegin.Should().Be(8);
            InterfaceDescriptionBlock.Layout.DataLinkTypeEnd.Should().Be(10);

            InterfaceDescriptionBlock.Layout.MaxCapturedLengthBegin.Should().Be(12);
            InterfaceDescriptionBlock.Layout.MaxCapturedLengthEnd.Should().Be(16);

            InterfaceDescriptionBlock.Layout.HeaderLength.Should().Be(16);
        }
    }
}
