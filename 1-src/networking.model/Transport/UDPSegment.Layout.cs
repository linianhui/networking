using System;

namespace Networking.Model.Transport
{

    /*
     |                          UDP Segment                          |
     |- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|
     |0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -| 
     |     Source Port (2 octets)    |  Destination Port (2 octets)  |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -| 
     | Total Length (header+payload) |      Checksum  (2 octets)     |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |                                                               |
     |                                                               |
     |                   Payload (Length octets)                     |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|

     fixed = 2+2+2+2 = 8 octets
     */

    public partial class UDPSegment
    {
        /// <summary>
        /// 布局信息
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
            /// 总长度-起始位置=4
            /// </summary>
            public static readonly Int32 TotalLengthBegin = DestinationPortEnd;

            /// <summary>
            /// 总长度-结束位置=6
            /// </summary>
            public static readonly Int32 TotalLengthEnd = TotalLengthBegin + 2;

            /// <summary>
            /// 校验和-起始位置=6
            /// </summary>
            public static readonly Int32 ChecksumBegin = TotalLengthEnd;

            /// <summary>
            /// 校验和-结束位置=8
            /// </summary>
            public static readonly Int32 ChecksumEnd = ChecksumBegin + 2;

            /// <summary>
            /// 首部长度
            /// </summary>
            public static readonly Int32 HeaderLength = ChecksumEnd;
        }
    }
}
