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
    public partial class PcapNGFileReader : PacketReader
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
            Block sectionHeaderBlock = null;
            var block = ReadBlock(null);
            while (block != null)
            {
                if (block.Type == BlockType.SectionHeader)
                {
                    sectionHeaderBlock = block;
                }
                yield return block;
                block = ReadBlock(sectionHeaderBlock?.IsLittleEndian);
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
                if (block.IsPacket)
                {
                    yield return block as IPacket;
                }
            }
        }

        private Block ReadBlock(Boolean? isLittleEndian)
        {
            var blockHeader = ReadBlockHeader(isLittleEndian);
            if (blockHeader == null)
            {
                return null;
            }

            var blockBytes = ReadBlockBytes(blockHeader.TotalLength);
            if (blockBytes.Length == 0)
            {
                return null;
            }

            return Block.From(blockHeader.Type, blockHeader.IsLittleEndian, blockBytes);
        }

        private BlockHeader ReadBlockHeader(Boolean? isLittleEndian)
        {
            var headerBytes = base.ReadBytes(SectionHeaderBlock.Layout.MagicNumberEnd);
            if (headerBytes.Length == 0)
            {
                return null;
            }

            base.Position = base.Position - SectionHeaderBlock.Layout.MagicNumberEnd;

            return BlockHeader.From(headerBytes, isLittleEndian);
        }

        private Byte[] ReadBlockBytes(UInt32 blockLength)
        {
            return base.ReadBytes((Int32)blockLength);
        }
    }
}
