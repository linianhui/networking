using System;

namespace Networking.Model.DataLink
{
    /// <summary>
    /// 数据链路层[Frame]
    /// <see href="https://en.wikipedia.org/wiki/data_link_layer"/>
    /// <see href="https://en.wikipedia.org/wiki/frame_(networking)"/>
    /// </summary>
    public class DataLinkPDU : Octets
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DataLinkPDU(Memory<byte> bytes) : base(bytes)
        {
        }
    }
}
