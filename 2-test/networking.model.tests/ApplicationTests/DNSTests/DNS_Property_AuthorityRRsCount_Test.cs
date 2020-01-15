using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DNSTests
{
    public class DNS_Property_AuthorityRRsCount_Test
    {
        [Fact]
        public void Get()
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };
            dns.SetByte(8, 0x12);
            dns.SetByte(9, 0x34);

            dns.AuthorityRRsCount.Should().Be(0x1234);
        }

        [Fact]
        public void Set()
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };

            dns.AuthorityRRsCount = 0x5678;

            dns.AuthorityRRsCount.Should().Be(0x5678);
            dns.GetByte(8).Should().Be(0x56);
            dns.GetByte(9).Should().Be(0x78);
        }
    }
}
