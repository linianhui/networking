using System;

namespace Networking.Utils.Pcap
{
    public partial class PcapFileHeader
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://wiki.wireshark.org/development/libpcapfileformat"/>
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
            public static readonly Int32 MagicNumberBegin = 0;

            /// <summary>
            /// Major Number-结束位置
            /// </summary>
            public static readonly Int32 MagicNumberEnd = MagicNumberBegin + 4;


            /// <summary>
            /// Major Version-起始位置
            /// </summary>
            public static readonly Int32 VersionMajorBegin = MagicNumberEnd;

            /// <summary>
            /// Major Version-结束位置
            /// </summary>
            public static readonly Int32 VersionMajorEnd = VersionMajorBegin + 2;


            /// <summary>
            /// Minor Version-起始位置
            /// </summary>
            public static readonly Int32 VersionMinorBegin = VersionMajorEnd;

            /// <summary>
            /// Minor Version-结束位置
            /// </summary>
            public static readonly Int32 VersionMinorEnd = VersionMinorBegin + 2;


            /// <summary>
            /// 数据包最大的长度-起始位置
            /// </summary>
            public static readonly Int32 PacketMaxLengthBegin = VersionMinorEnd + 8;


            /// <summary>
            /// 数据包最大的长度-结束位置
            /// </summary>
            public static readonly Int32 PacketMaxLengthEnd = PacketMaxLengthBegin + 4;

            /// <summary>
            /// 数据链路类型-起始位置
            /// </summary>
            public static readonly Int32 DataLinkTypeBegin = PacketMaxLengthEnd;


            /// <summary>
            /// 数据链路类型-结束位置
            /// </summary>
            public static readonly Int32 DataLinkTypeEnd = DataLinkTypeBegin + 4;


            /// <summary>
            /// 首部长度
            /// </summary>
            public static readonly Int32 HeaderLength = DataLinkTypeEnd;
        }
    }
}