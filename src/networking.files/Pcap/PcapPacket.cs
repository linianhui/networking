using System;

namespace Networking.Files.Pcap
{
    /// <summary>
    /// Packet (Record)
    /// <see href="https://wiki.wireshark.org/Development/LibpcapFileFormat"/>
    /// </summary>
    public class PcapPacket : IPacket
    {
        /// <summary>
        /// Packet首部
        /// </summary>
        public PcapPacketHeader Header { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PcapPacket(PcapPacketHeader header, Memory<Byte> payload)
        {
            Header = header;
            Payload = payload;
        }

        /// <summary>
        /// 链路层类型
        /// </summary>
        public PacketDataLinkType DataLinkType
        {
            get { return Header.Header.DataLinkType; }
        }

        /// <summary>
        /// 有效负载
        /// </summary>
        public Memory<Byte> Payload { get; }

        /// <summary>
        /// UNIX时间戳-纳秒
        /// </summary>
        public UInt64 TimestampNanosecond
        {
            get { return Header.TimestampNanosecond; }
        }
    }
}
