using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.VLANFrameTests
{
    public class VLANFrame_Property_Type_Test
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
            var vlanFrame = new VLANFrame
            {
                Bytes = new Byte[4]
            };

            vlanFrame.SetBytes(2, 2, input);

            vlanFrame.Type.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte[] expected, EthernetFrameType input)
        {
            var vlanFrame = new VLANFrame
            {
                Bytes = new Byte[4]
            };

            vlanFrame.Type = input;

            vlanFrame.GetBytes(2, 2).ToArray().Should().Equal(expected);
            vlanFrame.Type.Should().Be(input);
        }
    }
}
