using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.SimplePacketBodyTests
{
    public class SimplePacketBody_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            SimplePacketBody.Layout.OriginalLengthBegin.Should().Be(0);
            SimplePacketBody.Layout.OriginalLengthEnd.Should().Be(4);

            SimplePacketBody.Layout.HeaderLength.Should().Be(4);
        }
    }
}
