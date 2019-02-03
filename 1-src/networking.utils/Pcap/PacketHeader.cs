using System;
using Networking.Model;

namespace Networking.Utils.Pcap
{
    /// <summary>
    /// Packet (Record) 首部
    /// <see href="https://wiki.wireshark.org/development/libpcapfileformat"/>
    /// </summary>
    public partial class PacketHeader : Octets
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        public UInt32 TimestampSeconds
        {
            get
            {
                return ReadUInt32(Layout.TimestampSecondsBegin, Endian.Little);
            }
        }

        /// <summary>
        /// 时间戳的微妙部分
        /// </summary>
        public UInt32 TimestampMicroseconds
        {
            get
            {
                return ReadUInt32(Layout.TimestampMicrosecondsBegin, Endian.Little);
            }
        }

        /// <summary>
        /// 保存的长度
        /// </summary>
        public UInt32 SavedLength
        {
            get
            {
                return ReadUInt32(Layout.SavedLengthBegin, Endian.Little);
            }
        }

        /// <summary>
        /// 原始长度
        /// </summary>
        public UInt32 OriginalLength
        {
            get
            {
                return ReadUInt32(Layout.OriginalLengthBegin, Endian.Little);
            }
        }
    }
}
