using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// Interface Description Body
    /// <see href="https://pcapng.github.io/pcapng/#section_idb"/>
    /// </summary>
    public partial class InterfaceDescriptionBody : BlockBody
    {
        /// <summary>
        /// 数据链路类型
        /// </summary>
        public DataLinkType Type
        {
            get { return (DataLinkType)GetUInt16(Layout.DataLinkTypeBegin); }
        }

        /// <summary>
        /// 数据包最大长度
        /// </summary>
        public UInt32 MaxCapturedLength
        {
            get { return GetUInt32(Layout.MaxCapturedLengthBegin); }
        }
    }
}
