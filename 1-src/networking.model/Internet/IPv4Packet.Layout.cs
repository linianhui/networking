using System;

namespace Networking.Model.Internet
{

    /*
     |                          IPv4 Packet                          |
     |- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|
     |0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -| 
     |Version|  IHL  |   DSCP    |ECN|     Total Length              |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -| 
     |      Identification           |Flags|    Fragment Offset      |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |      TTL      |    Type       |          Checksum             |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |           Source IP Address (4 octets)                        |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |           Destination IP Address (4 octets)                   |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |                                                               |
     |                                                               |
     |                   Options (if IHL > 5)                        |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|

     IHL = Internet Header Length
     DSCP= Differentiated Services Code Point
     ECN = Explicit Congestion Notification
     TTL = Time to Live
     fixed-header                = 4*5 = 20 octets
     fixed-header+options-header = 20 + ?
     */

    public partial class IPv4Packet
    {
        /// <summary>
        /// 布局信息
        /// <see href="https://en.wikipedia.org/wiki/ipv4#packet_structure"/>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// Version-起始位置=0
            /// </summary>
            public static readonly Int32 VersionBegin = 0;

            /// <summary>
            /// IHL-起始位置=0
            /// </summary>
            public static readonly Int32 HeaderLengthBegin = 0;

            /// <summary>
            /// 总长度-起始位置=2
            /// </summary>
            public static readonly Int32 TotalLengthBegin = 2;

            /// <summary>
            /// 总长度-结束位置=4
            /// </summary>
            public static readonly Int32 TotalLengthEnd = TotalLengthBegin + 2;

            /// <summary>
            /// Id-起始位置=4
            /// </summary>
            public static readonly Int32 IdBegin = TotalLengthEnd;

            /// <summary>
            /// Id-结束位置=6
            /// </summary>
            public static readonly Int32 IdEnd = IdBegin + 2;

            /// <summary>
            /// TTL-起始位置=8
            /// </summary>
            public static readonly Int32 TTLBegin = 8;

            /// <summary>
            /// TTL-结束位置=9
            /// </summary>
            public static readonly Int32 TTLEnd = TTLBegin + 1;

            /// <summary>
            /// 类型-起始位置=9
            /// </summary>
            public static readonly Int32 TypeBegin = TTLEnd;

            /// <summary>
            /// 类型-结束位置=10
            /// </summary>
            public static readonly Int32 TypeEnd = TypeBegin + 1;

            /// <summary>
            /// 头部校验和-起始位置=10
            /// </summary>
            public static readonly Int32 HeaderChecksumBegin = TypeEnd;

            /// <summary>
            /// 头部校验和-结束位置=12
            /// </summary>
            public static readonly Int32 HeaderChecksumEnd = HeaderChecksumBegin + 2;

            /// <summary>
            /// 源IP-起始位置=12
            /// </summary>
            public static readonly Int32 SourceIPAddressBegin = HeaderChecksumEnd;

            /// <summary>
            /// 源IP-结束位置=16
            /// </summary>
            public static readonly Int32 SourceIPAddressEnd = SourceIPAddressBegin + 4;

            /// <summary>
            /// 目标IP-起始位置=16
            /// </summary>
            public static readonly Int32 DestinationIPAddressBegin = SourceIPAddressEnd;

            /// <summary>
            /// 目标IP-结束位置=20
            /// </summary>
            public static readonly Int32 DestinationIPAddressEnd = DestinationIPAddressBegin + 4;
        }
    }
}
