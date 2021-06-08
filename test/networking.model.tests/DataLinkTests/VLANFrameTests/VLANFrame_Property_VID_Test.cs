using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.VLANFrameTests
{
    public class VLANFrame_Property_VID_Test
    {
        [Fact]
        public void Get()
        {
            var vlanFrame = new VLANFrame
            {
                Bytes = new Byte[4]
            };
            vlanFrame.SetByte(0, 0b_0001_1100);
            vlanFrame.SetByte(1, 0b_1010_0101);

            vlanFrame.VID.Should().Be(0b_1100_1010_0101);
        }

        [Fact]
        public void Set()
        {
            var vlanFrame = new VLANFrame
            {
                Bytes = new Byte[4]
            };

            vlanFrame.SetByte(0, 0b_1110_0000);
            vlanFrame.VID = 0b_1100_1010_0101;

            vlanFrame.GetByte(0).Should().Be(0b_1110_1100);
            vlanFrame.GetByte(1).Should().Be(0b_1010_0101);
        }
    }
}
