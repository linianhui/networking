using System;

namespace Networking.Model.Internet
{
    /// <summary>
    /// IP协议类型
    /// </summary>
    public enum IPPacketType : Byte
    {
        /// <summary>
        /// Internet Control Message Protocol
        /// </summary>
        ICMPv4 = 1,

        /// <summary>
        /// Internet Group Management Protocol
        /// </summary>
        IGMP = 2,

        /// <summary>
        /// Transmission Control Protocol
        /// </summary>
        TCP = 6,

        /// <summary>
        /// User Datagram Protocol
        /// </summary>
        UDP = 17,

        /// <summary>
        /// Internet Control Message Protocol V6.
        /// </summary>
        ICMPV6 = 58
    }
}
