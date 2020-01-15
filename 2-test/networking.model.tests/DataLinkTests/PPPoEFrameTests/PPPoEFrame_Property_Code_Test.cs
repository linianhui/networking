using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.PPPoEFrameTests
{
    public class PPPoEFrame_Property_Code_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { 0x07, PPPoEFrameCode.PADO },
            new Object[] { 0x09, PPPoEFrameCode.PADI },
            new Object[] { 0x19, PPPoEFrameCode.PADR },
            new Object[] { 0x65, PPPoEFrameCode.PADS }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte input, PPPoEFrameCode expected)
        {
            var pppoeFrame = new PPPoEFrame
            {
                Bytes = new Byte[14]
            };

            pppoeFrame.SetByte(1, input);

            pppoeFrame.Code.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte expected, PPPoEFrameCode input)
        {
            var pppoeFrame = new PPPoEFrame
            {
                Bytes = new Byte[14]
            };

            pppoeFrame.Code = input;

            pppoeFrame.GetByte(1).Should().Be(expected);
            pppoeFrame.Code.Should().Be(input);
        }
    }
}
