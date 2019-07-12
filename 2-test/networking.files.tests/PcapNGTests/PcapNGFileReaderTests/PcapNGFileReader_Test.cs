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
            var pcapNgFileReader = this.GetPcapNGFileReader("1-shb.11-idb.64-epb.1-nrb.11-isb.pcapng");

            var blocks = pcapNgFileReader.ReadBlocks().ToList();
            blocks.Count.Should().Be(88);

            var sectionHeaderBlock = (SectionHeaderBlock)blocks[0];
            sectionHeaderBlock.Type.Should().Be(BlockType.SectionHeader);
            sectionHeaderBlock.IsLittleEndian.Should().Be(true);
            sectionHeaderBlock.TotalLength.Should().Be(140);
            sectionHeaderBlock.MagicNumber.Should().Be(0x1A2B3C4DU);
            sectionHeaderBlock.MajorVersion.Should().Be(1);
            sectionHeaderBlock.MinorVersion.Should().Be(0);
            sectionHeaderBlock.SectionLength.Should().Be(4294967295u);

            var interfaceDescriptionBlock = (InterfaceDescriptionBlock)blocks[1];
            interfaceDescriptionBlock.IsLittleEndian.Should().Be(true);
            interfaceDescriptionBlock.Type.Should().Be(BlockType.InterfaceDescription);
            interfaceDescriptionBlock.TotalLength.Should().Be(116);
            interfaceDescriptionBlock.DataLinkType.Should().Be(PacketDataLinkType.Ethernet);
            interfaceDescriptionBlock.MaxCapturedLength.Should().Be(262144u);

            var enhancedPacketBlock = (EnhancedPacketBlock)blocks[12];
            enhancedPacketBlock.IsLittleEndian.Should().Be(true);
            enhancedPacketBlock.Type.Should().Be(BlockType.EnhancedPacket);
            enhancedPacketBlock.TotalLength.Should().Be(212);
            enhancedPacketBlock.InterfaceId.Should().Be(0);
            enhancedPacketBlock.CapturedLength.Should().Be(178);
            enhancedPacketBlock.OriginalLength.Should().Be(178);

            var nameResolutionBlock = (NameResolutionBlock)blocks[76];
            nameResolutionBlock.Type.Should().Be(BlockType.NameResolution);
            nameResolutionBlock.IsLittleEndian.Should().Be(true);
            nameResolutionBlock.TotalLength.Should().Be(216);
            var nameResolutionBlockRecords = nameResolutionBlock.GetRecords().ToList();
            nameResolutionBlockRecords.Count.Should().Be(7);
            var nameResolutionBlockRecord = nameResolutionBlockRecords[0];
            nameResolutionBlockRecord.Type.Should().Be(NameResolutionBlock.RecordType.IPv4);
            nameResolutionBlockRecord.ValueLength.Should().Be(25);
            nameResolutionBlockRecord.IP.ToString().Should().Be("74.125.228.227");
            nameResolutionBlockRecord.Host.Should().Be("clients.l.google.com");

            var interfaceStatisticsBlock = (InterfaceStatisticsBlock)blocks[77];
            interfaceStatisticsBlock.Should().NotBeAssignableTo<IPacket>();
            interfaceStatisticsBlock.IsPacket.Should().Be(false);
            interfaceStatisticsBlock.TotalLength.Should().Be(0x6c);
            interfaceStatisticsBlock.InterfaceId.Should().Be(0);

            foreach (var block in blocks)
            {
                if (block.IsPacket == false)
                {
                    continue;
                }

                var packet = block as IPacket;
                var ethernetFrame = new EthernetFrame
                {
                    Bytes = packet.Payload
                };

                _testOutputHelper.WriteLine(
                    $"\r\n{ethernetFrame.SourceMACAddress} > {ethernetFrame.DestinationMACAddress} {ethernetFrame.Type}"
                );

                if (ethernetFrame.Type == EthernetFrameType.IPv4)
                {
                    var ipv4 = (IPv4Packet)ethernetFrame.Payload;
                    if (ipv4.Type == IPPacketType.UDP)
                    {
                        var udp = (UDPDatagram)ipv4.Payload;
                        _testOutputHelper.WriteLine(
                            $"\r\n{ethernetFrame.SourceMACAddress} > {ethernetFrame.DestinationMACAddress} {ethernetFrame.Type}" +
                            $"\r\n{ipv4.SourceIPAddress} > {ipv4.DestinationIPAddress} {ipv4.Type}" +
                            $"\r\n{udp.SourcePort} > {udp.DestinationPort}"
                        );
                    }

                    if (ipv4.Type == IPPacketType.TCP)
                    {
                        var tcp = (TCPSegment)ipv4.Payload;
                        _testOutputHelper.WriteLine(
                            $"\r\n{ethernetFrame.SourceMACAddress} > {ethernetFrame.DestinationMACAddress} {ethernetFrame.Type}" +
                            $"\r\n{ipv4.SourceIPAddress} > {ipv4.DestinationIPAddress} {ipv4.Type}" +
                            $"\r\n{tcp.SourcePort} > {tcp.DestinationPort}"
                        );
                    }
                }
            }
        }
    }
}
