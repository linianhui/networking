using System;

namespace Networking.Model.DataLink
{
    /// <summary>
    /// <see cref="EthernetFrame"/>的类型
    /// <see href="https://en.wikipedia.org/wiki/EtherType"/>
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
        /// VLAN : IEEE 802.1Q
        /// </summary>
        VLAN = 0x08100,

        /// <summary>
        /// Internet Protocol Version 6
        /// </summary>
        IPv6 = 0x86DD,

        /// <summary>
        /// PPPoE Discovery Stage
        /// </summary>
        PPPoEDiscoveryStage = 0x8863,

        /// <summary>
        /// PPPoE Session Stage
        /// </summary>
        PPPoESessionStage = 0x8864
    }
}
