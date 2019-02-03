using System;

namespace Networking.Model.Internet
{
    public partial class IPv6Packet
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://en.wikipedia.org/wiki/ipv6_packet"/>
        /// <para></para>
        /// <para>|                          IPv6 Packet                          |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para> 
        /// <para>|Version| Traffic Class |            Flow Label                 |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para> 
        /// <para>|      Payload Length           | Next Header   | Hop Limit     |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|                                                               |</para>
        /// <para>|                                                               |</para>
        /// <para>|           Source IP Address (16 octets)                       |</para>
        /// <para>|                                                               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|                                                               |</para> 
        /// <para>|                                                               |</para>
        /// <para>|           Destination IP Address (16 octets)                  |</para>
        /// <para>|                                                               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>fixed-header= 4+2+1+1+16+16 = 40                                 </para>
        /// <para></para>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// Version-起始位置=0
            /// </summary>
            public static readonly Int32 VersionBegin = 0;

            /// <summary>
            /// 负载长度-起始位置=4
            /// </summary>
            public static readonly Int32 PayloadLengthBegin = 4;

            /// <summary>
            /// 负载长度-结束位置=6
            /// </summary>
            public static readonly Int32 PayloadLengthEnd = PayloadLengthBegin + 2;

            /// <summary>
            /// 下一个首部-起始位置=6
            /// </summary>
            public static readonly Int32 NextHeaderBegin = PayloadLengthEnd;

            /// <summary>
            /// 下一个首部-结束位置=7
            /// </summary>
            public static readonly Int32 NextHeaderEnd = NextHeaderBegin + 1;

            /// <summary>
            /// 跳数限制-起始位置=7
            /// </summary>
            public static readonly Int32 HopLimitBegin = NextHeaderEnd;

            /// <summary>
            /// 跳数限制-结束位置=8
            /// </summary>
            public static readonly Int32 HopLimitEnd = HopLimitBegin + 1;

            /// <summary>
            /// 源IP-起始位置=8
            /// </summary>
            public static readonly Int32 SourceIPAddressBegin = HopLimitEnd;

            /// <summary>
            /// 源IP-结束位置=24
            /// </summary>
            public static readonly Int32 SourceIPAddressEnd = SourceIPAddressBegin + 16;

            /// <summary>
            /// 目标IP-起始位置=24
            /// </summary>
            public static readonly Int32 DestinationIPAddressBegin = SourceIPAddressEnd;

            /// <summary>
            /// 目标IP-结束位置=40
            /// </summary>
            public static readonly Int32 DestinationIPAddressEnd = DestinationIPAddressBegin + 16;

            /// <summary>
            /// 首部长度
            /// </summary>
            public static readonly Int32 HeaderLength = DestinationIPAddressEnd;
        }
    }
}
