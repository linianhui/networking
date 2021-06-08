using System;

namespace Networking.Model.DataLink
{
    /// <summary>
    /// 硬件类型
    /// </summary>
    public enum HardwareType : UInt16
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Ethernet
        /// </summary>
        Ethernet = 1,

        /// <summary>
        /// IEEE802
        /// </summary>
        IEEE802 = 6
    }
}
