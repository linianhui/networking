using System;
using System.Collections.Generic;
using System.IO;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// *.pcapng文件
    /// <see href="https://pcapng.github.io/pcapng"/>
    /// <see href="https://wiki.wireshark.org/Development/PcapNg"/>
    /// </summary>
    public class PcapNGFileReader : PacketReader
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PcapNGFileReader(String filePath) : base(filePath)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PcapNGFileReader(Stream stream) : base(stream)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PcapNGFileReader(Byte[] bytes) : base(bytes)
        {
        }

        /// <summary>
        /// 读取<see cref="Block"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Block> ReadBlocks()
        {
            Block sectionBlock = null;
            var block = ReadBlock(null);
            while (block != null)
            {
                if (block.Header.Type == BlockType.SectionHeader)
                {
                    sectionBlock = block;
                }
                yield return block;
                block = ReadBlock(sectionBlock);
            }
        }

        /// <summary>
        /// 读取<see cref="IPacket"/>
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<IPacket> ReadPackets()
        {
            foreach (var block in ReadBlocks())
            {
                var blockBody = block.Body;
                if (blockBody.IsPacket)
                {
                    yield return blockBody as IPacket;
                }
            }
        }

        private Block ReadBlock(Block sectionBlock)
        {
            var blockHeader = ReadBlockHeader(sectionBlock);
            if (blockHeader == null)
            {
                return null;
            }

            var blockBodyBytes = ReadBlockBodyBytes(blockHeader);
            if (blockBodyBytes.Length == 0)
            {
                return null;
            }

            return new Block(blockHeader, blockBodyBytes);
        }

        private BlockHeader ReadBlockHeader(Block sectionBlock)
        {
            var headerLength = BlockHeader.Layout.HeaderLength
                               + SectionHeaderBlock.Layout.MagicNumberLength;
            var headerBytes = base.ReadBytes(headerLength);
            if (headerBytes.Length == 0)
            {
                return null;
            }

            base.Offset = base.Offset - SectionHeaderBlock.Layout.MagicNumberLength;

            var blockHeader = BlockHeader.From(headerBytes);
            if (blockHeader.Type != BlockType.SectionHeader && sectionBlock != null)
            {
                blockHeader.IsLittleEndian = sectionBlock.Header.IsLittleEndian;
            }
            return blockHeader;
        }

        private Byte[] ReadBlockBodyBytes(BlockHeader blockHeader)
        {
            var bodyLength = (Int32)blockHeader.BodyLength;
            var bodyBytes = base.ReadBytes(bodyLength);
            base.Offset = base.Offset + BlockHeader.Layout.TotalLengthLength;
            return bodyBytes;
        }
    }
}
