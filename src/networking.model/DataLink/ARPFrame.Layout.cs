using System;

namespace Networking.Model.DataLink
{
    public partial class ARPFrame
    {
        /// <summary>
        /// <see cref="ARPFrame"/>的结构信息
        /// <see href="https://en.wikipedia.org/wiki/Address_Resolution_Protocol"/>
        /// <para></para>
        /// <para>|                          ARP Frame                            |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|    Hardware Type (2 octets)   |    Protocol Type (2 octets)   |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|Hardware Length|Protocol Length|   Operation Code              |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Sender Hardware Address (6 octets)                  |</para>
        /// <para>|                               +- - - - - - - -+- - - - - - - -|</para>
        /// <para>|                               | Sender IP Address (1~2 octets)|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>| Sender IP Address (3~4 octets)|                               |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+                               |</para>
        /// <para>|           Target Hardware Address (6 octets)                  |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|           Target IP Address (4 octets)                        |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>fixed = 2+2+1+1+2+6+4+6+4 = 28 octets                            </para>
        /// <para></para>
        /// </summary>
        public class Layout
        {

            /// <summary>
            /// 硬件类型-起始位置=0
            /// </summary>
            public const Int32 HardwareTypeBegin = 0;

            /// <summary>
            /// 硬件类型-结束位置
            /// </summary>
            public const Int32 HardwareTypeEnd = HardwareTypeBegin + 2;


            /// <summary>
            /// 协议类型-起始位置=2
            /// </summary>
            public const Int32 ProtocolTypeBegin = HardwareTypeEnd;

            /// <summary>
            /// 协议类型-结束位置=4
            /// </summary>
            public const Int32 ProtocolTypeEnd = ProtocolTypeBegin + 2;


            /// <summary>
            /// 硬件地址长度-起始位置=4
            /// </summary>
            public const Int32 HardwareAddressLengthBegin = ProtocolTypeEnd;

            /// <summary>
            /// 硬件地址长度-结束位置=5
            /// </summary>
            public const Int32 HardwareAddressLengthEnd = HardwareAddressLengthBegin + 1;


            /// <summary>
            /// 协议地址长度-起始位置=5
            /// </summary>
            public const Int32 ProtocolAddressLengthBegin = HardwareAddressLengthEnd;

            /// <summary>
            /// 协议地址长度-结束位置=6
            /// </summary>
            public const Int32 ProtocolAddressLengthEnd = ProtocolAddressLengthBegin + 1;


            /// <summary>
            /// 操作码-起始位置=6
            /// </summary>
            public const Int32 OperationCodeBegin = ProtocolAddressLengthEnd;

            /// <summary>
            /// 操作码-结束位置=8
            /// </summary>
            public const Int32 OperationCodeEnd = OperationCodeBegin + 2;


            /// <summary>
            /// 发送者硬件地址-起始位置=8
            /// </summary>
            public const Int32 SenderHardwareAddressBegin = OperationCodeEnd;

            /// <summary>
            /// 发送者硬件地址-结束位置=14
            /// </summary>
            public const Int32 SenderHardwareAddressEnd = SenderHardwareAddressBegin + MACAddress.Layout.Length;


            /// <summary>
            /// 发送者协议地址-起始位置=14
            /// </summary>
            public const Int32 SenderProtocolAddressBegin = SenderHardwareAddressEnd;

            /// <summary>
            /// 发送者协议地址-结束位置=18
            /// </summary>
            public const Int32 SenderProtocolAddressEnd = SenderProtocolAddressBegin + IPAddress.Layout.V4Length;


            /// <summary>
            /// 接收者硬件地址-起始位置=18
            /// </summary>
            public const Int32 TargetHardwareAddressBegin = SenderProtocolAddressEnd;

            /// <summary>
            /// 接收者硬件地址-结束位置=24
            /// </summary>
            public const Int32 TargetHardwareAddressEnd = TargetHardwareAddressBegin + +MACAddress.Layout.Length;


            /// <summary>
            /// 接收者协议地址-起始位置=24
            /// </summary>
            public const Int32 TargetProtocolAddressBegin = TargetHardwareAddressEnd;

            /// <summary>
            /// 接收者协议地址-结束位置=28
            /// </summary>
            public const Int32 TargetProtocolAddressEnd = TargetProtocolAddressBegin + +IPAddress.Layout.V4Length;

        }
    }
}
