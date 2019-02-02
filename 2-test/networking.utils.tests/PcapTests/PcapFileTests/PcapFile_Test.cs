using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Networking.Utils.Pcap;
using Xunit;

namespace Networking.Utils.Tests.PcapTests.PcapFileTests
{
    public class PcapFile_Test
    {
        [Fact]
        public void read()
        {
            PcapFile pcapFile = new PcapFile(AppContext.BaseDirectory + @"PcapTests\PcapFileTests\test.pcap");

            pcapFile.Header.MagicNumber.Should().Be(0xA1B2C3D4);
            pcapFile.Header.VersionMajor.Should().Be(2);
            pcapFile.Header.VersionMinor.Should().Be(4);
            pcapFile.Header.PacketMaxLength.Should().Be(65535);
            pcapFile.Header.Type.Should().Be(DataLinkType.Ethernet);

            Packet packet = null;
            Int32 i = 0;
            do
            {
                packet = pcapFile.ReadNextPacket();
                if (packet != null)
                {
                    EthernetFrame ethernetFrame = new EthernetFrame
                    {
                        Bytes = packet.Data
                    };
                    ethernetFrame.Length.Should().BeGreaterThan(0);
                    i++;
                }
            }
            while (packet != null);

            i.Should().Be(27);
        }
    }
}
