using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.UDPDatagramTests
{
    public class UDPDatagram_Property_Checksum_Test
    {
        [Fact]
        public void Get()
        {
            var udpDatagram = new UDPDatagram
            {
                Bytes = new Byte[32]
            };

            udpDatagram.SetBytes(6, 2, new Byte[] { 0x12, 0x34 });

            udpDatagram.Checksum.Should().Be(4660);
        }

        [Fact]
        public void Set()
        {
            var udpDatagram = new UDPDatagram
            {
                Bytes = new Byte[32]
            };

            udpDatagram.Checksum = 3232;

            udpDatagram.Checksum.Should().Be(3232);
        }
    }
}
