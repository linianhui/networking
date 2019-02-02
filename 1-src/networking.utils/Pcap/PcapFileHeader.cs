using System;
using Networking.Model;

namespace Networking.Utils.Pcap
{
    /// <summary>
    /// *.pcap 文件首部
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
                return ReadAsUInt32FromLittleEndian(Layout.MagicNumberBegin);
            }
        }

        /// <summary>
        /// Major Version
        /// </summary>
        public UInt16 VersionMajor
        {
            get
            {
                return ReadAsUInt16FromLittleEndian(Layout.VersionMajorBegin);
            }
        }

        /// <summary>
        /// Minor Version
        /// </summary>
        public UInt16 VersionMinor
        {
            get
            {
                return ReadAsUInt16FromLittleEndian(Layout.VersionMinorBegin);
            }
        }

        /// <summary>
        /// 数据包最大长度
        /// </summary>
        public UInt32 PacketMaxLength
        {
            get
            {
                return ReadAsUInt16FromLittleEndian(Layout.PacketMaxLengthBegin);
            }
        }

        /// <summary>
        /// 数据链路类型
        /// </summary>
        public DataLinkType Type
        {
            get
            {
                return (DataLinkType)ReadAsUInt32FromLittleEndian(Layout.DataLinkTypeBegin);
            }
        }
    }
}
