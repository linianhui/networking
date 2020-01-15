using System;

namespace Networking.Model.DataLink
{
    /// <summary>
    /// <see cref="PPPFrame"/>的类型
    /// <see href="http://www.iana.org/assignments/ppp-numbers"/>
    /// </summary>
    public enum PPPFrameType : UInt16
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Padding = 0x0001,

        /// <summary>
        /// Internet Protocol Version 4
        /// </summary>
        IPv4 = 0x0021,

        /// <summary>
        /// Internet Protocol Version 6
        /// </summary>
        IPv6 = 0x0057,
    }
}
