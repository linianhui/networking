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
            var sectionHeaderBody = (SectionHeaderBody)blocks[0].Body;
            sectionHeaderBody.MagicNumber.Should().Be(0x1A2B3C4DU);
            sectionHeaderBody.MajorVersion.Should().Be(1);
            sectionHeaderBody.MinorVersion.Should().Be(0);
            sectionHeaderBody.SectionLength.Should().Be(4294967295u);

            blocks[1].Header.IsLittleEndian.Should().Be(true);
            blocks[1].Header.Type.Should().Be(BlockType.InterfaceDescription);
            blocks[1].Header.TotalLength.Should().Be(32);
            blocks[1].Header.BodyLength.Should().Be(20);
            var interfaceDescriptionBody = (InterfaceDescriptionBody)blocks[1].Body;
            interfaceDescriptionBody.DataLinkType.Should().Be(PacketDataLinkType.Ethernet);
            interfaceDescriptionBody.MaxCapturedLength.Should().Be(0xFFFFu);
        }
    }
}
