using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Test.DataLink
{
    public class EthernetFrameTypeTest
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { new Byte[]{ 0x00, 0x00 }, EthernetFrameType.Unknown },
            new Object[] { new Byte[]{ 0x08, 0x00 }, EthernetFrameType.IPv4 },
            new Object[] { new Byte[]{ 0x08, 0x06 }, EthernetFrameType.ARP },
            new Object[] { new Byte[]{ 0x86, 0xDD }, EthernetFrameType.IPv6 }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void type(Byte[] bytes, EthernetFrameType type)
        {
            var ethernetFrame = new EthernetFrame
            {
                Bytes = new Byte[14]
            };
            if (bytes != null)
            {
                ethernetFrame[12, 2] = bytes;
            }

            ethernetFrame.Type.Should().Be(type);
        }
    }
}
