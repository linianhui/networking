using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.VXLANFrameTests
{
    public class VXLANFrame_Test
    {
        [Fact]
        public void EthernetFrame()
        {
            var vxlanFrame = new VXLANFrame
            {
                Bytes = new Byte[]
                {
                    0b_0000_1000, 0, 0, 0,
                    0b_1001_0110, 0b_1010_0101, 0b_0100_1111, 0, 0
                }
            };

            vxlanFrame.I.Should().Be(true);
            vxlanFrame.VNI.Should().Be(0b_1001_0110_1010_0101_0100_1111);
            vxlanFrame.Payload.GetType().Should().Be(typeof(EthernetFrame));
        }
    }
}
