using System;
using FluentAssertions;
using Networking.Model.Application;
using Networking.Model.DataLink;
using Networking.Model.Internet;
using Networking.Model.Transport;
using Xunit;
using Xunit.Abstractions;

namespace Networking.Model.Tests.ApplicationTests.CoAPTests
{
    public class CoAP_Test : BaseTest
    {
        public CoAP_Test(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        [Fact]
        public void coap_post()
        {
            var coap = new CoAP
            {
                Bytes = new Byte[]
                {
                    0b_0100_0100, 0b_0000_0010, 0x0c, 0x3c,
                    0xd1, 0x97, 0x96, 0xc1,
                    0xc1, 0x3c, 0xff, 0x00
                }
            };

            coap.Version.Should().Be(1);
            coap.Type.Should().Be(CoAPType.Confirmable);
            coap.TokenLength.Should().Be(4);
            coap.Code.Should().Be(CoAPCode.POST);
            coap.CodeC.Should().Be(0);
            coap.CodeDD.Should().Be(2);
            coap.MessageId.Should().Be(0x0c3c);
            coap.Token.ToString().Should().Be("D1-97-96-C1");
        }

        [Fact]
        public void coap()
        {
            this.GetPcapPacketReader("coap.pcap").ForEach(bytes =>
            {
                var ethernetFrame = new EthernetFrame { Bytes = bytes };

                var ipv4 = (IPv4Packet)ethernetFrame.Payload;
                var udp = (UDPDatagram)ipv4.Payload;
                var udpPayload = udp.Payload;

                udpPayload.GetType().Should().Be(typeof(CoAP));
                TestOutput.NewLine();
                TestOutput.Display(ethernetFrame);
            });
        }
    }
}
