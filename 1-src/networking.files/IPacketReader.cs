using System.Collections.Generic;

namespace Networking.Files
{
    /// <summary>
    /// Packet Reader
    /// </summary>
    public interface IPacketReader
    {
        /// <summary>
        /// 读取所有数据包
        /// </summary>
        IEnumerable<IPacket> ReadPackets();
    }
}
