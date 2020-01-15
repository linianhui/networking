using FluentAssertions;
using Networking.Files.Pcap;
using Networking.Model.DataLink;
using Xunit;
using Xunit.Abstractions;

namespace Networking.Files.Tests.PcapTests.PcapPacketReaderTests
{
    public class PcapPacketReader_Test : BaseTest
    {
        public PcapPacketReader_Test(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        [Fact]
        public void ReadPackets()
        {
            var pcapPacketReader = this.GetPcapPacketReader("pcap.pcap");

            pcapPacketReader.Header.IsLittleEndian.Should().Be(true);
            pcapPacketReader.Header.MagicNumber.Should().Be(0xA1B2C3D4);
            pcapPacketReader.Header.MajorVersion.Should().Be(2);
            pcapPacketReader.Header.MinorVersion.Should().Be(4);
            pcapPacketReader.Header.MaxCapturedLength.Should().Be(65535);
            pcapPacketReader.Header.DataLinkType.Should().Be(PacketDataLinkType.Ethernet);

            var i = 0;
            foreach (PcapPacket packet in pcapPacketReader.ReadPackets())
            {
                TestOutput.NewLine($"{packet.DataLinkType} {packet.TimestampNanosecond.ToDateTimeOffsetString()}");
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
