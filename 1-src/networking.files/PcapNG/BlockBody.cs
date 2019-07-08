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
        /// <param name="blockType">type</param>
        /// <param name="bodyBytes">bytes</param>
        /// <returns></returns>
        public static BlockBody From(BlockType blockType, Memory<Byte> bodyBytes)
        {
            switch (blockType)
            {
                case BlockType.SectionHeader:
                    return new SectionHeaderBody
                    {
                        Bytes = bodyBytes
                    };
                case BlockType.InterfaceDescription:
                    return new InterfaceDescriptionBody
                    {
                        Bytes = bodyBytes
                    };
                default:
                    return new BlockBody
                    {
                        Bytes = bodyBytes
                    };
            }
        }
    }
}
