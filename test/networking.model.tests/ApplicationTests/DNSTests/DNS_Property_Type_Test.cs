using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DNSTests
{
    public class DNS_Property_Type_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { 0b_0000_0000, DNSType.Query },
            new Object[] { 0b_1000_0000, DNSType.Response }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte input, DNSType expected)
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };

            dns.SetByte(2, input);

            dns.Type.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte expected, DNSType input)
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };

            dns.Type = input;
            dns.GetByte(2).Should().Be(expected);
            dns.Type.Should().Be(input);
        }
    }
}
