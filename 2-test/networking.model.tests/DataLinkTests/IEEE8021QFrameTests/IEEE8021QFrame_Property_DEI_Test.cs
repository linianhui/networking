using System;
using FluentAssertions;
using Xunit;
using Networking.Model.DataLink;

namespace Networking.Model.Tests.DataLinkTests.IPv4PacketTests
{
    public class IEEE8021QFrame_Property_DEI_Test
    {
        [Fact]
        public void Get()
        {
            var ieee8021QFrame = new IEEE8021QFrame
            {
                Bytes = new Byte[4]
            };
            ieee8021QFrame.SetByte(0, 0b_0001_0000);

            ieee8021QFrame.DEI.Should().Be(true);
        }

        [Fact]
        public void Set()
        {
            var ieee8021QFrame = new IEEE8021QFrame
            {
                Bytes = new Byte[4]
            };

            ieee8021QFrame.DEI = true;
            ieee8021QFrame.GetByte(0).Should().Be(0b_0001_0000);

            ieee8021QFrame.DEI = false;
            ieee8021QFrame.GetByte(0).Should().Be(0b_0000_0000);
        }
    }
}
