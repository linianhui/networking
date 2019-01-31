using System;

namespace Networking.Model.Transport
{

    /*
     |                          TCP Segment                          |
     |- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|
     |0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -| 
     |     Source Port (2 octets)    |  Destination Port (2 octets)  |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |                Sequence number (4 octets)                     | 
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |           Acknowledgment number (if ACK set)                  | 
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |offset |    todo               |   Windows Size (2 octets)     |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |    Checksum                   |  Urgent pointer (if URG set)  |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     | Options (if data offset > 5)                                  |
     | Padded at the end with "0" bytes if necessary.)               |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|

     fixed = 2+2+4+4+2+2+2+2 = 20 octets
     */

    public partial class TCPSegment
    {
        /// <summary>
        /// 首部-布局信息
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
            public static readonly Int32 SequenceBegin = DestinationPortEnd;

            /// <summary>
            /// 序列号-结束位置=8
            /// </summary>
            public static readonly Int32 SequenceEnd = SequenceBegin + 4;

            /// <summary>
            /// ACK-起始位置=8
            /// </summary>
            public static readonly Int32 ACKBegin = SequenceEnd;

            /// <summary>
            /// ACK-结束位置=12
            /// </summary>
            public static readonly Int32 ACKEnd = ACKBegin + 4;

            /// <summary>
            /// 首部长度-起始位置=12
            /// </summary>
            public static readonly Int32 HeaderLengthBegin = ACKEnd;

            /// <summary>
            /// 窗口大小-起始位置=14
            /// </summary>
            public static readonly Int32 WindowsSizeBegin = 14;

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
