using System;

namespace Networking.Files.PcapNG
{
    public partial class SectionHeaderBlock
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://pcapng.github.io/pcapng/#section_shb"/>
        /// <para></para>
        /// <para>|                  Section Header Block (SHB)                   |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Block Type = 0x0A0D0D0A                             |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Block Total Length (4 octets = 32 bits)             |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Byte-Order Magic (4 octets = 32 bits)               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Major Version       |         Minor Version         |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Section Length (4 octets = 32 bits)                 |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Options (variable)                                  |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Block Total Length (4 octets = 32 bits) Copy        |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para> 
        /// <para></para>
        /// </summary>
        public new class Layout
        {
            /// <summary>
            /// Byte-Order Magic-起始位置=8
            /// </summary>
            public const Int32 MagicNumberBegin = Block.Layout.HeaderLength;

            /// <summary>
            /// Byte-Order Magic-长度=4
            /// </summary>
            public const Int32 MagicNumberLength = 4;

            /// <summary>
            /// Byte-Order Magic-结束位置=12
            /// </summary>
            public const Int32 MagicNumberEnd = MagicNumberBegin + MagicNumberLength;


            /// <summary>
            /// Major Version-起始位置=12
            /// </summary>
            public const Int32 MajorVersionBegin = MagicNumberEnd;

            /// <summary>
            /// Major Version-结束位置=14
            /// </summary>
            public const Int32 MajorVersionEnd = MajorVersionBegin + 2;


            /// <summary>
            /// Minor Version-起始位置=14
            /// </summary>
            public const Int32 MinorVersionBegin = MajorVersionEnd;

            /// <summary>
            /// Minor Version-结束位置=16
            /// </summary>
            public const Int32 MinorVersionEnd = MinorVersionBegin + 2;


            /// <summary>
            /// Section Length-起始位置=16
            /// </summary>
            public const Int32 SectionLengthBegin = MinorVersionEnd;

            /// <summary>
            /// Section Length-结束位置=20
            /// </summary>
            public const Int32 SectionLengthEnd = SectionLengthBegin + 4;


            /// <summary>
            /// Header Length=20
            /// </summary>
            public const Int32 HeaderLength = SectionLengthEnd;
        }
    }
}
