using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DNSTests
{
    public class DNS_Property_AdditionalRRsCount_Test
    {
        [Fact]
        public void Get()
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };
            dns.SetByte(10, 0x12);
            dns.SetByte(11, 0x34);

            dns.AdditionalRRsCount.Should().Be(0x1234);
        }

        [Fact]
        public void Set()
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };

            dns.AdditionalRRsCount = 0x5678;

            dns.AdditionalRRsCount.Should().Be(0x5678);
            dns.GetByte(10).Should().Be(0x56);
            dns.GetByte(11).Should().Be(0x78);
        }
    }
}
