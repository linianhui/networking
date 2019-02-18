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
            get { return GetUInt32(Layout.TimestampSecondsBegin); }
        }

        /// <summary>
        /// 时间戳的微妙部分
        /// </summary>
        public UInt32 TimestampMicroseconds
        {
            get { return GetUInt32(Layout.TimestampMicrosecondsBegin); }
        }

        /// <summary>
        /// 保存的长度
        /// </summary>
        public UInt32 SavedLength
        {
            get { return GetUInt32(Layout.SavedLengthBegin); }
        }

        /// <summary>
        /// 原始长度
        /// </summary>
        public UInt32 OriginalLength
        {
            get { return GetUInt32(Layout.OriginalLengthBegin); }
        }
    }
}
