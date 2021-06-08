using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.IPAddressTests
{
    public class IPAddress_Property_Version_Test
    {
        [Fact]
        public void Get_IPv4()
        {
            var ipAddress = new IPAddress
            {
                Bytes = new Byte[4]
            };
            ipAddress.Version.Should().Be(IPVersion.IPv4);
        }

        [Fact]
        public void Get_IPv6()
        {
            var ipAddress = new IPAddress
            {
                Bytes = new Byte[16]
            };
            ipAddress.Version.Should().Be(IPVersion.IPv6);
        }

        [Fact]
        public void Get_NotSupport()
        {
            var ipAddress = new IPAddress
            {
                Bytes = new Byte[10]
            };

            Assert.Throws<NotSupportedException>(() => ipAddress.Version);
        }
    }
}
