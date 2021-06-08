using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.ARPFrameTests
{
    public class ARPFrame_Property_ProtocolAddressLength_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { 0x04 , 4 }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte input, Byte expected)
        {
            var arpFrame = new ARPFrame
            {
                Bytes = new Byte[28]
            };

            arpFrame.SetByte(5, input);

            arpFrame.ProtocolAddressLength.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte expected, Byte input)
        {
            var arpFrame = new ARPFrame
            {
                Bytes = new Byte[28]
            };

            arpFrame.ProtocolAddressLength = input;

            arpFrame.GetByte(5).Should().Equals(expected);
            arpFrame.ProtocolAddressLength.Should().Be(expected);
        }
    }
}
