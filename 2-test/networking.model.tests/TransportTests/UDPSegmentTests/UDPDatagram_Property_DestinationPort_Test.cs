using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.UDPDatagramTests
{
    public class UDPDatagram_Property_DestinationPort_Test
    {
        [Fact]
        public void Get()
        {
            var udpDatagram = new UDPDatagram
            {
                Bytes = new Byte[32]
            };

            udpDatagram.SetBytes(2, 2, new Byte[] { 0x00, 0x50 });

            udpDatagram.DestinationPort.Should().Be(80);
        }

        [Fact]
        public void Set()
        {
            var udpDatagram = new UDPDatagram
            {
                Bytes = new Byte[32]
            };

            udpDatagram.DestinationPort = 80;

            udpDatagram.DestinationPort.Should().Be(80);
        }
    }
}
