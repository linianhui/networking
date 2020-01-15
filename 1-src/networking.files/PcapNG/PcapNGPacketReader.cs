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
    public class PcapNGPacketReader : PacketReader
    {
        /// <summary>
        /// 魔数
        /// </summary>
        public static readonly ISet<UInt32> MagicNumbers = new HashSet<UInt32>
        {
           0x0A_0D_0D_0A
        };

        /// <summary>
        /// 构造函数
        /// </summary>
        internal PcapNGPacketReader(Stream stream) : base(stream)
        {
        }

        /// <summary>
        /// 读取<see cref="Block"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Block> ReadBlocks()
        {
            SectionHeaderBlock sectionHeaderBlock = null;
            var block = ReadBlock(false);
            var interfaceDescriptionBlocks = new List<InterfaceDescriptionBlock>();
            while (block != null)
            {
                switch (block.Type)
                {
                    case BlockType.SectionHeader:
                        sectionHeaderBlock = (SectionHeaderBlock)block;
                        interfaceDescriptionBlocks = new List<InterfaceDescriptionBlock>();
                        break;
                    case BlockType.InterfaceDescription:
                        interfaceDescriptionBlocks.Add((InterfaceDescriptionBlock)block);
                        break;
                }

                if (sectionHeaderBlock == null)
                {
                    throw new ArgumentNullException(nameof(sectionHeaderBlock));
                }

                block.SectionHeader = sectionHeaderBlock;

                if (block.InterfaceId.HasValue)
                {
                    block.InterfaceDescription = interfaceDescriptionBlocks[(Int32)block.InterfaceId.Value];
                }
                yield return block;
                block = ReadBlock(sectionHeaderBlock.IsLittleEndian);
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

        private Block ReadBlock(Boolean isLittleEndian)
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

            return BlockFactory.Create(blockHeader.Type, blockHeader.IsLittleEndian, blockBytes);
        }

        private BlockHeader ReadBlockHeader(Boolean isLittleEndian)
        {
            var headerBytes = base.ReadBytes(SectionHeaderBlock.Layout.MagicNumberEnd);
            if (headerBytes.Length == 0)
            {
                return null;
            }

            base.Position -= SectionHeaderBlock.Layout.MagicNumberEnd;

            return BlockHeader.From(isLittleEndian, headerBytes);
        }

        private Byte[] ReadBlockBytes(UInt32 blockLength)
        {
            return base.ReadBytes((Int32)blockLength);
        }
    }
}
