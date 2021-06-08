using System;

namespace Networking.Model.Internet
{
    public partial class ICMPv6Packet
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://tools.ietf.org/html/rfc4443"/>
        /// <para></para>
        /// <para>|                        ICMPv6 Packet                          |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para> 
        /// <para>|    Type       |      Code     |        Checksum               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Rest of Header (based on type and code)             |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|                                                               |</para>
        /// <para>|                   Datas                                       |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para></para>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// 类型-起始位置=0
            /// </summary>
            public const Int32 TypeBegin = 0;

            /// <summary>
            /// 类型-结束位置=1
            /// </summary>
            public const Int32 TypeEnd = TypeBegin + 1;


            /// <summary>
            /// 编号-起始位置=1
            /// </summary>
            public const Int32 CodeBegin = TypeEnd;

            /// <summary>
            /// 编号-结束位置=2
            /// </summary>
            public const Int32 CodeEnd = CodeBegin + 1;


            /// <summary>
            /// 类型编号-起始位置=0
            /// </summary>
            public const Int32 TypeCodeBegin = 0;

            /// <summary>
            /// 类型编号-结束位置=2
            /// </summary>
            public const Int32 TypeCodeEnd = 2;


            /// <summary>
            /// 校验和-起始位置=2
            /// </summary>
            public const Int32 ChecksumBegin = CodeEnd;

            /// <summary>
            /// 校验和-结束位置=4
            /// </summary>
            public const Int32 ChecksumEnd = ChecksumBegin + 2;


            /// <summary>
            /// Id-起始位置=4
            /// </summary>
            public const Int32 IdBegin = ChecksumEnd;

            /// <summary>
            /// Id-结束位置=6
            /// </summary>
            public const Int32 IdEnd = IdBegin + 2;


            /// <summary>
            /// 序列号-起始位置=6
            /// </summary>
            public const Int32 SequenceBegin = IdEnd;

            /// <summary>
            /// 序列号-结束位置=8
            /// </summary>
            public const Int32 SequenceEnd = SequenceBegin + 2;
        }
    }
}
