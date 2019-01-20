using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.ARPFrameTests
{
    public class ARPFrame_Property_HardwareAddressLength_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { 0x06 , 6 }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte input, Byte expected)
        {
            var arpFrame = new ARPFrame
            {
                Bytes = new Byte[28]
            };

            arpFrame[4] = input;

            arpFrame.HardwareAddressLength.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte input, Byte expected)
        {
            var arpFrame = new ARPFrame
            {
                Bytes = new Byte[28]
            };

            arpFrame.HardwareAddressLength = input;

            arpFrame.HardwareAddressLength.Should().Be(expected);
        }
    }
}
