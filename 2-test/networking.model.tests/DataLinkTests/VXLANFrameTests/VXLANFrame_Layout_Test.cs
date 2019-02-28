using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.VXLANFrameTests
{
    public class VXLANFrame_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            VXLANFrame.Layout.TagBegin.Should().Be(0);
            VXLANFrame.Layout.TagIBitIndex.Should().Be(4);

            VXLANFrame.Layout.VNIBegin.Should().Be(4);
            VXLANFrame.Layout.VNIBitIndex.Should().Be(0);
            VXLANFrame.Layout.VNIBitLength.Should().Be(24);

            VXLANFrame.Layout.HeaderLength.Should().Be(8);
        }
    }
}
