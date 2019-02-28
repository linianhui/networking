using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.DataLink;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.VXLANFrameTests
{
    public class VXLANFrame_Property_Payload_Test
    {
        [Fact]
        public void Get()
        {
            var vlanFrame = new VXLANFrame
            {
                Bytes = new Byte[32]
            };

            vlanFrame.Payload.GetType().Should().Be(typeof(EthernetFrame));
        }
    }
}
