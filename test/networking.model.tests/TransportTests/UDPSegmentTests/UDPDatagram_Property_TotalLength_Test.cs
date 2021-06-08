using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.UDPDatagramTests
{
    public class UDPDatagram_Property_TotalLength_Test
    {
        [Fact]
        public void Get()
        {
            var udpDatagram = new UDPDatagram
            {
                Bytes = new Byte[32]
            };

            udpDatagram.SetBytes(4, 2, new Byte[] { 0x00, 0x20 });

            udpDatagram.TotalLength.Should().Be(32);
        }

        [Fact]
        public void Set()
        {
            var udpDatagram = new UDPDatagram
            {
                Bytes = new Byte[32]
            };

            udpDatagram.TotalLength = 32;

            udpDatagram.TotalLength.Should().Be(32);
        }
    }
}
