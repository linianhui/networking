using System;
using FluentAssertions;
using Networking.Model.Application;
using Networking.Model.DataLink;
using Networking.Model.Internet;
using Networking.Model.Transport;
using Xunit;
using Xunit.Abstractions;

namespace Networking.Model.Tests.ApplicationTests.DNSTests
{
    public class DNS_Test
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public DNS_Test(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void dns_query()
        {
            var dns = new DNS
            {
                Bytes = new Byte[]
                {
                    0x10, 0x32,
                    0b_0_0000_0_0_1, 0b_0_000_0000,
                    0x00, 0x01,
                    0x00, 0x00,
                    0x00, 0x00,
                    0x00, 0x00,
                    0x06, 0x67, 0x6f, 0x6f, 0x67, 0x6c, 0x65, 0x03, 0x63, 0x6f, 0x6d, 0x00, 0x00, 0x10, 0x00, 0x01,
                }
            };

            dns.TransactionId.Should().Be(0x1032);
            dns.Type.Should().Be(DNSType.Query);
            dns.OperationCode.Should().Be(DNSOperationCode.StandardQuery);
            dns.AuthoritativeAnswer.Should().Be(false);
            dns.TrunCation.Should().Be(false);
            dns.RecursionDesired.Should().Be(true);
            dns.RecursionAvailable.Should().Be(false);
            dns.QueriesCount.Should().Be(1);
            dns.AnswersCount.Should().Be(0);
            dns.AuthorityRRsCount.Should().Be(0);
            dns.AdditionalRRsCount.Should().Be(0);
        }

        [Fact]
        public void dns()
        {
            this.PcapFileForEach("dns.pcap", bytes =>
            {
                var ethernetFrame = new EthernetFrame { Bytes = bytes };

                var ipv4 = (IPv4Packet)ethernetFrame.Payload;
                var udp = (UDPDatagram)ipv4.Payload;
                var udpPayload = udp.Payload;

                _testOutputHelper.WriteLine(
                    $"\r\n{ethernetFrame.SourceMACAddress} > {ethernetFrame.DestinationMACAddress} {ethernetFrame.Type}" +
                    $"\r\n{ipv4.SourceIPAddress} > {ipv4.DestinationIPAddress} {ipv4.Type}" +
                    $"\r\n{udp.SourcePort} > {udp.DestinationPort}"
                );

                udpPayload.GetType().Should().Be(typeof(DNS));
            });
        }
    }
}