using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.VLANFrameTests
{
    public class VLANFrame_Property_PCP_Test
    {
        [Fact]
        public void Get()
        {
            var vlanFrame = new VLANFrame
            {
                Bytes = new Byte[4]
            };
            vlanFrame.SetByte(0, 0b_0101_1111);

            vlanFrame.PCP.Should().Be(0b_010);
        }

        [Fact]
        public void Set()
        {
            var vlanFrame = new VLANFrame
            {
                Bytes = new Byte[4]
            };

            vlanFrame.SetByte(0, 0b_0101_1111);
            vlanFrame.PCP = 0b_101;

            vlanFrame.GetByte(0).Should().Be(0b_1011_1111);
        }
    }
}
