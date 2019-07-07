using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// General Block Header
    /// <see href="https://pcapng.github.io/pcapng/#section_block"/>
    /// </summary>
    public partial class BlockHeader : Octets
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
    }
}
