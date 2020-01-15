using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DNSTests
{
    public class DNS_Property_QueriesCount_Test
    {
        [Fact]
        public void Get()
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };
            dns.SetByte(4, 0x12);
            dns.SetByte(5, 0x34);

            dns.QueriesCount.Should().Be(0x1234);
        }

        [Fact]
        public void Set()
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };

            dns.QueriesCount = 0x5678;

            dns.QueriesCount.Should().Be(0x5678);
            dns.GetByte(4).Should().Be(0x56);
            dns.GetByte(5).Should().Be(0x78);
        }
    }
}
