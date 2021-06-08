using System;

namespace Networking.Files.PcapNG
{
    public partial class SimplePacketBlock
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://pcapng.github.io/pcapng/#section_spb"/>
        /// <para></para>
        /// <para>|                  Simple Packet Block (SPB)                    |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Block Type = 0x00000003                             |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Block Total Length (4 octets = 32 bits)             |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Original Packet Length                              |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Packet Data                                         |</para>
        /// <para>|                                                               |</para>
        /// <para>|                                                               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Block Total Length (4 octets = 32 bits) Copy        |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para> 
        /// <para></para>
        /// </summary>
        public new class Layout
        {
            /// <summary>
            /// Original Length-起始位置=8
            /// </summary>
            public const Int32 OriginalLengthBegin = Block.Layout.HeaderLength;

            /// <summary>
            /// Original Length-结束位置=12
            /// </summary>
            public const Int32 OriginalLengthEnd = OriginalLengthBegin + 4;


            /// <summary>
            /// Header Length=12
            /// </summary>
            public const Int32 HeaderLength = OriginalLengthEnd;

            /// <summary>
            /// Header Total Length=16
            /// </summary>
            public const Int32 HeaderTotalLength = HeaderLength + 4;
        }
    }
}
