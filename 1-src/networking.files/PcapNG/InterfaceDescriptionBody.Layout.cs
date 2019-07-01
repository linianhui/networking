using System;

namespace Networking.Files.PcapNG
{
    public partial class InterfaceDescriptionBody
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://pcapng.github.io/pcapng/#section_idb"/>
        /// <para></para>
        /// <para>|               Interface Description Block (IHB)               |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para> 
        /// <para>|           LinkType            |         Reserved              |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           SnapLen                                             |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Options (variable)                                  |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para> 
        /// <para></para>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// LinkType-起始位置=0
            /// </summary>
            public const Int32 DataLinkTypeBegin = 0;

            /// <summary>
            /// LinkType-结束位置=2
            /// </summary>
            public const Int32 DataLinkTypeEnd = DataLinkTypeBegin + 2;


            /// <summary>
            /// Captured Length-起始位置=4
            /// </summary>
            public const Int32 MaxCapturedLengthBegin = 4;

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