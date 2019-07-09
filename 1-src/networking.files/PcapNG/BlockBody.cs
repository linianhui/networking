using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// <see cref="Block"/> 的Body
    /// </summary>
    public class BlockBody : Octets
    {
        /// <summary>
        /// 是否是数据包
        /// </summary>
        public Boolean IsPacket { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BlockBody(Boolean isPacket = false)
        {
            IsPacket = isPacket;
        }

        /// <summary>
        /// 创建 <see cref="BlockBody"/> 
        /// </summary>
        /// <param name="blockHeader">blockHeader</param>
        /// <param name="bodyBytes">bodyBytes</param>
        /// <returns></returns>
        public static BlockBody From(BlockHeader blockHeader, Memory<Byte> bodyBytes)
        {
            switch (blockHeader.Type)
            {
                case BlockType.SectionHeader:
                    return new SectionHeaderBlock
                    {
                        IsLittleEndian = blockHeader.IsLittleEndian,
                        Bytes = bodyBytes
                    };
                case BlockType.InterfaceDescription:
                    return new InterfaceDescriptionBlock
                    {
                        IsLittleEndian = blockHeader.IsLittleEndian,
                        Bytes = bodyBytes
                    };
                default:
                    return new BlockBody
                    {
                        IsLittleEndian = blockHeader.IsLittleEndian,
                        Bytes = bodyBytes
                    };
            }
        }
    }
}
