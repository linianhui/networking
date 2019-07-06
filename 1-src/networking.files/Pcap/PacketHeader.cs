using System;

namespace Networking.Files.Pcap
{
    /// <summary>
    /// Packet (Record) 首部
    /// <see href="https://wiki.wireshark.org/Development/LibpcapFileFormat"/>
    /// </summary>
    public partial class PacketHeader : Octets
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        public UInt32 TimestampSecond
        {
            get { return GetUInt32(Layout.TimestampSecondBegin); }
        }

        /// <summary>
        /// 时间戳的微妙部分
        /// </summary>
        public UInt32 TimestampMicrosecond
        {
            get { return GetUInt32(Layout.TimestampMicrosecondBegin); }
        }

        /// <summary>
        /// 捕获的长度
        /// </summary>
        public UInt32 CapturedLength
        {
            get { return GetUInt32(Layout.CapturedLengthBegin); }
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
