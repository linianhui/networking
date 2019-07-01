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
        public UInt16 VersionMinor
        {
            get { return GetUInt16(Layout.VersionMinorBegin); }
        }

        /// <summary>
        /// 数据包最大长度
        /// </summary>
        public UInt32 PacketMaxLength
        {
            get { return GetUInt16(Layout.PacketMaxLengthBegin); }
        }

        /// <summary>
        /// 数据链路类型
        /// </summary>
        public DataLinkType Type
        {
            get { return (DataLinkType)GetUInt32(Layout.DataLinkTypeBegin); }
        }
    }
}
