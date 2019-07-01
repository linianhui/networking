using System;

namespace Networking.Files.Pcap
{
    public partial class PacketHeader
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://wiki.wireshark.org/Development/LibpcapFileFormat"/>
        /// <para></para>
        /// <para>typedef struct pcaprec_hdr_s {                                     </para>
        /// <para>    guint32 ts_sec;   // timestamp seconds                         </para>
        /// <para>    guint32 ts_usec;  // timestamp microseconds                    </para>
        /// <para>    guint32 incl_len; // number of octets of packet saved in file  </para>
        /// <para>    guint32 orig_len; // actual length of packet                   </para>
        /// <para>} pcaprec_hdr_t;                                                   </para>
        /// <para></para>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// 时间戳-起始位置
            /// </summary>
            public const Int32 TimestampSecondsBegin = 0;

            /// <summary>
            /// 时间戳-结束位置
            /// </summary>
            public const Int32 TimestampSecondsEnd = TimestampSecondsBegin + 4;


            /// <summary>
            /// 时间戳-微妙-起始位置
            /// </summary>
            public const Int32 TimestampMicrosecondsBegin = TimestampSecondsEnd;

            /// <summary>
            /// 时间戳-微妙-结束位置
            /// </summary>
            public const Int32 TimestampMicrosecondsEnd = TimestampMicrosecondsBegin + 4;


            /// <summary>
            /// 保存的长度-起始位置
            /// </summary>
            public const Int32 CapturedLengthBegin = TimestampMicrosecondsEnd;

            /// <summary>
            /// 保存的长度-结束位置
            /// </summary>
            public const Int32 CapturedLengthEnd = CapturedLengthBegin + 4;


            /// <summary>
            /// 原始长度-起始位置
            /// </summary>
            public const Int32 OriginalLengthBegin = CapturedLengthEnd;

            /// <summary>
            /// 原始长度-结束位置
            /// </summary>
            public const Int32 OriginalLengthEnd = OriginalLengthBegin + 4;


            /// <summary>
            /// 首部长度
            /// </summary>
            public const Int32 HeaderLength = OriginalLengthEnd;
        }
    }
}
