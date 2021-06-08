using System.Linq;
using FluentAssertions;
using Networking.Files.PcapNG;
using Networking.Model.DataLink;
using Xunit;
using Xunit.Abstractions;

namespace Networking.Files.Tests.PcapNGTests.PcapNGPacketReaderTests
{
    public class PcapNGPacketReader_Test : BaseTest
    {
        public PcapNGPacketReader_Test(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        [Fact]
        public void ReadBlocks()
        {
            var pcapNGPacketReader = this.GetPcapNGPacketReader("1-shb.11-idb.64-epb.1-nrb.11-isb.pcapng");

            var blocks = pcapNGPacketReader.ReadBlocks().ToList();
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
            enhancedPacketBlock.InterfaceDescription.Should().BeSameAs(interfaceDescriptionBlock);
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
            interfaceStatisticsBlock.InterfaceDescription.Should().BeSameAs(interfaceDescriptionBlock);
            interfaceStatisticsBlock.Should().NotBeAssignableTo<IPacket>();
            interfaceStatisticsBlock.IsPacket.Should().Be(false);
            interfaceStatisticsBlock.TotalLength.Should().Be(0x6c);
            interfaceStatisticsBlock.InterfaceId.Should().Be(0);

            foreach (var block in blocks)
            {
                block.SectionHeader.Should().BeSameAs(sectionHeaderBlock);
                if (block.Type == BlockType.InterfaceStatistics)
                {
                    var interfaceStatistics = (InterfaceStatisticsBlock)block;
                    TestOutput.NewLine($"{interfaceStatistics.InterfaceId} {interfaceStatistics.TimestampNanosecond.ToDateTimeOffsetString()}");
                }
                if (block.IsPacket == false)
                {
                    continue;
                }

                var packet = block as IPacket;
                TestOutput.NewLine($"{packet.DataLinkType} {packet.TimestampNanosecond.ToDateTimeOffsetString()}");
                if (packet.DataLinkType != PacketDataLinkType.Ethernet)
                {
                    continue;
                }
                var ethernetFrame = new EthernetFrame
                {
                    Bytes = packet.Payload
                };

                TestOutput.NewLine();
                TestOutput.Display(ethernetFrame);
            }
        }
    }
}
