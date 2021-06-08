using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.PPPoEFrameTests
{
    public class PPPoEFrame_Property_SessionId_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { new Byte[]{ 0x00, 0x06 } , 6 },
            new Object[] { new Byte[]{ 0x00, 0x18 } , 24 },
            new Object[] { new Byte[]{ 0x01, 0x01 } , 257 },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte[] input, UInt16 expected)
        {
            var pppoeFrame = new PPPoEFrame
            {
                Bytes = new Byte[28]
            };

            pppoeFrame.SetBytes(2, 2, input);

            pppoeFrame.SessionId.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte[] expected, UInt16 input)
        {
            var pppoeFrame = new PPPoEFrame
            {
                Bytes = new Byte[28]
            };

            pppoeFrame.SessionId = input;

            pppoeFrame.GetBytes(2, 2).ToArray().Should().Equal(expected);
            pppoeFrame.SessionId.Should().Be(input);
        }
    }
}
