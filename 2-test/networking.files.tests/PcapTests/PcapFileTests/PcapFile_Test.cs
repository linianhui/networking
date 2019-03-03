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
            var pcapFile = new PcapFile(AppContext.BaseDirectory + "PcapTests/PcapFileTests/test.pcap");

            pcapFile.Header.IsLittleEndian.Should().Be(true);
            pcapFile.Header.MagicNumber.Should().Be(0xA1B2C3D4);
            pcapFile.Header.VersionMajor.Should().Be(2);
            pcapFile.Header.VersionMinor.Should().Be(4);
            pcapFile.Header.PacketMaxLength.Should().Be(65535);
            pcapFile.Header.Type.Should().Be(DataLinkType.Ethernet);

            Packet packet = null;
            var i = 0;
            do
            {
                packet = pcapFile.ReadNextPacket();
                if (packet != null)
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
            }
            while (packet != null);

            i.Should().Be(27);
        }
    }
}
