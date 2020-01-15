using System;

namespace Networking.Files
{
    /// <summary>
    /// 数据包接口
    /// </summary>
    public interface IPacket
    {
        /// <summary>
        /// 链路层类型
        /// </summary>
        PacketDataLinkType DataLinkType { get; }

        /// <summary>
        /// 有效负载
        /// </summary>
        Memory<Byte> Payload { get; }

        /// <summary>
        /// UNIX时间戳-纳秒
        /// </summary>
        UInt64 TimestampNanosecond { get; }
    }
}
