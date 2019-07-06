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
        DataLinkType Type { get; }

        /// <summary>
        /// 数据包
        /// </summary>
        Memory<Byte> Data { get; }

        /// <summary>
        /// UNIX时间戳-纳秒
        /// </summary>
        UInt64 TimestampNanosecond { get; }
    }
}
