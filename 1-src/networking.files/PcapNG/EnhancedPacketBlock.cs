using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// Enhanced Packet Block
    /// <see href="https://pcapng.github.io/pcapng/#section_epb"/>
    /// </summary>
    public partial class EnhancedPacketBlock : Block
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public EnhancedPacketBlock() : base(isPacket: false)
        {

        }
    }
}
