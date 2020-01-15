using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.VXLANTests
{
    public class VXLAN_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            VXLAN.Layout.TagBegin.Should().Be(0);
            VXLAN.Layout.TagIBitIndex.Should().Be(4);

            VXLAN.Layout.VNIBegin.Should().Be(4);
            VXLAN.Layout.VNIBitIndex.Should().Be(0);
            VXLAN.Layout.VNIBitLength.Should().Be(24);

            VXLAN.Layout.HeaderLength.Should().Be(8);
        }
    }
}
