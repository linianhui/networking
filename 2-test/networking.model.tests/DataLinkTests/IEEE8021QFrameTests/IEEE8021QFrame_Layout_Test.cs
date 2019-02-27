using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.IEEE8021QFrameTests
{
    public class IEEE8021QFrame_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            IEEE8021QFrame.Layout.PCPBegin.Should().Be(0);
            IEEE8021QFrame.Layout.PCPBitIndex.Should().Be(0);
            IEEE8021QFrame.Layout.PCPBitLength.Should().Be(3);

            IEEE8021QFrame.Layout.DEIBegin.Should().Be(0);
            IEEE8021QFrame.Layout.DEIBitIndex.Should().Be(3);

            IEEE8021QFrame.Layout.VIDBegin.Should().Be(0);
            IEEE8021QFrame.Layout.VIDBitIndex.Should().Be(4);
            IEEE8021QFrame.Layout.VIDBitLength.Should().Be(12);

            IEEE8021QFrame.Layout.TypeBegin.Should().Be(2);
            IEEE8021QFrame.Layout.TypeEnd.Should().Be(4);

            IEEE8021QFrame.Layout.HeaderLength.Should().Be(4);
        }
    }
}
