using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// Name Resolution Block
    /// <see href="https://pcapng.github.io/pcapng/#section_nrb"/>
    /// </summary>
    public partial class NameResolutionBlock : Block
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public NameResolutionBlock() : base(isPacket: false)
        {

        }
    }
}
