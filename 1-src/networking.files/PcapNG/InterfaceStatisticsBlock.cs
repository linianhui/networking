using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// Interface Statistics Block
    /// <see href="https://pcapng.github.io/pcapng/#section_isb"/>
    /// </summary>
    public partial class InterfaceStatisticsBlock : Block
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public InterfaceStatisticsBlock() : base(isPacket: false)
        {

        }

        /// <summary>
        /// Interface Id
        /// </summary>
        public UInt32 InterfaceId
        {
            get { return GetUInt32(Layout.InterfaceIdBegin); }
        }
    }
}
