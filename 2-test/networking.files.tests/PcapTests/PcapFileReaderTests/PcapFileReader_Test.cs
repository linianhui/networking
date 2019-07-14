using System;
using FluentAssertions;
using Networking.Files.Pcap;
using Networking.Model.DataLink;
using Xunit;
using Xunit.Abstractions;

namespace Networking.Files.Tests.PcapTests.PcapFileReaderTests
{
    public class PcapFileReader_Test : BaseTest
    {
        public PcapFileReader_Test(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        [Fact]
        public void ReadPackets()
        {
            var pcapFileReader = this.GetPcapFileReader("pcap.pcap");

            pcapFileReader.Header.IsLittleEndian.Should().Be(true);
            pcapFileReader.Header.MagicNumber.Should().Be(0xA1B2C3D4);
            pcapFileReader.Header.MajorVersion.Should().Be(2);
            pcapFileReader.Header.MinorVersion.Should().Be(4);
            pcapFileReader.Header.MaxCapturedLength.Should().Be(65535);
            pcapFileReader.Header.DataLinkType.Should().Be(PacketDataLinkType.Ethernet);

            var i = 0;
            foreach (PcapPacket packet in pcapFileReader.ReadPackets())
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
