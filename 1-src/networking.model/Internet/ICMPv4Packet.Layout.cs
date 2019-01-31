using System;

namespace Networking.Model.Internet
{

    /*
     |                        ICMPv4 Packet                          |
     |- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|
     |0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -| 
     |    Type       |      Code     |        Checksum               |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |           Rest of Header (based on type and code)             |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |                                                               |
     |                   Datas                                       |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     */

    public partial class ICMPv4Packet
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://en.wikipedia.org/wiki/internet_control_message_protocol#datagram_structure"/>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// 类型编号-起始位置=0
            /// </summary>
            public static readonly Int32 TypeCodeBegin = 0;

            /// <summary>
            /// 类型编号-结束位置=2
            /// </summary>
            public static readonly Int32 TypeCodeEnd = 2;

            /// <summary>
            /// 校验和-起始位置=2
            /// </summary>
            public static readonly Int32 ChecksumBegin = TypeCodeEnd;

            /// <summary>
            /// 校验和-结束位置=4
            /// </summary>
            public static readonly Int32 ChecksumEnd = ChecksumBegin + 2;
        }
    }
}
