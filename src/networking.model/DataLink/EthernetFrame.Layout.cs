using System;

namespace Networking.Model.DataLink
{
    public partial class EthernetFrame
    {
        /// <summary>
        /// <see cref="EthernetFrame"/>的首部-布局信息
        /// <see href="https://en.wikipedia.org/wiki/Ethernet_frame"/>
        /// <para></para>
        /// <para>|              Ethernet II (DIX) Frame                          |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Destination MAC Address (6 octets)                  |</para>
        /// <para>|                               +- - - - - - - -+- - - - - - - -|</para>
        /// <para>|                               |                               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+                               |</para>
        /// <para>|           Source MAC Address (6 octets)                       |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|        Type (2 octets)        |                               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+                               |</para>
        /// <para>|                                                               |</para>
        /// <para>|               Payload (46-1500 octets)                        |</para>
        /// <para>|                                                               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|                        CRC (4 octets)                         |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>min = 6+6+2+4+46   = 64 octets                                   </para>
        /// <para>max = 6+6+2+4+1500 = 1518 octets                                 </para>
        /// <para></para>
        /// </summary>
        public class Layout
        {

            /// <summary>
            /// 目标MAC地址-起始位置=0
            /// </summary>
            public const Int32 DestinationMACAddressBegin = 0;

            /// <summary>
            /// 目标MAC地址-结束位置=6
            /// </summary>
            public const Int32 DestinationMACAddressEnd = DestinationMACAddressBegin + MACAddress.Layout.Length;


            /// <summary>
            /// 源MAC地址-起始位置=6
            /// </summary>
            public const Int32 SourceMACAddressBegin = DestinationMACAddressEnd;

            /// <summary>
            /// 源MAC地址-结束位置=12
            /// </summary>
            public const Int32 SourceMACAddressEnd = SourceMACAddressBegin + MACAddress.Layout.Length;


            /// <summary>
            /// 类型-起始位置=12
            /// </summary>
            public const Int32 TypeBegin = SourceMACAddressEnd;

            /// <summary>
            /// 类型-结束位置=14
            /// </summary>
            public const Int32 TypeEnd = TypeBegin + 2;


            /// <summary>
            /// 首部信息-长度=14
            /// </summary>
            public const Int32 HeaderLength = TypeEnd;
        }
    }
}
