using System;

namespace Networking.Files.Pcap
{
    /// <summary>
    /// Packet (Record)
    /// <see href="https://wiki.wireshark.org/Development/LibpcapFileFormat"/>
    /// </summary>
    public class Packet
    {
        /// <summary>
        /// 文件首部
        /// </summary>
        public PcapFileHeader FileHeader { get; }

        /// <summary>
        /// Packet首部
        /// </summary>
        public PacketHeader Header { get; }

        /// <summary>
        /// Packet数据部分
        /// </summary>
        public Byte[] Data { get; }


        /// <summary>
        /// 构造函数
        /// </summary>
        public Packet(PcapFileHeader fileHeader, PacketHeader header, Byte[] data)
        {
            FileHeader = fileHeader;
            Header = header;
            Data = data;
        }
    }
}
