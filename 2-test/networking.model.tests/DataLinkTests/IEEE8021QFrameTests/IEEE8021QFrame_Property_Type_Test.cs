using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.IEEE8021QFrameTests
{
    public class IEEE8021QFrame_Property_Type_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { new Byte[]{ 0x00, 0x00 }, EthernetFrameType.Unknown },
            new Object[] { new Byte[]{ 0x08, 0x00 }, EthernetFrameType.IPv4 },
            new Object[] { new Byte[]{ 0x08, 0x06 }, EthernetFrameType.ARP },
            new Object[] { new Byte[]{ 0x86, 0xDD }, EthernetFrameType.IPv6 },
            new Object[] { new Byte[]{ 0x88, 0x63 }, EthernetFrameType.PPPoEDiscoveryStage },
            new Object[] { new Byte[]{ 0x88, 0x64 }, EthernetFrameType.PPPoESessionStage },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte[] input, EthernetFrameType expected)
        {
            var ieee8021QFrame = new IEEE8021QFrame
            {
                Bytes = new Byte[4]
            };

            ieee8021QFrame[2, 2] = input;

            ieee8021QFrame.Type.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte[] expected, EthernetFrameType input)
        {
            var ieee8021QFrame = new IEEE8021QFrame
            {
                Bytes = new Byte[4]
            };

            ieee8021QFrame.Type = input;

            ieee8021QFrame[2, 2].ToArray().Should().Equal(expected);
            ieee8021QFrame.Type.Should().Be(input);
        }
    }
}
