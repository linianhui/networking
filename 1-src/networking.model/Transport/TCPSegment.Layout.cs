using System;

namespace Networking.Model.Transport
{
    public partial class TCPSegment
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://en.wikipedia.org/wiki/transmission_control_protocol"/>
        /// <para></para>
        /// <para>|                          TCP Segment                          |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para> 
        /// <para>|     Source Port (2 octets)    |  Destination Port (2 octets)  |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|                Sequence number (4 octets)                     |</para> 
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Acknowledgment number (if ACK set)                  |</para> 
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>| data  |     |N|C|E|U|A|P|R|S|F|                               |</para>
        /// <para>|offset |     |S|W|C|R|C|S|S|Y|I|   Windows Size (2 octets)     |</para>
        /// <para>|(4 bit)|     | |R|E|G|K|H|T|N|N|                               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|    Checksum                   |  Urgent pointer (if URG set)  |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>| Options (if data offset > 5)                                  |</para>
        /// <para>| Padded at the end with "0" bytes if necessary.)               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>fixed = 2+2+4+4+2+2+2+2 = 20 octets                              </para>
        /// <para></para>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// 源端口-起始位置=0
            /// </summary>
            public static readonly Int32 SourcePortBegin = 0;

            /// <summary>
            /// 源端口-结束位置=2
            /// </summary>
            public static readonly Int32 SourcePortEnd = SourcePortBegin + 2;

            /// <summary>
            /// 目标端口-起始位置=2
            /// </summary>
            public static readonly Int32 DestinationPortBegin = SourcePortEnd;

            /// <summary>
            /// 目标端口-结束位置=4
            /// </summary>
            public static readonly Int32 DestinationPortEnd = DestinationPortBegin + 2;

            /// <summary>
            /// 序列号-起始位置=4
            /// </summary>
            public static readonly Int32 SYNNumberBegin = DestinationPortEnd;

            /// <summary>
            /// 序列号-结束位置=8
            /// </summary>
            public static readonly Int32 SYNNumberEnd = SYNNumberBegin + 4;

            /// <summary>
            /// ACKNumber-起始位置=8
            /// </summary>
            public static readonly Int32 ACKNumberBegin = SYNNumberEnd;

            /// <summary>
            /// ACKNumber-结束位置=12
            /// </summary>
            public static readonly Int32 ACKNumberEnd = ACKNumberBegin + 4;

            /// <summary>
            /// 首部长度-起始位置=12
            /// </summary>
            public static readonly Int32 HeaderLengthBegin = ACKNumberEnd;

            /// <summary>
            /// 首部长度-起始位置=13
            /// </summary>
            public static readonly Int32 HeaderLengthEnd = HeaderLengthBegin + 1;

            /// <summary>
            /// 标志位-起始位置=13
            /// </summary>
            public static readonly Int32 FlagsBegin = HeaderLengthEnd;

            /// <summary>
            /// 标志位-起始位置=14
            /// </summary>
            public static readonly Int32 FlagsEnd = FlagsBegin + 1;

            /// <summary>
            /// 窗口大小-起始位置=14
            /// </summary>
            public static readonly Int32 WindowsSizeBegin = FlagsEnd;

            /// <summary>
            /// 窗口大小-结束位置=16
            /// </summary>
            public static readonly Int32 WindowsSizeEnd = WindowsSizeBegin + 2;

            /// <summary>
            /// 校验和-起始位置=16
            /// </summary>
            public static readonly Int32 ChecksumBegin = WindowsSizeEnd;

            /// <summary>
            /// 校验和-结束位置=18
            /// </summary>
            public static readonly Int32 ChecksumEnd = ChecksumBegin + 2;

            /// <summary>
            /// 紧急指针-起始位置=18
            /// </summary>
            public static readonly Int32 UrgentPointerBegin = ChecksumEnd;

            /// <summary>
            /// 紧急指针-结束位置=20
            /// </summary>
            public static readonly Int32 UrgentPointerEnd = UrgentPointerBegin + 2;
        }
    }
}
