using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// Block
    /// </summary>
    public class Block
    {
        /// <summary>
        /// Header
        /// </summary>
        public BlockHeader Header { get; }

        /// <summary>
        /// Body
        /// </summary>
        public BlockBody Body { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Block(BlockHeader blockHeader, Memory<Byte> blockBytes)
        {
            Header = blockHeader;
            Body = BlockBody.From(blockHeader.Type, blockBytes);
        }
    }
}
