using System;
using Networking.Model.DataLink;
using Networking.Model.Internet;

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

        /// <summary>
        /// 设置<see cref="MACAddress"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="index">索引</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static void SetMAC(this Octets @this, Int32 index, MACAddress value)
        {
            @this[index, MACAddress.Layout.Length] = value.Bytes;
        }

        /// <summary>
        /// 获取IPv4<see cref="IPAddress"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public static IPAddress GetIPv4(this Octets @this, Int32 index)
        {
            return new IPAddress
            {
                Bytes = @this[index, IPAddress.Layout.V4Length]
            };
        }

        /// <summary>
        /// 设置IPv4<see cref="IPAddress"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="index">索引</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static void SetIPv4(this Octets @this, Int32 index, IPAddress value)
        {
            @this[index, IPAddress.Layout.V4Length] = value.Bytes;
        }

        /// <summary>
        /// 获取IPv6<see cref="IPAddress"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public static IPAddress GetIPv6(this Octets @this, Int32 index)
        {
            return new IPAddress
            {
                Bytes = @this[index, IPAddress.Layout.V6Length]
            };
        }
    }
}
