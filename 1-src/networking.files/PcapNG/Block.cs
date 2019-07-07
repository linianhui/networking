using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// General Block
    /// <see href="https://pcapng.github.io/pcapng/#section_block"/>
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
        /// ¹¹Ôìº¯Êý
        /// </summary>
        public Block(BlockHeader blockHeader, Memory<Byte> blockBytes)
        {
            Header = blockHeader;
            Body = BlockBody.From(blockHeader.Type, blockBytes);
        }
    }
}
