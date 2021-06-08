using System;
using FluentAssertions;
using Networking.Model.Application;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.VXLANTests
{
    public class VXLAN_Property_Payload_Test
    {
        [Fact]
        public void Get()
        {
            var vxlan = new VXLAN
            {
                Bytes = new Byte[32]
            };

            vxlan.Payload.GetType().Should().Be(typeof(EthernetFrame));
        }
    }
}
