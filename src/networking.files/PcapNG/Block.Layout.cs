using System;

namespace Networking.Files.PcapNG
{
    public partial class Block
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://pcapng.github.io/pcapng/#section_block"/>
        /// <para></para>
        /// <para>|                    General Block Structure                    |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para> 
        /// <para>|           Block Type (4 octets = 32 bits)                     |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Block Total Length (4 octets = 32 bits)             |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Block Body : variable length, padded to 32 bits     |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Block Total Length (4 octets = 32 bits) Copy        |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para> 
        /// <para></para>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// Type-起始位置
            /// </summary>
            public const Int32 TypeBegin = 0;

            /// <summary>
            /// Type-结束位置
            /// </summary>
            public const Int32 TypeEnd = TypeBegin + 4;


            /// <summary>
            /// Total Length-起始位置
            /// </summary>
            public const Int32 TotalLengthBegin = TypeEnd;

            /// <summary>
            /// Total Length的长度
            /// </summary>
            public const Int32 TotalLengthLength = 4;

            /// <summary>
            /// Total Length-结束位置
            /// </summary>
            public const Int32 TotalLengthEnd = TotalLengthBegin + TotalLengthLength;


            /// <summary>
            /// 头部长度
            /// </summary>
            public const Int32 HeaderLength = TotalLengthEnd;
        }
    }
}
