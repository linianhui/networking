using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// Simple Packet Body
    /// <see href="https://pcapng.github.io/pcapng/#section_spb"/>
    /// </summary>
    public partial class SimplePacketBody : BlockBody
    {
        /// <summary>
        /// 原始长度
        /// </summary>
        public UInt32 OriginalLength
        {
            get { return GetUInt32(Layout.OriginalLengthBegin); }
        }

        /// <summary>
        /// 负载信息
        /// </summary>
        public Memory<Byte> Data
        {
            get { return GetBytes(Layout.HeaderLength); }
        }
    }
}
