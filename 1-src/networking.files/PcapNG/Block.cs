using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// Block
    /// <see href="https://pcapng.github.io/pcapng/#section_block"/>
    /// </summary>
    public partial class Block : Octets
    {
        /// <summary>
        /// 是否是数据包
        /// </summary>
        public Boolean IsPacket { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Block(Boolean isPacket = false)
        {
            IsPacket = isPacket;
        }

        /// <summary>
        /// Type
        /// </summary>
        public BlockType Type
        {
            get { return (BlockType)base.GetUInt32(Layout.TypeBegin); }
        }

        /// <summary>
        /// Total Length
        /// </summary>
        public UInt32 TotalLength
        {
            get { return base.GetUInt32(Layout.TotalLengthBegin); }
        }
    }
}
