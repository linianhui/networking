using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.PPPFrameTests
{
    public class PPPFrame_Property_Type_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { new Byte[]{ 0x00, 0x01 }, PPPFrameType.Padding },
            new Object[] { new Byte[]{ 0x00, 0x21 }, PPPFrameType.IPv4 },
            new Object[] { new Byte[]{ 0x00, 0x57 }, PPPFrameType.IPv6 }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte[] input, PPPFrameType expected)
        {
            var pppFrame = new PPPFrame
            {
                Bytes = new Byte[14]
            };

            pppFrame.SetBytes(0, 2, input);

            pppFrame.Type.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte[] expected, PPPFrameType input)
        {
            var pppFrame = new PPPFrame
            {
                Bytes = new Byte[14]
            };

            pppFrame.Type = input;

            pppFrame.GetBytes(0, 2).ToArray().Should().Equal(expected);
            pppFrame.Type.Should().Be(input);
        }
    }
}
