using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// Interface Description Body
    /// <see href="https://pcapng.github.io/pcapng/#section_idb"/>
    /// </summary>
    public partial class InterfaceDescriptionBlock : BlockBody
    {
        /// <summary>
        /// 数据链路类型
        /// </summary>
        public PacketDataLinkType DataLinkType
        {
            get { return (PacketDataLinkType)GetUInt16(Layout.DataLinkTypeBegin); }
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
