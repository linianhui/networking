using System;
using System.Collections.Generic;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// <see cref="Block"/>创建者
    /// </summary>
    public static class BlockFactory
    {

        /// <summary>
        /// 默认
        /// </summary>
        public static readonly Func<Boolean, Memory<Byte>, Block> Default = (isLittleEndian, bytes) => new Block
        {
            IsLittleEndian = isLittleEndian,
            Bytes = bytes
        };

        /// <summary>
        /// BlockType
        /// </summary>
        public static readonly IDictionary<BlockType, Func<Boolean, Memory<Byte>, Block>> BlockTypeMap = new Dictionary<BlockType, Func<Boolean, Memory<Byte>, Block>>
        {
            [BlockType.SectionHeader] = (isLittleEndian, bytes) => new SectionHeaderBlock
            {
                IsLittleEndian = isLittleEndian,
                Bytes = bytes
            },
            [BlockType.InterfaceDescription] = (isLittleEndian, bytes) => new InterfaceDescriptionBlock
            {
                IsLittleEndian = isLittleEndian,
                Bytes = bytes
            },
            [BlockType.SimplePacket] = (isLittleEndian, bytes) => new SimplePacketBlock
            {
                IsLittleEndian = isLittleEndian,
                Bytes = bytes
            },
            [BlockType.NameResolution] = (isLittleEndian, bytes) => new NameResolutionBlock
            {
                IsLittleEndian = isLittleEndian,
                Bytes = bytes
            },
            [BlockType.InterfaceStatistics] = (isLittleEndian, bytes) => new InterfaceStatisticsBlock
            {
                IsLittleEndian = isLittleEndian,
                Bytes = bytes
            },
            [BlockType.EnhancedPacket] = (isLittleEndian, bytes) => new EnhancedPacketBlock
            {
                IsLittleEndian = isLittleEndian,
                Bytes = bytes
            },
        };

        /// <summary>
        /// 创建 <see cref="Block"/> 
        /// </summary>
        public static Block Create(BlockType blockType, Boolean isLittleEndian, Memory<Byte> blockBytes)
        {
            if (BlockTypeMap.ContainsKey(blockType))
            {
                return BlockTypeMap[blockType](isLittleEndian, blockBytes);
            }

            return Default(isLittleEndian, blockBytes);
        }
    }
}
