using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.IEEE8021QFrameTests
{
    public class IEEE8021QFrame_Test
    {
        [Fact]
        public void ipv4()
        {
            var ieee8021QFrame = new IEEE8021QFrame
            {
                Bytes = new Byte[]
                {
                    0b_101_1_1010, 0b_1100_0011,
                    0x08, 0x00
                }
            };


            ieee8021QFrame.PCP.Should().Be(0b_101);
            ieee8021QFrame.DEI.Should().Be(true);
            ieee8021QFrame.VID.Should().Be(0b_1010_1100_0011);
            ieee8021QFrame.Type.Should().Be(EthernetFrameType.IPv4);
        }
    }
}
