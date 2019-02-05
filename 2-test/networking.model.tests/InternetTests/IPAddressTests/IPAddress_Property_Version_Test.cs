using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPAddressTests
{
    public class IPAddress_Property_Version_Test
    {
        [Fact]
        public void Get_IPv4()
        {
            var ipAddress = new IPAddress(new Byte[4]);
            ipAddress.Version.Should().Be(IPVersion.IPv4);
        }

        [Fact]
        public void Get_IPv6()
        {
            var ipAddress = new IPAddress(new Byte[16]);
            ipAddress.Version.Should().Be(IPVersion.IPv6);
        }

        [Fact]
        public void Get_NotSupport()
        {
            var ipAddress = new IPAddress(new Byte[10]);

            Assert.Throws<NotSupportedException>(() => ipAddress.Version);
        }
    }
}
