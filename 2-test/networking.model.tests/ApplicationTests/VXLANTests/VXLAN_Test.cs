using System;
using FluentAssertions;
using Networking.Model.Application;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.VXLANTests
{
    public class VXLAN_Test
    {
        [Fact]
        public void EthernetFrame()
        {
            var vxlan = new VXLAN
            {
                Bytes = new Byte[]
                {
                    0b_0000_1000, 0, 0, 0,
                    0b_1001_0110, 0b_1010_0101, 0b_0100_1111, 0, 0
                }
            };

            vxlan.I.Should().Be(true);
            vxlan.VNI.Should().Be(0b_1001_0110_1010_0101_0100_1111);
            vxlan.Payload.GetType().Should().Be(typeof(EthernetFrame));
        }
    }
}
