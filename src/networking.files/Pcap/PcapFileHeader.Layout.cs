using System;

namespace Networking.Files.Pcap
{
    public partial class PcapFileHeader
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://wiki.wireshark.org/Development/LibpcapFileFormat"/>
        /// <para></para>
        /// <para>typedef struct pcap_hdr_s {                                               </para>
        /// <para>    guint32 magic_number;   // magic number                               </para>
        /// <para>    guint16 version_major;  // major version number                       </para>
        /// <para>    guint16 version_minor;  // minor version number                       </para>
        /// <para>    gint32  thiszone;       // GMT to local correction                    </para>
        /// <para>    guint32 sigfigs;        // accuracy of timestamps                     </para>
        /// <para>    guint32 snaplen;        // max length of captured packets, in octets  </para>
        /// <para>    guint32 network;        // data link type                             </para>
        /// <para>} pcap_hdr_t;                                                             </para>
        /// <para></para>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// Major Number-起始位置
            /// </summary>
            public const Int32 MagicNumberBegin = 0;

            /// <summary>
            /// Major Number-结束位置
            /// </summary>
            public const Int32 MagicNumberEnd = MagicNumberBegin + 4;


            /// <summary>
            /// Major Version-起始位置
            /// </summary>
            public const Int32 MajorVersionBegin = MagicNumberEnd;

            /// <summary>
            /// Major Version-结束位置
            /// </summary>
            public const Int32 MajorVersionEnd = MajorVersionBegin + 2;


            /// <summary>
            /// Minor Version-起始位置
            /// </summary>
            public const Int32 MinorVersionBegin = MajorVersionEnd;

            /// <summary>
            /// Minor Version-结束位置
            /// </summary>
            public const Int32 MinorVersionEnd = MinorVersionBegin + 2;


            /// <summary>
            /// 数据包最大的长度-起始位置
            /// </summary>
            public const Int32 MaxCapturedLengthBegin = MinorVersionEnd + 8;


            /// <summary>
            /// 数据包最大的长度-结束位置
            /// </summary>
            public const Int32 MaxCapturedLengthEnd = MaxCapturedLengthBegin + 4;

            /// <summary>
            /// 数据链路类型-起始位置
            /// </summary>
            public const Int32 DataLinkTypeBegin = MaxCapturedLengthEnd;


            /// <summary>
            /// 数据链路类型-结束位置
            /// </summary>
            public const Int32 DataLinkTypeEnd = DataLinkTypeBegin + 4;


            /// <summary>
            /// 首部长度
            /// </summary>
            public const Int32 HeaderLength = DataLinkTypeEnd;
        }
    }
}
