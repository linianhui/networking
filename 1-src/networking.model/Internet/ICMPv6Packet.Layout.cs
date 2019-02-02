using System;

namespace Networking.Model.Internet
{

    /*
     |                        ICMPv6 Packet                          |
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

    public partial class ICMPv6Packet
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://tools.ietf.org/html/rfc4443"/>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// 类型-起始位置=0
            /// </summary>
            public static readonly Int32 TypeBegin = 0;

            /// <summary>
            /// 类型-结束位置=1
            /// </summary>
            public static readonly Int32 TypeEnd = TypeBegin + 1;

             /// <summary>
            /// 编号-起始位置=1
            /// </summary>
            public static readonly Int32 CodeBegin = TypeEnd;

            /// <summary>
            /// 编号-结束位置=2
            /// </summary>
            public static readonly Int32 CodeEnd = CodeBegin + 1;

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
            public static readonly Int32 ChecksumBegin = CodeEnd;

            /// <summary>
            /// 校验和-结束位置=4
            /// </summary>
            public static readonly Int32 ChecksumEnd = ChecksumBegin + 2;

            /// <summary>
            /// Id-起始位置=4
            /// </summary>
            public static readonly Int32 IdBegin = ChecksumEnd;

            /// <summary>
            /// Id-结束位置=6
            /// </summary>
            public static readonly Int32 IdEnd = IdBegin + 2;

            /// <summary>
            /// 序列号-起始位置=6
            /// </summary>
            public static readonly Int32 SequenceBegin = IdEnd;

            /// <summary>
            /// 序列号-结束位置=8
            /// </summary>
            public static readonly Int32 SequenceEnd = SequenceBegin + 2;
        }
    }
}
