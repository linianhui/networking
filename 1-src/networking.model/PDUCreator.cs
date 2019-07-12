using System;
using System.Collections.Generic;
using Networking.Model.Application;

namespace Networking.Model
{
    /// <summary>
    /// PDU 创建者
    /// </summary>
    public static class PDUCreator
    {
        /// <summary>
        /// 默认
        /// </summary>
        public static readonly Func<Memory<Byte>, Octets> Default = bytes => new Octets { Bytes = bytes };

        /// <summary>
        /// 端口号
        /// </summary>
        public static readonly IDictionary<UInt16, Func<Memory<Byte>, Octets>> PortMap = new Dictionary<UInt16, Func<Memory<Byte>, Octets>>
        {
            [CoAP.ServerPort] = bytes => new CoAP { Bytes = bytes },
            [DHCP.ClientPort] = bytes => new DHCP { Bytes = bytes },
            [DHCP.ServerPort] = bytes => new DHCP { Bytes = bytes },
            [DNS.ServerPort] = bytes => new DNS { Bytes = bytes },
            [MQTT.ServerPort] = bytes => new MQTT { Bytes = bytes },
            [MQTT.ServerTLSPort] = bytes => new MQTT { Bytes = bytes },
            [VXLAN.ServerPort] = bytes => new VXLAN { Bytes = bytes }
        };



        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="sourcePort">源端口号</param>
        /// <param name="destinationPort">目标端口号</param>
        /// <param name="bytes">数据</param>
        /// <returns></returns>
        public static Octets Create(UInt16 sourcePort, UInt16 destinationPort, Memory<Byte> bytes)
        {
            if (PortMap.ContainsKey(sourcePort))
            {
                return PortMap[sourcePort](bytes);
            }

            if (PortMap.ContainsKey(destinationPort))
            {
                return PortMap[destinationPort](bytes);
            }

            return Default(bytes);
        }
    }
}
