using System;
using Networking.Model;

namespace Networking.Utils.Pcap
{
    /// <summary>
    /// *.pcap 文件首部
    /// <see href="https://wiki.wireshark.org/development/libpcapfileformat"/>
    /// </summary>
    public partial class PcapFileHeader : Octets
    {
        /// <summary>
        /// Magic Number
        /// </summary>
        public UInt32 MagicNumber
        {
            get
            {
                return ReadUInt32(Layout.MagicNumberBegin, Endian.Little);
            }
        }

        /// <summary>
        /// Major Version
        /// </summary>
        public UInt16 VersionMajor
        {
            get
            {
                return ReadUInt16(Layout.VersionMajorBegin, Endian.Little);
            }
        }

        /// <summary>
        /// Minor Version
        /// </summary>
        public UInt16 VersionMinor
        {
            get
            {
                return ReadUInt16(Layout.VersionMinorBegin, Endian.Little);
            }
        }

        /// <summary>
        /// 数据包最大长度
        /// </summary>
        public UInt32 PacketMaxLength
        {
            get
            {
                return ReadUInt16(Layout.PacketMaxLengthBegin, Endian.Little);
            }
        }

        /// <summary>
        /// 数据链路类型
        /// </summary>
        public DataLinkType Type
        {
            get
            {
                return (DataLinkType)ReadUInt32(Layout.DataLinkTypeBegin, Endian.Little);
            }
        }
    }
}
