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
        /// Interface Id
        /// </summary>
        public override UInt32? InterfaceId
        {
            get { return GetUInt32(Layout.InterfaceIdBegin); }
        }
    }
}
