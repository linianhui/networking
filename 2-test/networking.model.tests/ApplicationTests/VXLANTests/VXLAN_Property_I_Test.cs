using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.VXLANTests
{
    public class VXLAN_Property_I_Test
    {
        [Fact]
        public void Get()
        {
            var vxlan = new VXLAN
            {
                Bytes = new Byte[8]
            };
            vxlan.SetByte(0, 0b_0000_1000);

            vxlan.I.Should().Be(true);
        }

        [Fact]
        public void Set()
        {
            var vxlan = new VXLAN
            {
                Bytes = new Byte[4]
            };

            vxlan.I = true;
            vxlan.GetByte(0).Should().Be(0b_0000_1000);

            vxlan.I = false;
            vxlan.GetByte(0).Should().Be(0b_0000_0000);
        }
    }
}
