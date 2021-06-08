using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// Block Header
    /// </summary>
    public class BlockHeader : Octets
    {
        private BlockHeader() { }

        /// <summary>
        /// Type
        /// </summary>
        public BlockType Type
        {
            get { return (BlockType)base.GetUInt32(Block.Layout.TypeBegin); }
        }

        /// <summary>
        /// Total Length
        /// </summary>
        public UInt32 TotalLength
        {
            get { return base.GetUInt32(Block.Layout.TotalLengthBegin); }
        }

        /// <summary>
        /// 创建
        /// </summary>
        internal static BlockHeader From(Boolean isLittleEndian, Memory<Byte> headerBytes)
        {
            var header = new BlockHeader
            {
                IsLittleEndian = isLittleEndian,
                Bytes = headerBytes
            };

            if (header.Type == BlockType.SectionHeader)
            {
                header.IsLittleEndian = header.GetByte(8) == 0x4D;
            }

            return header;
        }
    }
}
