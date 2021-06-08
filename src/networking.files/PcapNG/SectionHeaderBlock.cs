using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// Section Header Block
    /// <see href="https://pcapng.github.io/pcapng/#section_shb"/>
    /// </summary>
    public partial class SectionHeaderBlock : Block
    {
        /// <summary>
        /// Magic Number
        /// </summary>
        public UInt32 MagicNumber
        {
            get { return GetUInt32(Layout.MagicNumberBegin); }
        }

        /// <summary>
        /// Major Version
        /// </summary>
        public UInt16 MajorVersion
        {
            get { return GetUInt16(Layout.MajorVersionBegin); }
        }

        /// <summary>
        /// Minor Version
        /// </summary>
        public UInt16 MinorVersion
        {
            get { return GetUInt16(Layout.MinorVersionBegin); }
        }

        /// <summary>
        /// 数据包最大长度
        /// </summary>
        public UInt32 SectionLength
        {
            get { return GetUInt32(Layout.SectionLengthBegin); }
        }
    }
}
