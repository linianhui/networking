using System;

namespace Networking.Model.DataLink
{
    /*
     |                          ARP Frame                            |
     |- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|
     |0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -| 
     |    Hardware Type (2 octets)   |    Protocol Type (2 octets)   |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -| 
     |Hardware Length|Protocol Length|   Operation Code              |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |           Sender Hardware Address (6 octets)                  |
     |                               +- - - - - - - -+- - - - - - - -| 
     |                               | Sender IP Address (1~2 octets)|
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     | Sender IP Address (3~4 octets)|                               |
     |- - - - - - - -+- - - - - - - -+                               |
     |           Target Hardware Address (6 octets)                  |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|
     |           Target IP Address (4 octets)                        |
     |- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|

     fixed = 2+2+1+1+2+6+4+6+4 = 28 octets
     */

    public partial class ARPFrame
    {
        /// <summary>
        /// <see cref="ARPFrame"/>的结构信息
        /// <see href="https://en.wikipedia.org/wiki/address_resolution_protocol"/>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// 硬件类型-起始位置=0
            /// </summary>
            public static readonly Int32 HardwareTypeBegin = 0;

            /// <summary>
            /// 硬件类型-结束位置=2
            /// </summary>
            public static readonly Int32 HardwareTypeEnd = 2;

            /// <summary>
            /// 协议类型-起始位置=2
            /// </summary>
            public static readonly Int32 ProtocolTypeBegin = HardwareTypeEnd;

            /// <summary>
            /// 协议类型-结束位置=4
            /// </summary>
            public static readonly Int32 ProtocolTypeEnd = ProtocolTypeBegin + 2;

            /// <summary>
            /// 硬件地址长度-起始位置=4
            /// </summary>
            public static readonly Int32 HardwareAddressLengthBegin = ProtocolTypeEnd;

            /// <summary>
            /// 硬件地址长度-结束位置=5
            /// </summary>
            public static readonly Int32 HardwareAddressLengthEnd = HardwareAddressLengthBegin + 1;

            /// <summary>
            /// 协议地址长度-起始位置=5
            /// </summary>
            public static readonly Int32 ProtocolAddressLengthBegin = HardwareAddressLengthEnd;

            /// <summary>
            /// 协议地址长度-结束位置=6
            /// </summary>
            public static readonly Int32 ProtocolAddressLengthEnd = ProtocolAddressLengthBegin + 1;

            /// <summary>
            /// 操作码-起始位置=6
            /// </summary>
            public static readonly Int32 OperationCodeBegin = ProtocolAddressLengthEnd;

            /// <summary>
            /// 操作码-结束位置=8
            /// </summary>
            public static readonly Int32 OperationCodeEnd = OperationCodeBegin + 2;

            /// <summary>
            /// 发送者硬件地址-起始位置=8
            /// </summary>
            public static readonly Int32 SenderHardwareAddressBegin = OperationCodeEnd;

            /// <summary>
            /// 发送者硬件地址-结束位置=14
            /// </summary>
            public static readonly Int32 SenderHardwareAddressEnd = SenderHardwareAddressBegin + 6;

            /// <summary>
            /// 发送者协议地址-起始位置=14
            /// </summary>
            public static readonly Int32 SenderProtocolAddressBegin = SenderHardwareAddressEnd;

            /// <summary>
            /// 发送者协议地址-结束位置=18
            /// </summary>
            public static readonly Int32 SenderProtocolAddressEnd = SenderProtocolAddressBegin + 4;

            /// <summary>
            /// 接收者硬件地址-起始位置=18
            /// </summary>
            public static readonly Int32 TargetHardwareAddressBegin = SenderProtocolAddressEnd;

            /// <summary>
            /// 接收者硬件地址-结束位置=24
            /// </summary>
            public static readonly Int32 TargetHardwareAddressEnd = TargetHardwareAddressBegin + 6;

            /// <summary>
            /// 接收者协议地址-起始位置=24
            /// </summary>
            public static readonly Int32 TargetProtocolAddressBegin = TargetHardwareAddressEnd;

            /// <summary>
            /// 接收者协议地址-结束位置=28
            /// </summary>
            public static readonly Int32 TargetProtocolAddressEnd = TargetProtocolAddressBegin + 4;

        }
    }
}
