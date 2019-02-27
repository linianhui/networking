using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.IEEE8021QFrameTests
{
    public class IEEE8021QFrame_Property_PCP_Test
    {
        [Fact]
        public void Get()
        {
            var ieee8021QFrame = new IEEE8021QFrame
            {
                Bytes = new Byte[4]
            };
            ieee8021QFrame.SetByte(0, 0b_0101_1111);

            ieee8021QFrame.PCP.Should().Be(0b_010);
        }

        [Fact]
        public void Set()
        {
            var ieee8021QFrame = new IEEE8021QFrame
            {
                Bytes = new Byte[4]
            };

            ieee8021QFrame.SetByte(0, 0b_0101_1111);
            ieee8021QFrame.PCP = 0b_101;

            ieee8021QFrame.GetByte(0).Should().Be(0b_1011_1111);
        }
    }
}
