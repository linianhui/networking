using System;

namespace Networking.Files.Pcap
{
    /// <summary>
    /// Packet (Record)
    /// <see href="https://wiki.wireshark.org/Development/LibpcapFileFormat"/>
    /// </summary>
    public class Packet : IPacket
    {
        /// <summary>
        /// Packet首部
        /// </summary>
        public PacketHeader Header { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Packet(PacketHeader header, Memory<Byte> payload)
        {
            Header = header;
            Data = payload;
        }

        /// <summary>
        /// 数据包
        /// </summary>
        public Memory<Byte> Data { get; }

        /// <summary>
        /// 链路层类型
        /// </summary>
        public DataLinkType Type
        {
            get { return Header.FileHeader.Type; }
        }

        /// <summary>
        /// UNIX时间戳-纳秒
        /// </summary>
        public UInt64 TimestampNanosecond
        {
            get { return Header.TimestampNanosecond; }
        }
    }
}
