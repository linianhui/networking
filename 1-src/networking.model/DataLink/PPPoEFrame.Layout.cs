using System;

namespace Networking.Model.DataLink
{
    /*
     |        PPPoE (Point to Point over Ethernet) Frame             |
     |- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|
     |0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |Version| Type  |   Code        |       Session Id              |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |  Payload Length               |                               |
     |- - - - - - - -+- - - - - - - -+                               |
     |                                                               |
     |               Payload (46-1500 octets)                        |
     |                                                               |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|

     fixed-header = 1+1+2+2 = 6 octets
     */

    public partial class PPPoEFrame
    {
        /// <summary>
        /// <see cref="PPPoEFrame"/>的首部-布局信息
        /// <see href="https://en.wikipedia.org/wiki/point-to-point_protocol_over_ethernet"/>
        /// <see href="https://tools.ietf.org/html/rfc2516"/>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// 版本-起始位置=0
            /// </summary>
            public static readonly Int32 VersionBegin = 0;

            /// <summary>
            /// 版本-结束位置=1
            /// </summary>
            public static readonly Int32 VersionEnd = VersionBegin + 1;

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
            /// 会话Id-起始位置=2
            /// </summary>
            public static readonly Int32 SessionIdBegin = CodeEnd;

            /// <summary>
            /// 会话Id-结束位置=4
            /// </summary>
            public static readonly Int32 SessionIdEnd = SessionIdBegin + 2;

            /// <summary>
            /// 负载长度-起始位置=4
            /// </summary>
            public static readonly Int32 PayloadLengthBegin = SessionIdEnd;

            /// <summary>
            /// 负载长度-结束位置=6
            /// </summary>
            public static readonly Int32  PayloadLengthEnd = PayloadLengthBegin + 2;

            /// <summary>
            /// 首部信息-长度=6
            /// </summary>
            public static readonly Int32 HeaderLength =  PayloadLengthEnd;
        }
    }
}
