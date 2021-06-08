using System;

namespace Networking.Files.PcapNG
{

    public partial class NameResolutionBlock
    {
        /// <summary>
        /// Name Resolution Block Record Type
        /// </summary>
        public enum RecordType : UInt16
        {
            /// <summary>
            /// 结束
            /// </summary>
            End = 0x0000,

            /// <summary>
            /// IPv4
            /// </summary>
            IPv4 = 0x0001,

            /// <summary>
            /// IPv6
            /// </summary>
            IPv6 = 0x0002
        }
    }
}
