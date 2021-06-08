using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.EthernetFrameTests
{
    public class EthernetFrame_Property_Type_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { new Byte[]{ 0x00, 0x00 }, EthernetFrameType.Unknown },
            new Object[] { new Byte[]{ 0x08, 0x00 }, EthernetFrameType.IPv4 },
            new Object[] { new Byte[]{ 0x08, 0x06 }, EthernetFrameType.ARP },
            new Object[] { new Byte[]{ 0x81, 0x00 }, EthernetFrameType.VLAN },
            new Object[] { new Byte[]{ 0x86, 0xDD }, EthernetFrameType.IPv6 },
            new Object[] { new Byte[]{ 0x88, 0x63 }, EthernetFrameType.PPPoEDiscoveryStage },
            new Object[] { new Byte[]{ 0x88, 0x64 }, EthernetFrameType.PPPoESessionStage },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte[] input, EthernetFrameType expected)
        {
            var ethernetFrame = new EthernetFrame
            {
                Bytes = new Byte[14]
            };

            ethernetFrame.SetBytes(12, 2, input);

            ethernetFrame.Type.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte[] expected, EthernetFrameType input)
        {
            var ethernetFrame = new EthernetFrame
            {
                Bytes = new Byte[14]
            };

            ethernetFrame.Type = input;

            ethernetFrame.GetBytes(12, 2).ToArray().Should().Equal(expected);
            ethernetFrame.Type.Should().Be(input);
        }
    }
}
