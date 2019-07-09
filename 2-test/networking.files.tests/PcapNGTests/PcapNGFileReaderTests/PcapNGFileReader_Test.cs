using System.Linq;
using FluentAssertions;
using Networking.Files.PcapNG;
using Networking.Model.Application;
using Networking.Model.DataLink;
using Networking.Model.Internet;
using Networking.Model.Transport;
using Xunit;
using Xunit.Abstractions;

namespace Networking.Files.Tests.PcapNGTests.PcapNGFileReaderTests
{
    public class PcapNGFileReader_Test
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public PcapNGFileReader_Test(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ReadBlocks()
        {
            var pcapNgFileReader = this.GetPcapNGFileReader("pcapng.pcapng");

            var blocks = pcapNgFileReader.ReadBlocks().ToList();
            blocks.Count.Should().Be(6);

            var sectionHeaderBlock = (SectionHeaderBlock)blocks[0];
            sectionHeaderBlock.Type.Should().Be(BlockType.SectionHeader);
            sectionHeaderBlock.IsLittleEndian.Should().Be(true);
            sectionHeaderBlock.TotalLength.Should().Be(28);
            sectionHeaderBlock.MagicNumber.Should().Be(0x1A2B3C4DU);
            sectionHeaderBlock.MajorVersion.Should().Be(1);
            sectionHeaderBlock.MinorVersion.Should().Be(0);
            sectionHeaderBlock.SectionLength.Should().Be(4294967295u);

            var interfaceDescriptionBlock = (InterfaceDescriptionBlock)blocks[1];
            interfaceDescriptionBlock.IsLittleEndian.Should().Be(true);
            interfaceDescriptionBlock.Type.Should().Be(BlockType.InterfaceDescription);
            interfaceDescriptionBlock.TotalLength.Should().Be(32);
            interfaceDescriptionBlock.DataLinkType.Should().Be(PacketDataLinkType.Ethernet);
            interfaceDescriptionBlock.MaxCapturedLength.Should().Be(0xFFFFu);

            var enhancedPacketBlock = (EnhancedPacketBlock)blocks[2];
            enhancedPacketBlock.IsLittleEndian.Should().Be(true);
            enhancedPacketBlock.Type.Should().Be(BlockType.EnhancedPacket);
            enhancedPacketBlock.TotalLength.Should().Be(348);
            enhancedPacketBlock.InterfaceId.Should().Be(0);
            enhancedPacketBlock.CapturedLength.Should().Be(314);
            enhancedPacketBlock.OriginalLength.Should().Be(314);


            foreach (var block in blocks)
            {
                if (block.IsPacket == false)
                {
                    continue;
                }

                var packet = block as IPacket;
                var ethernetFrame = new EthernetFrame { Bytes = packet.Payload };

                var ipv4 = (IPv4Packet)ethernetFrame.Payload;
                var udp = (UDPDatagram)ipv4.Payload;
                var udpPayload = udp.Payload;

                _testOutputHelper.WriteLine(
                    $"\r\n{ethernetFrame.SourceMACAddress} > {ethernetFrame.DestinationMACAddress} {ethernetFrame.Type}" +
                    $"\r\n{ipv4.SourceIPAddress} > {ipv4.DestinationIPAddress} {ipv4.Type}" +
                    $"\r\n{udp.SourcePort} > {udp.DestinationPort}"
                );

                udpPayload.GetType().Should().Be(typeof(DHCP));
            }
        }
    }
}
