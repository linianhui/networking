using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Networking.Files.Pcap;
using Xunit;

namespace Networking.Files.Tests.PcapTests.PcapFileTests
{
    public class PcapFile_Test
    {
        [Fact]
        public void read()
        {
            var pcapFile = this.GetPcapFile("test.pcap");

            pcapFile.FileHeader.IsLittleEndian.Should().Be(true);
            pcapFile.FileHeader.MagicNumber.Should().Be(0xA1B2C3D4);
            pcapFile.FileHeader.MajorVersion.Should().Be(2);
            pcapFile.FileHeader.MinorVersion.Should().Be(4);
            pcapFile.FileHeader.MaxCapturedLength.Should().Be(65535);
            pcapFile.FileHeader.Type.Should().Be(DataLinkType.Ethernet);

            var i = 0;

            foreach (var packet in pcapFile.ReadAllPackets())
            {
                packet.Header.IsLittleEndian.Should().Be(true);
                packet.Header.FileHeader.IsLittleEndian.Should().Be(true);

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
