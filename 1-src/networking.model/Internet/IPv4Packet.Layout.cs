using System;

namespace Networking.Model.Internet
{
    public partial class IPv4Packet
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://en.wikipedia.org/wiki/ipv4#packet_structure"/>
        /// <para></para>
        /// <para>|                          IPv4 Packet                          |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para> 
        /// <para>|Version|  IHL  |   DSCP    |ECN|     Total Length              |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para> 
        /// <para>|      Identification           |Flags|    Fragment Offset      |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|      TTL      |    Type       |          Checksum             |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Source IP Address (4 octets)                        |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Destination IP Address (4 octets)                   |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|                                                               |</para>
        /// <para>|                                                               |</para>
        /// <para>|                   Options (if IHL > 5)                        |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>IHL = Internet Header Length                                     </para>
        /// <para>DSCP= Differentiated Services Code Point                         </para>
        /// <para>ECN = Explicit Congestion Notification                           </para>
        /// <para>TTL = Time to Live                                               </para>
        /// <para>fixed-header                = 4*5 = 20 octets                    </para>
        /// <para>fixed-header+options-header = 20 + ?                             </para>
        /// <para></para>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// Version-起始位置=0
            /// </summary>
            public const Int32 VersionBegin = 0;

            /// <summary>
            /// Version-结束位置=1
            /// </summary>
            public const Int32 VersionEnd = VersionBegin + 1;

            /// <summary>
            /// Version-bit索引=0
            /// </summary>
            public const Int32 VersionBitIndex = 0;

            /// <summary>
            /// Version-bit长度=4
            /// </summary>
            public const Int32 VersionBitLength = 4;



            /// <summary>
            /// IHL-起始位置=0
            /// </summary>
            public const Int32 HeaderLengthBegin = 0;

            /// <summary>
            /// IHL-结束位置=1
            /// </summary>
            public const Int32 HeaderLengthEnd = HeaderLengthBegin + 1;

            /// <summary>
            /// IHL-bit索引=4
            /// </summary>
            public const Int32 HeaderLengthBitIndex = 4;

            /// <summary>
            /// IHL-bit长度=4
            /// </summary>
            public const Int32 HeaderLengthBitLength = 4;


            /// <summary>
            /// DSCP-起始位置=1
            /// </summary>
            public const Int32 DSCPBegin = 1;

            /// <summary>
            /// DSCP-bit索引=0
            /// </summary>
            public const Int32 DSCPBitIndex = 0;

            /// <summary>
            /// DSCP-bit长度=6
            /// </summary>
            public const Int32 DSCPBitLength = 6;


            /// <summary>
            /// 总长度-起始位置=2
            /// </summary>
            public const Int32 TotalLengthBegin = 2;

            /// <summary>
            /// 总长度-结束位置=4
            /// </summary>
            public const Int32 TotalLengthEnd = TotalLengthBegin + 2;


            /// <summary>
            /// Id-起始位置=4
            /// </summary>
            public const Int32 IdBegin = TotalLengthEnd;

            /// <summary>
            /// Id-结束位置=6
            /// </summary>
            public const Int32 IdEnd = IdBegin + 2;


            /// <summary>
            /// TTL-起始位置=8
            /// </summary>
            public const Int32 TTLBegin = 8;

            /// <summary>
            /// TTL-结束位置=9
            /// </summary>
            public const Int32 TTLEnd = TTLBegin + 1;


            /// <summary>
            /// 类型-起始位置=9
            /// </summary>
            public const Int32 TypeBegin = TTLEnd;

            /// <summary>
            /// 类型-结束位置=10
            /// </summary>
            public const Int32 TypeEnd = TypeBegin + 1;


            /// <summary>
            /// 首部校验和-起始位置=10
            /// </summary>
            public const Int32 HeaderChecksumBegin = TypeEnd;

            /// <summary>
            /// 首部校验和-结束位置=12
            /// </summary>
            public const Int32 HeaderChecksumEnd = HeaderChecksumBegin + 2;


            /// <summary>
            /// 源IP-起始位置=12
            /// </summary>
            public const Int32 SourceIPAddressBegin = HeaderChecksumEnd;

            /// <summary>
            /// 源IP-结束位置=16
            /// </summary>
            public const Int32 SourceIPAddressEnd = SourceIPAddressBegin + IPAddress.Layout.V4Length;


            /// <summary>
            /// 目标IP-起始位置=16
            /// </summary>
            public const Int32 DestinationIPAddressBegin = SourceIPAddressEnd;

            /// <summary>
            /// 目标IP-结束位置=20
            /// </summary>
            public const Int32 DestinationIPAddressEnd = DestinationIPAddressBegin + IPAddress.Layout.V4Length;
        }
    }
}
