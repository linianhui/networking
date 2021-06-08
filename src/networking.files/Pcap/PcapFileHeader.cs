using System;

namespace Networking.Files.Pcap
{
    /// <summary>
    /// *.pcap 文件首部
    /// <see href="https://wiki.wireshark.org/Development/LibpcapFileFormat"/>
    /// </summary>
    public partial class PcapFileHeader : Octets
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="headerBytes">首部Byte[]</param>
        public PcapFileHeader(Byte[] headerBytes)
        {
            Bytes = headerBytes;
            IsLittleEndian = base.GetByte(0) != 0xA1;
        }

        /// <summary>
        /// 数据链路类型
        /// </summary>
        public PacketDataLinkType DataLinkType
        {
            get { return (PacketDataLinkType)GetUInt32(Layout.DataLinkTypeBegin); }
        }

        /// <summary>
        /// Magic Number
        /// </summary>
        public UInt32 MagicNumber
        {
            get { return GetUInt32(Layout.MagicNumberBegin); }
        }

        /// <summary>
        /// Major Version
        /// </summary>
        public UInt16 MajorVersion
        {
            get { return GetUInt16(Layout.MajorVersionBegin); }
        }

        /// <summary>
        /// Minor Version
        /// </summary>
        public UInt16 MinorVersion
        {
            get { return GetUInt16(Layout.MinorVersionBegin); }
        }

        /// <summary>
        /// 数据包最大长度
        /// </summary>
        public UInt32 MaxCapturedLength
        {
            get { return GetUInt32(Layout.MaxCapturedLengthBegin); }
        }

        /// <summary>
        /// 是否是纳秒
        /// </summary>
        public Boolean TimestampMicrosecondPartIsNanosecond
        {
            get
            {
                if (IsLittleEndian)
                {
                    return base.GetByte(0) == 0x4D;
                }
                return base.GetByte(3) == 0x4D;
            }
        }
    }
}
