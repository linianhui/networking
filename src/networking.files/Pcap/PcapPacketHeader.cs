using System;

namespace Networking.Files.Pcap
{
    /// <summary>
    /// Packet (Record) 首部
    /// <see href="https://wiki.wireshark.org/Development/LibpcapFileFormat"/>
    /// </summary>
    public partial class PcapPacketHeader : Octets
    {
        private PcapFileHeader _header;

        /// <summary>
        /// 文件首部
        /// </summary>
        public PcapFileHeader Header
        {
            get { return _header; }
            set
            {
                _header = value;
                IsLittleEndian = value.IsLittleEndian;
            }
        }

        /// <summary>
        /// 时间戳-秒部分
        /// </summary>
        public UInt32 TimestampSecondPart
        {
            get { return GetUInt32(Layout.TimestampSecondPartBegin); }
        }

        /// <summary>
        /// 时间戳-微妙部分
        /// </summary>
        public UInt32 TimestampMicrosecondPart
        {
            get { return GetUInt32(Layout.TimestampMicrosecondPartBegin); }
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

        /// <summary>
        /// UNIX时间戳-精度纳秒
        /// </summary>
        public UInt64 TimestampNanosecond
        {
            get
            {
                UInt64 nanosecondPart = TimestampMicrosecondPart;
                if (Header.TimestampMicrosecondPartIsNanosecond == false)
                {
                    nanosecondPart *= 1000;
                }
                return TimestampSecondPart * 1_000_000_000UL + nanosecondPart;
            }
        }
    }
}
