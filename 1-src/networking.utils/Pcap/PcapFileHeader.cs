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
        /// 字节序
        /// </summary>
        public Endian Endian
        {
            get
            {
                if (base[0] == 0xA1)
                {
                    return Endian.Big;
                }
                return Endian.Little;
            }
        }

        /// <summary>
        /// Magic Number
        /// </summary>
        public UInt32 MagicNumber
        {
            get
            {
                return ReadUInt32(Layout.MagicNumberBegin, Endian);
            }
        }

        /// <summary>
        /// Major Version
        /// </summary>
        public UInt16 VersionMajor
        {
            get
            {
                return ReadUInt16(Layout.VersionMajorBegin, Endian);
            }
        }

        /// <summary>
        /// Minor Version
        /// </summary>
        public UInt16 VersionMinor
        {
            get
            {
                return ReadUInt16(Layout.VersionMinorBegin, Endian);
            }
        }

        /// <summary>
        /// 数据包最大长度
        /// </summary>
        public UInt32 PacketMaxLength
        {
            get
            {
                return ReadUInt16(Layout.PacketMaxLengthBegin, Endian);
            }
        }

        /// <summary>
        /// 数据链路类型
        /// </summary>
        public DataLinkType Type
        {
            get
            {
                return (DataLinkType)ReadUInt32(Layout.DataLinkTypeBegin, Endian);
            }
        }
    }
}
