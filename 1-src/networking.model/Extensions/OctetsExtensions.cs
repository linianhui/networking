using System;
using Networking.Model.DataLink;

namespace Networking
{
    /// <summary>
    /// <see cref="Octets"/> 的扩展方法
    /// </summary>
    public static class OctetsExtensions
    {
        /// <summary>
        /// 获取<see cref="MACAddress"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public static MACAddress GetMAC(this Octets @this, Int32 index)
        {
            return new MACAddress
            {
                Bytes = @this[index, MACAddress.Layout.Length]
            };
        }
    }
}
