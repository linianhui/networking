using System;

namespace Networking.Model.DataLink
{
    public partial class PPPoEFrame
    {
        /// <summary>
        /// <see cref="PPPoEFrame"/>的首部-布局信息
        /// <see href="https://en.wikipedia.org/wiki/Point-to-Point_Protocol_over_Ethernet"/>
        /// <see href="https://tools.ietf.org/html/rfc2516"/>
        /// <para></para>
        /// <para>|        PPPoE (Point to Point over Ethernet) Frame             |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|Version| Type  |   Code        |       Session Id              |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|  Payload Length               |                               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+                               |</para>
        /// <para>|                                                               |</para>
        /// <para>|               Payload (46-1500 octets)                        |</para>
        /// <para>|                                                               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>fixed-header = 1+1+2+2 = 6 octets                                </para>
        /// <para></para>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// 版本-起始位置=0
            /// </summary>
            public const Int32 VersionBegin = 0;

            /// <summary>
            /// 版本-结束位置=1
            /// </summary>
            public const Int32 VersionEnd = VersionBegin + 1;

            /// <summary>
            /// 版本-bit索引=0
            /// </summary>
            public const Int32 VersionBitIndex = 0;

            /// <summary>
            /// 版本-bit长度=4
            /// </summary>
            public const Int32 VersionBitLength = 4;


            /// <summary>
            /// 类型-起始位置=0
            /// </summary>
            public const Int32 TypeBegin = 0;

            /// <summary>
            /// 类型-结束位置=1
            /// </summary>
            public const Int32 TypeEnd = TypeBegin + 1;

            /// <summary>
            /// 版本-bit索引=4
            /// </summary>
            public const Int32 TypeBitIndex = 4;

            /// <summary>
            /// 版本-bit长度=4
            /// </summary>
            public const Int32 TypeBitLength = 4;


            /// <summary>
            /// 编号-起始位置=1
            /// </summary>
            public const Int32 CodeBegin = TypeEnd;

            /// <summary>
            /// 编号-结束位置=2
            /// </summary>
            public const Int32 CodeEnd = CodeBegin + 1;


            /// <summary>
            /// 会话Id-起始位置=2
            /// </summary>
            public const Int32 SessionIdBegin = CodeEnd;

            /// <summary>
            /// 会话Id-结束位置=4
            /// </summary>
            public const Int32 SessionIdEnd = SessionIdBegin + 2;


            /// <summary>
            /// 负载长度-起始位置=4
            /// </summary>
            public const Int32 PayloadLengthBegin = SessionIdEnd;

            /// <summary>
            /// 负载长度-结束位置=6
            /// </summary>
            public const Int32 PayloadLengthEnd = PayloadLengthBegin + 2;


            /// <summary>
            /// 首部信息-长度=6
            /// </summary>
            public const Int32 HeaderLength = PayloadLengthEnd;
        }
    }
}
