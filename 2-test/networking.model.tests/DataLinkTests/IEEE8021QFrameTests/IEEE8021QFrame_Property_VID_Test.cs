using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.IEEE8021QFrameTests
{
    public class IEEE8021QFrame_Property_VID_Test
    {
        [Fact]
        public void Get()
        {
            var ieee8021QFrame = new IEEE8021QFrame
            {
                Bytes = new Byte[4]
            };
            ieee8021QFrame.SetByte(0, 0b_0001_1100);
            ieee8021QFrame.SetByte(1, 0b_1010_0101);

            ieee8021QFrame.VID.Should().Be(0b_1100_1010_0101);
        }

        [Fact]
        public void Set()
        {
            var ieee8021QFrame = new IEEE8021QFrame
            {
                Bytes = new Byte[4]
            };

            ieee8021QFrame.SetByte(0, 0b_1110_0000);
            ieee8021QFrame.VID = 0b_1100_1010_0101;

            ieee8021QFrame.GetByte(0).Should().Be(0b1110_1100);
            ieee8021QFrame.GetByte(1).Should().Be(0b1010_0101);
        }
    }
}
