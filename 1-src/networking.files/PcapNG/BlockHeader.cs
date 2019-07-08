using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// Block Header
    /// <see href="https://pcapng.github.io/pcapng/#section_block"/>
    /// </summary>
    public partial class BlockHeader : Octets
    {
        private BlockHeader() { }

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
        /// Body Length
        /// </summary>
        public UInt32 BodyLength
        {
            get { return TotalLength - 12; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="headerBytes"></param>
        /// <returns></returns>
        public static BlockHeader From(Memory<Byte> headerBytes)
        {
            if (headerBytes.Length != 12)
            {
                throw new ArithmeticException(nameof(headerBytes) + "length must be 12.");
            }
            var blockHeader = new BlockHeader
            {
                Bytes = headerBytes
            };
            if (blockHeader.Type == BlockType.SectionHeader)
            {
                blockHeader.IsLittleEndian = blockHeader.GetByte(8) == 0x1A;
            }
            return blockHeader;
        }
    }
}
