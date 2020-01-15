using System;

namespace Networking.Files.PcapNG
{
    public partial class EnhancedPacketBlock
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://pcapng.github.io/pcapng/#section_epb"/>
        /// <para></para>
        /// <para>|                  Enhanced Packet Block (EPB)                  |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Block Type = 0x00000006                             |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Block Total Length (4 octets = 32 bits)             |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Interface ID                                        |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Timestamp (High)                                    |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Timestamp (Low)                                     |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Captured Packet Length                              |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Original Packet Length                              |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Packet Data                                         |</para>
        /// <para>|                                                               |</para>
        /// <para>|                                                               |</para>
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
            /// Interface ID-起始位置=8
            /// </summary>
            public const Int32 InterfaceIdBegin = Block.Layout.HeaderLength;

            /// <summary>
            /// Interface ID-结束位置=12
            /// </summary>
            public const Int32 InterfaceIdEnd = InterfaceIdBegin + 4;


            /// <summary>
            /// Timestamp (High)-起始位置=12
            /// </summary>
            public const Int32 TimestampHighBegin = InterfaceIdEnd;

            /// <summary>
            /// Timestamp (High)-结束位置=16
            /// </summary>
            public const Int32 TimestampHighEnd = TimestampHighBegin + 4;


            /// <summary>
            /// Timestamp (Low)-起始位置=16
            /// </summary>
            public const Int32 TimestampLowBegin = TimestampHighEnd;

            /// <summary>
            /// Timestamp (Low)-结束位置=20
            /// </summary>
            public const Int32 TimestampLowEnd = TimestampLowBegin + 4;


            /// <summary>
            /// Captured Length-起始位置=20
            /// </summary>
            public const Int32 CapturedLengthBegin = TimestampLowEnd;

            /// <summary>
            /// Captured Length-结束位置=24
            /// </summary>
            public const Int32 CapturedLengthEnd = CapturedLengthBegin + 4;


            /// <summary>
            /// Original Length-起始位置=24
            /// </summary>
            public const Int32 OriginalLengthBegin = CapturedLengthEnd;

            /// <summary>
            /// Original Length-结束位置=28
            /// </summary>
            public const Int32 OriginalLengthEnd = OriginalLengthBegin + 4;


            /// <summary>
            /// Header Length=28
            /// </summary>
            public const Int32 HeaderLength = OriginalLengthEnd;

            /// <summary>
            /// Header Total Length=32
            /// </summary>
            public const Int32 HeaderTotalLength = HeaderLength + 4;
        }
    }
}
