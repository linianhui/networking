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

        /// <summary>
        /// 创建 <see cref="Block"/> 
        /// </summary>
        public static Block From(
            BlockType blockType,
            Boolean isLittleEndian,
            Memory<Byte> blockBytes)
        {
            var block = BuildBlock(blockType);
            block.IsLittleEndian = isLittleEndian;
            block.Bytes = blockBytes;
            return block;
        }

        private static Block BuildBlock(BlockType blockType)
        {
            switch (blockType)
            {
                case BlockType.SectionHeader:
                    return new SectionHeaderBlock();
                case BlockType.InterfaceDescription:
                    return new InterfaceDescriptionBlock();
                case BlockType.SimplePacket:
                    return new SimplePacketBlock();
                case BlockType.EnhancedPacket:
                    return new EnhancedPacketBlock();
                default:
                    return new Block();
            }
        }
    }
}
