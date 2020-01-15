using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DNSTests
{
    public class DNS_Property_TransactionId_Test
    {
        [Fact]
        public void Get()
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };
            dns.SetByte(0, 0x12);
            dns.SetByte(1, 0x34);

            dns.TransactionId.Should().Be(0x1234);
        }

        [Fact]
        public void Set()
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };

            dns.TransactionId = 0x5678;

            dns.TransactionId.Should().Be(0x5678);
            dns.GetByte(0).Should().Be(0x56);
            dns.GetByte(1).Should().Be(0x78);
        }
    }
}
