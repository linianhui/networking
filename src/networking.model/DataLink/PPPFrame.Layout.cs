using System;

namespace Networking.Model.DataLink
{
    public partial class PPPFrame
    {
        /// <summary>
        /// <see cref="PPPFrame"/>的结构信息
        /// <see href="https://en.wikipedia.org/wiki/Point-to-Point_Protocol"/>
        /// <para></para>
        /// <para>|              PPP (Point to Point) Frame                       |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|        Type (2 octets)        |                               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+                               |</para>
        /// <para>|                                                               |</para>
        /// <para>|               Payload (46-1500 octets)                        |</para>
        /// <para>|                                                               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>fixed-header = 2 octets                                          </para>
        /// <para></para>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// 类型-起始位置=0
            /// </summary>
            public const Int32 TypeBegin = 0;

            /// <summary>
            /// 类型-结束位置=2
            /// </summary>
            public const Int32 TypeEnd = TypeBegin + 2;


            /// <summary>
            /// 首部信息-长度=2
            /// </summary>
            public const Int32 HeaderLength = TypeEnd;
        }
    }
}
