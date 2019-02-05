using System;

namespace Networking.Model.Transport
{
    /// <summary>
    /// 传输层
    /// <see href="https://en.wikipedia.org/wiki/transport_layer"/>
    /// <see href="https://en.wikipedia.org/wiki/datagram"/>
    /// </summary>
    public class TransportPDU : Octets
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public TransportPDU(Memory<byte> bytes) : base(bytes)
        {
        }
    }
}
