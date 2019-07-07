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
        /// 是否是纳秒
        /// </summary>
        public Boolean IsNanosecond { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="headerBytes">首部Byte[]</param>
        public PcapFileHeader(Byte[] headerBytes)
        {
            Bytes = headerBytes;
            IsLittleEndian = base.GetByte(0) != 0xA1;
            if (IsLittleEndian)
            {
                IsNanosecond = base.GetByte(0) == 0x4D;
            }
            IsNanosecond = base.GetByte(3) == 0x4D;
            MagicNumber = GetUInt32(Layout.MagicNumberBegin);
            MajorVersion = GetUInt16(Layout.MajorVersionBegin);
            MinorVersion = GetUInt16(Layout.MinorVersionBegin);
            MaxCapturedLength = GetUInt32(Layout.MaxCapturedLengthBegin);
            Type = (DataLinkType)GetUInt32(Layout.DataLinkTypeBegin);
        }

        /// <summary>
        /// Magic Number
        /// </summary>
        public UInt32 MagicNumber { get; }

        /// <summary>
        /// Major Version
        /// </summary>
        public UInt16 MajorVersion { get; }

        /// <summary>
        /// Minor Version
        /// </summary>
        public UInt16 MinorVersion { get; }

        /// <summary>
        /// 数据包最大长度
        /// </summary>
        public UInt32 MaxCapturedLength { get; }

        /// <summary>
        /// 数据链路类型
        /// </summary>
        public DataLinkType Type { get; }
    }
}
