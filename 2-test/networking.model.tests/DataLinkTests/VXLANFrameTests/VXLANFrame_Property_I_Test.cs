using System;
using FluentAssertions;
using Xunit;
using Networking.Model.DataLink;

namespace Networking.Model.Tests.DataLinkTests.VXLANFrameTests
{
    public class VXLANFrame_Property_I_Test
    {
        [Fact]
        public void Get()
        {
            var vxlanFrame = new VXLANFrame
            {
                Bytes = new Byte[8]
            };
            vxlanFrame.SetByte(0, 0b_0000_1000);

            vxlanFrame.I.Should().Be(true);
        }

        [Fact]
        public void Set()
        {
            var vlanFrame = new VXLANFrame
            {
                Bytes = new Byte[4]
            };

            vlanFrame.I = true;
            vlanFrame.GetByte(0).Should().Be(0b_0000_1000);

            vlanFrame.I = false;
            vlanFrame.GetByte(0).Should().Be(0b_0000_0000);
        }
    }
}
