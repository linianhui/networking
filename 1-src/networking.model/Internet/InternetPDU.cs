using System;

namespace Networking.Model.Internet
{
    /// <summary>
    /// 网络层[Packet]
    /// <see href="https://en.wikipedia.org/wiki/internet_layer"/>
    /// <see href="https://en.wikipedia.org/wiki/network_packet"/>
    /// </summary>
    public class InternetPDU : Octets
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public InternetPDU(Memory<byte> bytes) : base(bytes)
        {
        }

    }
}
