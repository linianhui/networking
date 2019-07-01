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

            pcapFile.Header.IsLittleEndian.Should().Be(true);
            pcapFile.Header.MagicNumber.Should().Be(0xA1B2C3D4);
            pcapFile.Header.MajorVersion.Should().Be(2);
            pcapFile.Header.MinorVersion.Should().Be(4);
            pcapFile.Header.MaxCapturedLength.Should().Be(65535);
            pcapFile.Header.Type.Should().Be(DataLinkType.Ethernet);

            var i = 0;

            foreach (var packet in pcapFile.ReadAllPackets())
            {
                packet.FileHeader.IsLittleEndian.Should().Be(true);
                packet.Header.IsLittleEndian.Should().Be(true);
                var ethernetFrame = new EthernetFrame
                {
                    Bytes = packet.Data
                };
                ethernetFrame.IsLittleEndian.Should().Be(false);
                ethernetFrame.Length.Should().BeGreaterThan(0);
                i++;
            }

            i.Should().Be(27);
        }
    }
}
