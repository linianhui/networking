using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DNSTests
{
    public class DNS_Property_OperationCode_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { 0b_0_0000_000, DNSOperationCode.StandardQuery },
            new Object[] { 0b_0_0001_000, DNSOperationCode.InverseQuery },
            new Object[] { 0b_0_0010_000, DNSOperationCode.ServerStatusRequest }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte input, DNSOperationCode expected)
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };

            dns.SetByte(2, input);

            dns.OperationCode.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte expected, DNSOperationCode input)
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };

            dns.OperationCode = input;
            dns.GetByte(2).Should().Be(expected);
            dns.OperationCode.Should().Be(input);
        }
    }
}
