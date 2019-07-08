using FluentAssertions;
using Networking.Files.Pcap;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Files.Tests.PcapTests.PcapFileReaderTests
{
    public class PcapFileReader_Test
    {
        [Fact]
        public void ReadPackets()
        {
            var pcapFileReader = this.GetPcapFileReader("test.pcap");

            pcapFileReader.Header.IsLittleEndian.Should().Be(true);
            pcapFileReader.Header.MagicNumber.Should().Be(0xA1B2C3D4);
            pcapFileReader.Header.MajorVersion.Should().Be(2);
            pcapFileReader.Header.MinorVersion.Should().Be(4);
            pcapFileReader.Header.MaxCapturedLength.Should().Be(65535);
            pcapFileReader.Header.Type.Should().Be(DataLinkType.Ethernet);

            var i = 0;

            foreach (PcapPacket packet in pcapFileReader.ReadPackets())
            {
                packet.Header.IsLittleEndian.Should().Be(true);
                packet.Header.Header.IsLittleEndian.Should().Be(true);

                if (i == 0)
                {
                    packet.TimestampNanosecond.Should().Be(1_549_110_206_807_127_000UL);
                }
                var ethernetFrame = new EthernetFrame
                {
                    Bytes = packet.Payload
                };
                ethernetFrame.IsLittleEndian.Should().Be(false);
                ethernetFrame.Length.Should().BeGreaterThan(0);
                i++;
            }

            i.Should().Be(27);
        }
    }
}
