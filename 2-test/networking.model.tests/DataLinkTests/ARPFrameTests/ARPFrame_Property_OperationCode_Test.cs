using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.ARPFrameTests
{
    public class ARPFrame_Property_OperationCode_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { new Byte[]{ 0x00, 0x01 }, ARPOperationCode.Request },
            new Object[] { new Byte[]{ 0x00, 0x02 }, ARPOperationCode.Response }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte[] input, ARPOperationCode expected)
        {
            var arpFrame = new ARPFrame
            {
                Bytes = new Byte[28]
            };

            arpFrame.SetBytes(6, 2, input);

            arpFrame.OperationCode.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte[] expected, ARPOperationCode input)
        {
            var arpFrame = new ARPFrame
            {
                Bytes = new Byte[28]
            };

            arpFrame.OperationCode = input;

            arpFrame.GetBytes(6, 2).ToArray().Should().Equal(expected);
            arpFrame.OperationCode.Should().Be(input);
        }
    }
}
