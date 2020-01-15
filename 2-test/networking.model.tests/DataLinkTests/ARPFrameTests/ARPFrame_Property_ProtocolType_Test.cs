using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.ARPFrameTests
{
    public class ARPFrame_Property_ProtocolType_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { new Byte[]{ 0x08, 0x00 }, EthernetFrameType.IPv4 }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte[] input, EthernetFrameType expected)
        {
            var arpFrame = new ARPFrame
            {
                Bytes = new Byte[28]
            };


            arpFrame.SetBytes(2, 2, input);


            arpFrame.ProtocolType.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte[] expected, EthernetFrameType input)
        {
            var arpFrame = new ARPFrame
            {
                Bytes = new Byte[28]
            };

            arpFrame.ProtocolType = input;

            arpFrame.GetBytes(2, 2).ToArray().Should().Equal(expected);
            arpFrame.ProtocolType.Should().Be(input);
        }
    }
}
