using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// Enhanced Packet Block
    /// <see href="https://pcapng.github.io/pcapng/#section_epb"/>
    /// </summary>
    public partial class EnhancedPacketBlock : Block, IPacket
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public EnhancedPacketBlock()
        {
            base.IsPacket = true;
        }

        /// <summary>
        /// Interface Id
        /// </summary>
        public override UInt32? InterfaceId
        {
            get { return GetUInt32(Layout.InterfaceIdBegin); }
        }

        /// <summary>
        /// 捕获长度
        /// </summary>
        public UInt32 CapturedLength
        {
            get { return GetUInt32(Layout.CapturedLengthBegin); }
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
            get
            {
                var bytes = GetBytes(Layout.TimestampHighBegin, Layout.TimestampLowEnd - Layout.TimestampHighBegin);
                return Timestamp.ToTimestampNanosecond(IsLittleEndian, false, bytes.Span);
            }
        }

        /// <summary>
        /// <see cref="IPacket.Payload"/>
        /// </summary>
        public Memory<Byte> Payload
        {
            get { return GetBytes(Layout.HeaderLength, (Int32)CapturedLength); }
        }
    }
}
