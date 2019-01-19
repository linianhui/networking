using System;

namespace Networking.Model.DataLink
{
    /// <summary>
    /// <see cref="EthernetFrame"/>的类型
    /// </summary>
    public enum EthernetFrameType : UInt16
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0x0000,

        /// <summary>
        /// Internet Protocol Version 4
        /// </summary>
        IPv4 = 0x0800,

        /// <summary>
        /// Address Resolution Protocol
        /// </summary>
        ARP = 0x0806,

        /// <summary>
        /// Internet Protocol Version 6
        /// </summary>
        IPv6 = 0x86DD,
    }
}
