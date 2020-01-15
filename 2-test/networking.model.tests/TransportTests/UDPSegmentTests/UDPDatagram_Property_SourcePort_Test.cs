using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.UDPDatagramTests
{
    public class UDPDatagram_Property_SourcePort_Test
    {
        [Fact]
        public void Get()
        {
            var udpDatagram = new UDPDatagram
            {
                Bytes = new Byte[32]
            };

            udpDatagram.SetBytes(0, 2, new Byte[] { 0x00, 0x50 });

            udpDatagram.SourcePort.Should().Be(80);
        }

        [Fact]
        public void Set()
        {
            var udpDatagram = new UDPDatagram
            {
                Bytes = new Byte[32]
            };

            udpDatagram.SourcePort = 80;

            udpDatagram.SourcePort.Should().Be(80);
        }
    }
}
