using System;
using System.Collections.Generic;
using System.IO;

namespace Networking.Files.Pcap
{
    /// <summary>
    /// *.pcap文件
    /// <see href="https://wiki.wireshark.org/Development/LibpcapFileFormat"/>
    /// <see href="https://wiki.wireshark.org/SampleCaptures"/>
    /// </summary>
    public class PcapPacketReader : PacketReader
    {
        /// <summary>
        /// 魔数
        /// </summary>
        public static readonly ISet<UInt32> MagicNumbers = new HashSet<UInt32>
        {
           0xA1_B2_C3_D4,
           0xD4_C3_B2_A1,
           0xA1_B2_3C_4D,
           0x4D_3C_B2_A1
        };

        /// <summary>
        /// 文件首部
        /// </summary>
        public PcapFileHeader Header { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        internal PcapPacketReader(Stream stream) : base(stream)
        {
            ReadFileHeader();
        }

        /// <summary>
        /// 读取所有数据包
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<IPacket> ReadPackets()
        {
            var packet = ReadPacket();
            while (packet != null)
            {
                yield return packet;
                packet = ReadPacket();
            }
        }

        private void ReadFileHeader()
        {
            var headerBytes = base.ReadBytes(PcapFileHeader.Layout.HeaderLength);
            Header = new PcapFileHeader(headerBytes);
        }

        private PcapPacket ReadPacket()
        {
            var packetHeader = ReadPacketHeader();
            if (packetHeader == null)
            {
                return null;
            }

            var packetPayloadBytes = ReadPacketPayload(packetHeader);
            if (packetPayloadBytes.Length == 0)
            {
                return null;
            }

            return new PcapPacket(packetHeader, packetPayloadBytes);
        }

        private PcapPacketHeader ReadPacketHeader()
        {
            var packetHeaderBytes = base.ReadBytes(PcapPacketHeader.Layout.HeaderLength);
            if (packetHeaderBytes.Length == 0)
            {
                return null;
            }

            return new PcapPacketHeader
            {
                Header = Header,
                Bytes = packetHeaderBytes
            };
        }

        private Byte[] ReadPacketPayload(PcapPacketHeader packetHeader)
        {
            var packetPayloadLength = (Int32)packetHeader.CapturedLength;
            return base.ReadBytes(packetPayloadLength);
        }
    }
}
