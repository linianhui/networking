using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DNSTests
{
    public class DNS_Property_RecursionDesired_Test
    {
        [Fact]
        public void Get()
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };
            dns.SetByte(2, 0b_0000_0001);

            dns.RecursionDesired.Should().Be(true);
        }

        [Fact]
        public void Set()
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };

            dns.RecursionDesired = true;
            dns.GetByte(2).Should().Be(0b_0000_0001);

            dns.RecursionDesired = false;
            dns.GetByte(2).Should().Be(0b_0000_0000);
        }
    }
}
