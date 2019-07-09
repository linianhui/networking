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
            InterfaceDescriptionBlock.Layout.DataLinkTypeBegin.Should().Be(0);
            InterfaceDescriptionBlock.Layout.DataLinkTypeEnd.Should().Be(2);

            InterfaceDescriptionBlock.Layout.MaxCapturedLengthBegin.Should().Be(4);
            InterfaceDescriptionBlock.Layout.MaxCapturedLengthEnd.Should().Be(8);

            InterfaceDescriptionBlock.Layout.HeaderLength.Should().Be(8);
        }
    }
}
