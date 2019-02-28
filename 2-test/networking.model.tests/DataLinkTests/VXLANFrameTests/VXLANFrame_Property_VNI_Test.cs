using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.VXLANFrameTests
{
    public class VXLANFrame_Property_VNI_Test
    {
        [Fact]
        public void Get()
        {
            var vxlanFrame = new VXLANFrame
            {
                Bytes = new Byte[8]
            };
            vxlanFrame.SetByte(4, 0b_1001_0110);
            vxlanFrame.SetByte(5, 0b_1010_0101);
            vxlanFrame.SetByte(6, 0b_0100_1111);

            vxlanFrame.VNI.Should().Be(0b_1001_0110_1010_0101_0100_1111);
        }

        [Fact]
        public void Set()
        {
            var vxlanFrame = new VXLANFrame
            {
                Bytes = new Byte[8]
            };

            vxlanFrame.SetByte(7, 0b_1110_0000);
            vxlanFrame.VNI = 0b_1001_0110_1010_0101_0100_1111;

            vxlanFrame.GetByte(4).Should().Be(0b_1001_0110);
            vxlanFrame.GetByte(5).Should().Be(0b_1010_0101);
            vxlanFrame.GetByte(6).Should().Be(0b_0100_1111);
            vxlanFrame.GetByte(7).Should().Be(0b_1110_0000);
        }
    }
}
