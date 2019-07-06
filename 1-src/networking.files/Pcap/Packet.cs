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
        /// 文件首部
        /// </summary>
        public PcapFileHeader FileHeader { get; }

        /// <summary>
        /// Packet首部
        /// </summary>
        public PacketHeader Header { get; }

        /// <summary>
        /// 数据包
        /// </summary>
        public Memory<Byte> Data { get; }

        /// <summary>
        /// 链路层类型
        /// </summary>
        public DataLinkType Type
        {
            get { return FileHeader.Type; }
        }

        /// <summary>
        /// UNIX时间戳-纳秒
        /// </summary>
        public UInt64 TimestampNanosecond
        {
            get
            {
                UInt64 nanosecond = Header.TimestampMicrosecond;
                if (FileHeader.IsNanosecond==false)
                {
                    nanosecond *= 1000;
                }

                return Header.TimestampSecond * 1_000_000_000UL + nanosecond;
            }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        public Packet(PcapFileHeader fileHeader, PacketHeader header, Memory<Byte> data)
        {
            FileHeader = fileHeader;
            Header = header;
            Data = data;
        }
    }
}
