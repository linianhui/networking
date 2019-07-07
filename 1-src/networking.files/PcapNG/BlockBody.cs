using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// <see cref="Block"/> 的Body
    /// </summary>
    public class BlockBody : Octets
    {
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
