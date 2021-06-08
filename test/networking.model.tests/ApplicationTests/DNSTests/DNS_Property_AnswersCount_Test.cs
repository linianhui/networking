using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DNSTests
{
    public class DNS_Property_AnswersCount_Test
    {
        [Fact]
        public void Get()
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };
            dns.SetByte(6, 0x12);
            dns.SetByte(7, 0x34);

            dns.AnswersCount.Should().Be(0x1234);
        }

        [Fact]
        public void Set()
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };

            dns.AnswersCount = 0x5678;

            dns.AnswersCount.Should().Be(0x5678);
            dns.GetByte(6).Should().Be(0x56);
            dns.GetByte(7).Should().Be(0x78);
        }
    }
}
