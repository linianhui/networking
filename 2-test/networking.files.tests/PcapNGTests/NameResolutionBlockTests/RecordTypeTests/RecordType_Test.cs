using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.NameResolutionBlockTests.RecordTypeTests
{
    public class RecordType_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { NameResolutionBlock.RecordType.End, 0x0000},
            new Object[] { NameResolutionBlock.RecordType.IPv4, 0x0001},
            new Object[] { NameResolutionBlock.RecordType.IPv6, 0x0002}
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void type_value(NameResolutionBlock.RecordType input, UInt16 expected)
        {
            input.Should().Be(expected);
        }
    }
}
