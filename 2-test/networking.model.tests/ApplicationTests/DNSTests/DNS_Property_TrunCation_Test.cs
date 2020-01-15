using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DNSTests
{
    public class DNS_Property_TrunCation_Test
    {
        [Fact]
        public void Get()
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };
            dns.SetByte(2, 0b_0000_0010);

            dns.TrunCation.Should().Be(true);
        }

        [Fact]
        public void Set()
        {
            var dns = new DNS
            {
                Bytes = new Byte[32]
            };

            dns.TrunCation = true;
            dns.GetByte(2).Should().Be(0b_0000_0010);

            dns.TrunCation = false;
            dns.GetByte(2).Should().Be(0b_0000_0000);
        }
    }
}
