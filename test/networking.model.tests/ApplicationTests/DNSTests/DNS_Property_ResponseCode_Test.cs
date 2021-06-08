using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DNSTests
{
    public class DNS_Property_ResponseCode_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { 0b_0000_0000, DNSResponseCode.NoError },
            new Object[] { 0b_0000_0001, DNSResponseCode.FormatError },
            new Object[] { 0b_0000_0010, DNSResponseCode.ServerFailure },
            new Object[] { 0b_0000_0011, DNSResponseCode.NameError },
            new Object[] { 0b_0000_0100, DNSResponseCode.NotImplemented },
            new Object[] { 0b_0000_0101, DNSResponseCode.Refused }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte input, DNSResponseCode expected)
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };

            dns.SetByte(3, input);

            dns.ResponseCode.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte expected, DNSResponseCode input)
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };

            dns.ResponseCode = input;
            dns.GetByte(3).Should().Be(expected);
            dns.ResponseCode.Should().Be(input);
        }
    }
}
