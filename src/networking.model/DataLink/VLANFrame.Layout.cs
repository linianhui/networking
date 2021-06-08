using System;

namespace Networking.Model.DataLink
{
    public partial class VLANFrame
    {
        /// <summary>
        /// <see cref="VLANFrame"/>的首部-布局信息
        /// <see href="https://en.wikipedia.org/wiki/IEEE_802.1Q#Frame_format"/>
        /// <para></para>
        /// <para>|                          IEEE 802.1Q                          |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>| PCP |D| VID (VLAN identifier) |                               |</para>
        /// <para>|3bits|E| 12 bits               +        Type (2 octets)        |</para>
        /// <para>|     |I| max = 0xFFF = 4096    |                               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|                                                               |</para>
        /// <para>|               Payload (46-1500 octets)                        |</para>
        /// <para>|                                                               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>PCP = Priority code point                                        </para>
        /// <para>DEI = Drop eligible indicator                                    </para>
        /// <para></para>
        /// </summary>
        public class Layout
        {

            /// <summary>
            /// PCP-起始位置=0
            /// </summary>
            public const Int32 PCPBegin = 0;

            /// <summary>
            /// PCP-bits索引=0
            /// </summary>
            public const Int32 PCPBitIndex = 0;

            /// <summary>
            /// PCP-bits长度=0
            /// </summary>
            public const Int32 PCPBitLength = 3;



            /// <summary>
            /// DEI-起始位置=0
            /// </summary>
            public const Int32 DEIBegin = 0;

            /// <summary>
            /// DEI-bits索引=0
            /// </summary>
            public const Int32 DEIBitIndex = 3;


            /// <summary>
            /// VID-起始位置=0
            /// </summary>
            public const Int32 VIDBegin = 0;

            /// <summary>
            /// VID-bits索引=4
            /// </summary>
            public const Int32 VIDBitIndex = 4;

            /// <summary>
            /// VID-bits长度=12
            /// </summary>
            public const Int32 VIDBitLength = 12;


            /// <summary>
            /// 类型-起始位置=2
            /// </summary>
            public const Int32 TypeBegin = 2;

            /// <summary>
            /// 类型-结束位置=4
            /// </summary>
            public const Int32 TypeEnd = TypeBegin + 2;



            /// <summary>
            /// 首部信息-长度=4
            /// </summary>
            public const Int32 HeaderLength = TypeEnd;
        }
    }
}
