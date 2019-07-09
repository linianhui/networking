using System.Linq;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.PcapNGFileReaderTests
{
    public class PcapNGFileReader_Test
    {
        [Fact]
        public void ReadBlocks()
        {
            var pcapNgFileReader = this.GetPcapNGFileReader("pcapng.pcapng");

            var blocks = pcapNgFileReader.ReadBlocks().ToList();
            blocks.Count.Should().Be(6);
            blocks[0].Header.Type.Should().Be(BlockType.SectionHeader);
            blocks[0].Header.IsLittleEndian.Should().Be(true);
            blocks[0].Header.TotalLength.Should().Be(28);
            blocks[0].Header.BodyLength.Should().Be(16);
            var sectionHeaderBlock = (SectionHeaderBlock)blocks[0].Body;
            sectionHeaderBlock.MagicNumber.Should().Be(0x1A2B3C4DU);
            sectionHeaderBlock.MajorVersion.Should().Be(1);
            sectionHeaderBlock.MinorVersion.Should().Be(0);
            sectionHeaderBlock.SectionLength.Should().Be(4294967295u);

            blocks[1].Header.IsLittleEndian.Should().Be(true);
            blocks[1].Header.Type.Should().Be(BlockType.InterfaceDescription);
            blocks[1].Header.TotalLength.Should().Be(32);
            blocks[1].Header.BodyLength.Should().Be(20);
            var interfaceDescriptionBlock = (InterfaceDescriptionBlock)blocks[1].Body;
            interfaceDescriptionBlock.DataLinkType.Should().Be(PacketDataLinkType.Ethernet);
            interfaceDescriptionBlock.MaxCapturedLength.Should().Be(0xFFFFu);
        }
    }
}
