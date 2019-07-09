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
        }
    }
}
