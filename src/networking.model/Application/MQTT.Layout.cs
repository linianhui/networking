using System;

namespace Networking.Model.Application
{
    public partial class MQTT
    {
        /// <summary>
        /// <see cref="MQTT"/>的首部-布局信息
        /// <see href="http://docs.oasis-open.org/mqtt/mqtt/v3.1.1/mqtt-v3.1.1.html"/>
        /// <para></para>
        /// <para>|                             MQTT                              |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>| Type  | Flags |Remaining Length (1 ~ 4 octets)                |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|         Variable Header (optional)                            |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|         Payload (optional)                                    |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>Fixed header    = Type + Flags + Remaining Length = 2 ~ 5 octets </para>
        /// <para>RemainingLength = Variable Header + Payload                      </para>
        /// <para></para>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// Type-起始位置=0
            /// </summary>
            public const Int32 TypeBegin = 0;

            /// <summary>
            /// Type-bits索引=0
            /// </summary>
            public const Int32 TypeBitIndex = 0;

            /// <summary>
            /// Type-bits长度=4
            /// </summary>
            public const Int32 TypeBitLength = 4;


            /// <summary>
            /// Flags-起始位置=0
            /// </summary>
            public const Int32 FlagsBegin = 0;

            /// <summary>
            /// Flags-Duplicate-bit索引=4
            /// </summary>
            public const Int32 FlagsDuplicateBitIndex = 4;

            /// <summary>
            /// Flags-QoS-bits索引=5
            /// </summary>
            public const Int32 FlagsQoSBitIndex = 5;

            /// <summary>
            /// Flags-QoS-bits长度=2
            /// </summary>
            public const Int32 FlagsQoSLength = 2;

            /// <summary>
            /// Flags-Retain-bit索引=7
            /// </summary>
            public const Int32 FlagsRetainBitIndex = 7;
        }
    }
}
