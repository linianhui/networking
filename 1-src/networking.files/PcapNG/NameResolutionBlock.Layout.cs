using System;

namespace Networking.Files.PcapNG
{
    public partial class NameResolutionBlock
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://pcapng.github.io/pcapng/#section_nrb"/>
        /// <para></para>
        /// <para>|                  Name Resolution Block (NRB)                  |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Block Type = 0x00000004                             |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Block Total Length (4 octets = 32 bits)             |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|  Record Type                  | Record Value Length           |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|  Record Value : variable length, padded to 32 bits            |</para>
        /// <para>|                                                               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|                                                               |</para>
        /// <para>|                    . . . other records . . .                  |</para>
        /// <para>|                                                               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|  Record Type = nrb_record_end | Record Value Length = 0       |</para>
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
            /// Record Type 起始位置=0
            /// </summary>
            public const Int32 RecordTypeBegin = 0;

            /// <summary>
            /// Record Type 结束位置=2
            /// </summary>
            public const Int32 RecordTypeEnd = RecordTypeBegin + 2;


            /// <summary>
            /// Record Value 起始位置=2
            /// </summary>
            public const Int32 RecordValueBegin = RecordTypeEnd;

            /// <summary>
            /// Record Value 结束位置=4
            /// </summary>
            public const Int32 RecordValueEnd = RecordValueBegin + 2;


            /// <summary>
            /// Record Header Length=4
            /// </summary>
            public const Int32 RecordHeaderLength = RecordValueEnd;
        }
    }
}
