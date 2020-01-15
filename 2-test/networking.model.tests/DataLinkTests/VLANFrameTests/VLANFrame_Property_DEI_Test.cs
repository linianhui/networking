using System;
using FluentAssertions;
using Xunit;
using Networking.Model.DataLink;

namespace Networking.Model.Tests.DataLinkTests.VLANFrameTests
{
    public class VLANFrame_Property_DEI_Test
    {
        [Fact]
        public void Get()
        {
            var vlanFrame = new VLANFrame
            {
                Bytes = new Byte[4]
            };
            vlanFrame.SetByte(0, 0b_0001_0000);

            vlanFrame.DEI.Should().Be(true);
        }

        [Fact]
        public void Set()
        {
            var vlanFrame = new VLANFrame
            {
                Bytes = new Byte[4]
            };

            vlanFrame.DEI = true;
            vlanFrame.GetByte(0).Should().Be(0b_0001_0000);

            vlanFrame.DEI = false;
            vlanFrame.GetByte(0).Should().Be(0b_0000_0000);
        }
    }
}
