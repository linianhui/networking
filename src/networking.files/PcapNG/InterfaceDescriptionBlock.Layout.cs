using System;

namespace Networking.Files.PcapNG
{
    public partial class InterfaceDescriptionBlock
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://pcapng.github.io/pcapng/#section_idb"/>
        /// <para></para>
        /// <para>|               Interface Description Block (IDB)               |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Block Type = 0x00000001                             |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Block Total Length (4 octets = 32 bits)             |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para> 
        /// <para>|           LinkType            |         Reserved              |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           SnapLen                                             |</para>
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
            /// LinkType-起始位置=0
            /// </summary>
            public const Int32 DataLinkTypeBegin = Block.Layout.HeaderLength;

            /// <summary>
            /// LinkType-结束位置=2
            /// </summary>
            public const Int32 DataLinkTypeEnd = DataLinkTypeBegin + 2;


            /// <summary>
            /// Captured Length-起始位置=4
            /// </summary>
            public const Int32 MaxCapturedLengthBegin = DataLinkTypeEnd + 2;

            /// <summary>
            /// Captured Length-结束位置=8
            /// </summary>
            public const Int32 MaxCapturedLengthEnd = MaxCapturedLengthBegin + 4;


            /// <summary>
            /// Header Length=12
            /// </summary>
            public const Int32 HeaderLength = MaxCapturedLengthEnd;
        }
    }
}
