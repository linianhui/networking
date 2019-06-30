using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.InterfaceDescriptionBodyTests
{
    public class InterfaceDescriptionBody_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            InterfaceDescriptionBody.Layout.DataLinkTypeBegin.Should().Be(0);
            InterfaceDescriptionBody.Layout.DataLinkTypeEnd.Should().Be(2);

            InterfaceDescriptionBody.Layout.HeaderLength.Should().Be(8);
        }
    }
}
