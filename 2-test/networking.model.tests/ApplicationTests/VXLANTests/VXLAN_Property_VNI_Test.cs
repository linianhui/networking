using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.VXLANTests
{
    public class VXLAN_Property_VNI_Test
    {
        [Fact]
        public void Get()
        {
            var vxlan = new VXLAN
            {
                Bytes = new Byte[8]
            };
            vxlan.SetByte(4, 0b_1001_0110);
            vxlan.SetByte(5, 0b_1010_0101);
            vxlan.SetByte(6, 0b_0100_1111);

            vxlan.VNI.Should().Be(0b_1001_0110_1010_0101_0100_1111);
        }

        [Fact]
        public void Set()
        {
            var vxlan = new VXLAN
            {
                Bytes = new Byte[8]
            };

            vxlan.SetByte(7, 0b_1110_0000);
            vxlan.VNI = 0b_1001_0110_1010_0101_0100_1111;

            vxlan.GetByte(4).Should().Be(0b_1001_0110);
            vxlan.GetByte(5).Should().Be(0b_1010_0101);
            vxlan.GetByte(6).Should().Be(0b_0100_1111);
            vxlan.GetByte(7).Should().Be(0b_1110_0000);
        }
    }
}
