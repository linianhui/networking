using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// Simple Packet Block
    /// <see href="https://pcapng.github.io/pcapng/#section_spb"/>
    /// </summary>
    public partial class SimplePacketBlock : Block, IPacket
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SimplePacketBlock()
        {
            base.IsPacket = true;
        }

        /// <summary>
        /// Interface Id
        /// </summary>
        public override UInt32? InterfaceId
        {
            get { return 0; }
        }

        /// <summary>
        /// 原始长度
        /// </summary>
        public UInt32 OriginalLength
        {
            get { return GetUInt32(Layout.OriginalLengthBegin); }
        }

        /// <summary>
        /// <see cref="IPacket.DataLinkType"/>
        /// </summary>
        public PacketDataLinkType DataLinkType
        {
            get { return InterfaceDescription.DataLinkType; }
        }

        /// <summary>
        /// <see cref="IPacket.TimestampNanosecond"/>
        /// </summary>
        public UInt64 TimestampNanosecond
        {
            get { return 0; }
        }

        /// <summary>
        /// <see cref="IPacket.Payload"/>
        /// </summary>
        public Memory<Byte> Payload
        {
            get { return GetBytes(Layout.HeaderLength, (Int32)TotalLength - Layout.HeaderTotalLength); }
        }
    }
}
