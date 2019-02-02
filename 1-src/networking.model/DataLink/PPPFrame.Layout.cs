using System;

namespace Networking.Model.DataLink
{
    /*
     |              PPP (Point to Point) Frame                       |
     |- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|
     |0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |        Type (2 octets)        |                               |
     |- - - - - - - -+- - - - - - - -+                               |
     |                                                               |
     |               Payload (46-1500 octets)                        |
     |                                                               |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     
     fixed-header = 2 octets
     */

    public partial class PPPFrame
    {
        /// <summary>
        /// <see cref="PPPFrame"/>的结构信息
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// 类型-起始位置=0
            /// </summary>
            public static readonly Int32 TypeBegin = 0;

            /// <summary>
            /// 类型-结束位置=2
            /// </summary>
            public static readonly Int32 TypeEnd = TypeBegin + 2;

            /// <summary>
            /// 首部信息-长度=2
            /// </summary>
            public static readonly Int32 HeaderLength = TypeEnd;
        }
    }
}
