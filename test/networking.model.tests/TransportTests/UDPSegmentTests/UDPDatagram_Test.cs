using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.UDPDatagramTests
{
    public class UDPDatagram_Test
    {
        [Fact]
        public void DHCP()
        {
            var udpDatagram = new UDPDatagram
            {
                Bytes = new Byte[]
                {
                    0x00, 0x44,
                    0x00, 0x43,
                    0x02, 0x2c,
                    0x00, 0x00
                }
            };

            udpDatagram.SourcePort.Should().Be(68);
            udpDatagram.DestinationPort.Should().Be(67);
            udpDatagram.TotalLength.Should().Be(556);
            udpDatagram.Checksum.Should().Be(0);
        }
    }
}
