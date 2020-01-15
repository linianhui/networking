using System;

namespace Networking.Files.PcapNG
{
    public partial class InterfaceStatisticsBlock
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://pcapng.github.io/pcapng/#section_isb"/>
        /// <para></para>
        /// <para>|               Interface Statistics Block (ISB)                |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Block Type = 0x00000005                             |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Block Total Length (4 octets = 32 bits)             |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Interface ID                                        |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Timestamp (High)                                    |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Timestamp (Low)                                     |</para>
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
            /// Header Length=20
            /// </summary>
            public const Int32 HeaderLength = TimestampLowEnd;

            /// <summary>
            /// Header Total Length=24
            /// </summary>
            public const Int32 HeaderTotalLength = HeaderLength + 4;
        }
    }
}
