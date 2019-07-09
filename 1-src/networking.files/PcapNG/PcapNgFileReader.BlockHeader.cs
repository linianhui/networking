using System;
using System.Collections.Generic;
using System.Text;

namespace Networking.Files.PcapNG
{
    public partial class PcapNGFileReader
    {
        /// <summary>
        /// 
        /// </summary>
        private class BlockHeader : Octets
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

                var header = new BlockHeader { Bytes = headerBytes };
                if (header.Type == BlockType.SectionHeader)
                {
                    header.IsLittleEndian = header.GetByte(8) == 0x4D;
                }

                return header;
            }
        }
    }
}
