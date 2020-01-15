using System;

namespace Networking.Model.Application
{
    public partial class DHCP
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://en.wikipedia.org/wiki/Dynamic_Host_Configuration_Protocol"/>
        /// <para></para>
        /// <para>|          DHCP : Dynamic Host Configuration Protocol           |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+</para>
        /// <para>|Operation Code | Hardware Type |Hardware Length|   hops(1)     |</para> 
        /// <para>+---------------+---------------+---------------+---------------+</para>
        /// <para>|                        Transaction ID                         |</para>
        /// <para>+---------------+---------------+---------------+---------------+</para>
        /// <para>|      Seconds (2 octets)       |       Flags (2 octets)        |</para>
        /// <para>+---------------+---------------+---------------+---------------+</para>
        /// <para>|                        Client   IP Address                    |</para>
        /// <para>+---------------+---------------+---------------+---------------+</para>
        /// <para>|                 Your (Client)   IP Address                    |</para>
        /// <para>+---------------+---------------+---------------+---------------+</para>
        /// <para>|                        Server   IP Address                    |</para>
        /// <para>+---------------+---------------+---------------+---------------+</para>
        /// <para>|                       Gateway   IP Address                    |</para>
        /// <para>+---------------+---------------+---------------+---------------+</para>
        /// <para>|                        Client   Hardware Address              |</para>
        /// <para>|                         (16 octets)                           |</para>
        /// <para>+---------------+---------------+---------------+---------------+</para>
        /// <para>|                         Server Host Name                      |</para>
        /// <para>|                         (64 octets)                           |</para>
        /// <para>+---------------+---------------+---------------+---------------+</para>
        /// <para>|                         Boot File Name                        |</para>
        /// <para>|                        (128 octets)                           |</para>
        /// <para>+---------------+---------------+---------------+---------------+</para>
        /// <para>|                          options(var)                         |</para>
        /// <para>+---------------+---------------+---------------+---------------+</para>
        /// <para></para>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// 操作码-起始位置=0
            /// </summary>
            public const Int32 OperationCodeBegin = 0;

            /// <summary>
            /// 操作码-结束位置=1
            /// </summary>
            public const Int32 OperationCodeEnd = OperationCodeBegin + 1;


            /// <summary>
            /// Hardware Type-起始位置=1
            /// </summary>
            public const Int32 HardwareTypeBegin = OperationCodeEnd;

            /// <summary>
            /// Hardware Type-结束位置=2
            /// </summary>
            public const Int32 HardwareTypeEnd = HardwareTypeBegin + 1;


            /// <summary>
            /// Hardware Length-起始位置=2
            /// </summary>
            public const Int32 HardwareLengthBegin = HardwareTypeEnd;

            /// <summary>
            /// Hardware Length-结束位置=3
            /// </summary>
            public const Int32 HardwareLengthEnd = HardwareLengthBegin + 1;


            /// <summary>
            /// Transaction Id-起始位置=4
            /// </summary>
            public const Int32 TransactionIdBegin = 4;

            /// <summary>
            /// Transaction Id-结束位置=8
            /// </summary>
            public const Int32 TransactionIdEnd = TransactionIdBegin + 4;


            /// <summary>
            /// Seconds-起始位置=8
            /// </summary>
            public const Int32 SecondsBegin = TransactionIdEnd;

            /// <summary>
            /// Seconds-结束位置=10
            /// </summary>
            public const Int32 SecondsEnd = SecondsBegin + 2;


            /// <summary>
            /// Flags-起始位置=10
            /// </summary>
            public const Int32 FlagsBegin = SecondsEnd;

            /// <summary>
            /// Flags-结束位置=12
            /// </summary>
            public const Int32 FlagsEnd = FlagsBegin + 2;


            /// <summary>
            /// Client IP Address-起始位置=12
            /// </summary>
            public const Int32 ClientIPAddressBegin = FlagsEnd;

            /// <summary>
            /// Client IP Address-结束位置=16
            /// </summary>
            public const Int32 ClientIPAddressEnd = ClientIPAddressBegin + 4;


            /// <summary>
            /// Your Client IP Address-起始位置=16
            /// </summary>
            public const Int32 YourClientIPAddressBegin = ClientIPAddressEnd;

            /// <summary>
            /// Your Client IP Address-结束位置=20
            /// </summary>
            public const Int32 YourClientIPAddressEnd = YourClientIPAddressBegin + 4;


            /// <summary>
            /// Server IP Address-起始位置=20
            /// </summary>
            public const Int32 ServerIPAddressBegin = YourClientIPAddressEnd;

            /// <summary>
            /// Server IP Address-结束位置=24
            /// </summary>
            public const Int32 ServerIPAddressEnd = ServerIPAddressBegin + 4;


            /// <summary>
            /// Gateway IP Address-起始位置=24
            /// </summary>
            public const Int32 GatewayIPAddressBegin = ServerIPAddressEnd;

            /// <summary>
            /// Gateway IP Address-结束位置=28
            /// </summary>
            public const Int32 GatewayIPAddressEnd = GatewayIPAddressBegin + 4;


            /// <summary>
            /// Client Hardware Address-起始位置=28
            /// </summary>
            public const Int32 ClientHardwareAddressBegin = GatewayIPAddressEnd;

            /// <summary>
            /// Client Hardware Address-结束位置=44
            /// </summary>
            public const Int32 ClientHardwareAddressEnd = ClientHardwareAddressBegin + 16;


            /// <summary>
            /// Server Host Name-起始位置=44
            /// </summary>
            public const Int32 ServerHostNameBegin = ClientHardwareAddressEnd;

            /// <summary>
            /// Server Host Name-结束位置=108
            /// </summary>
            public const Int32 ServerHostNameEnd = ServerHostNameBegin + 64;


            /// <summary>
            /// Boot File Name-起始位置=108
            /// </summary>
            public const Int32 BootFileNameBegin = ServerHostNameEnd;

            /// <summary>
            /// Boot File Name-结束位置=236
            /// </summary>
            public const Int32 BootFileNameEnd = BootFileNameBegin + 128;
        }
    }
}
