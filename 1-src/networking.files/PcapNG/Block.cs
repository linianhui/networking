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
            set { base.SetUInt32(Layout.TypeBegin, (UInt32)value); }
        }

        /// <summary>
        /// Total Length
        /// </summary>
        public UInt32 TotalLength
        {
            get { return base.GetUInt32(Layout.TotalLengthBegin); }
            set { base.SetUInt32(Layout.TotalLengthBegin, value); }
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
        public Octets Body
        {
            get
            {
                var bodyBytes = base[Layout.BodyBegin, (Int32)BodyLength];
                return new Octets
                {
                    Bytes = bodyBytes
                };
            }
        }
    }
}
