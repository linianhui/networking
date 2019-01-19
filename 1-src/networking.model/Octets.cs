using System;

namespace Networking.Model
{
    /// <summary>
    /// 八位字节组
    /// <see href="https://en.wikipedia.org/wiki/octet_(computing)"/>
    /// </summary>
    public class Octets
    {
        /// <summary>
        /// 字节数据
        /// </summary>
        public Memory<Byte> Bytes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return BitConverter.ToString(Bytes.ToArray());
        }
    }
}
