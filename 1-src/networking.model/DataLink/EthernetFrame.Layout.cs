using System;

namespace Networking.Model.DataLink
{
    /*
     |              Ethernet II (DIX) Frame                          |
     |- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|
     |0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -| 
     |           Destination MAC Address (6 octets)                  |
     |                               +- - - - - - - -+- - - - - - - -| 
     |                               |                               |
     |- - - - - - - -+- - - - - - - -+                               | 
     |           Source MAC Address (6 octets)                       |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |        Type (2 octets)        |                               |
     |- - - - - - - -+- - - - - - - -+                               |
     |                                                               |
     |               Payload (46-1500 octets)                        |
     |                                                               |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |                        CRC (4 octets)                         |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|

     min = 6+6+2+4+46   = 64 octets
     max = 6+6+2+4+1500 = 1518 octets
     */

    public partial class EthernetFrame
    {
        /// <summary>
        /// <see cref="EthernetFrame"/>的结构信息
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// 类型长度=2
            /// </summary>
            public static readonly Int32 TypeLength = 2;

            /// <summary>
            /// 目标MAC地址-起始位置=0
            /// </summary>
            public static readonly Int32 DestinationMACAddressBegin = 0;

            /// <summary>
            /// 目标MAC地址-结束位置=6
            /// </summary>
            public static readonly Int32 DestinationMACAddressEnd = DestinationMACAddressBegin + MACAddress.Layout.Length;

            /// <summary>
            /// 源MAC地址-起始位置=6
            /// </summary>
            public static readonly Int32 SourceMACAddressBegin = DestinationMACAddressEnd;

            /// <summary>
            /// 源MAC地址-结束位置=12
            /// </summary>
            public static readonly Int32 SourceMACAddressEnd = SourceMACAddressBegin + MACAddress.Layout.Length;

            /// <summary>
            /// 类型-起始位置=12
            /// </summary>
            public static readonly Int32 TypeBegin = SourceMACAddressEnd;

            /// <summary>
            /// 类型-结束位置=14
            /// </summary>
            public static readonly Int32 TypeEnd = TypeBegin + TypeLength;

            /// <summary>
            /// 头部信息-长度=14
            /// </summary>
            public static readonly Int32 HeaderLength = TypeEnd;
        }
    }
}
