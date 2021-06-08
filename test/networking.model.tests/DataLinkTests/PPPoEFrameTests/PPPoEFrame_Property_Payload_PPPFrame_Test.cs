using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.PPPoEFrameTests
{
    public class PPPoEFrame_Property_Payload_PPPFrame_Test
    {
        [Fact]
        public void Get()
        {
            var pppoeFrame = new PPPoEFrame
            {
                Bytes = new Byte[14]
            };

            pppoeFrame.Payload.GetType().Should().Be(typeof(PPPFrame));
        }
    }
}
