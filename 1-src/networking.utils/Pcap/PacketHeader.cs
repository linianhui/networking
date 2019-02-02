using System;
using Networking.Model;

namespace Networking.Utils.Pcap
{
    /// <summary>
    /// Packet (Record) 首部
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
                return ReadAsUInt32FromLittleEndian(Layout.TimestampSecondsBegin);
            }
        }

        /// <summary>
        /// 时间戳-毫秒
        /// </summary>
        public UInt32 TimestampMicroseconds
        {
            get
            {
                return ReadAsUInt32FromLittleEndian(Layout.TimestampMicrosecondsBegin);
            }
        }

        /// <summary>
        /// 保存的长度
        /// </summary>
        public UInt32 SavedLength
        {
            get
            {
                return ReadAsUInt32FromLittleEndian(Layout.SavedLengthBegin);
            }
        }

        /// <summary>
        /// 原始长度
        /// </summary>
        public UInt32 OriginalLength
        {
            get
            {
                return ReadAsUInt32FromLittleEndian(Layout.OriginalLengthBegin);
            }
        }
    }
}
