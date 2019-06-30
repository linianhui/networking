using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// General Block
    /// <see href="https://pcapng.github.io/pcapng/#rfc.section.3.1"/>
    /// </summary>
    public partial class Block : Octets
    {
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
        /// Body
        /// </summary>
        public BlockBody Body
        {
            get
            {
                var bodyBytes = base[Layout.BodyBegin, (Int32)BodyLength];
                switch (Type)
                {
                    case BlockType.SectionHeader:
                        return new SectionHeaderBody
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
}
