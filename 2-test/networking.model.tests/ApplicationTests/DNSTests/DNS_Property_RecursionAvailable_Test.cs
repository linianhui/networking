using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DNSTests
{
    public class DNS_Property_RecursionAvailable_Test
    {
        [Fact]
        public void Get()
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };
            dns.SetByte(3, 0b_1000_0000);

            dns.RecursionAvailable.Should().Be(true);
        }

        [Fact]
        public void Set()
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };

            dns.RecursionAvailable = true;
            dns.GetByte(3).Should().Be(0b_1000_0000);

            dns.RecursionAvailable = false;
            dns.GetByte(3).Should().Be(0b_0000_0000);
        }
    }
}
