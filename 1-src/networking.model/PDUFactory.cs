using System;
using System.Collections.Generic;
using Networking.Model.Application;
using Networking.Model.DataLink;
using Networking.Model.Internet;
using Networking.Model.Transport;

namespace Networking.Model
{
    /// <summary>
    /// PDU 创建者
    /// </summary>
    public static class PDUFactory
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
        /// IPPacketType
        /// </summary>
        public static readonly IDictionary<IPPacketType, Func<Memory<Byte>, Octets>> IPPacketTypeMap = new Dictionary<IPPacketType, Func<Memory<Byte>, Octets>>
        {
            [IPPacketType.ICMPv4] = bytes => new ICMPv4Packet { Bytes = bytes },
            [IPPacketType.TCP] = bytes => new TCPSegment { Bytes = bytes },
            [IPPacketType.UDP] = bytes => new UDPDatagram { Bytes = bytes }
        };


        /// <summary>
        /// PPPFrameType
        /// </summary>
        public static readonly IDictionary<PPPFrameType, Func<Memory<Byte>, Octets>> PPPFrameTypeMap = new Dictionary<PPPFrameType, Func<Memory<Byte>, Octets>>
        {
            [PPPFrameType.IPv4] = bytes => new IPv4Packet { Bytes = bytes },
            [PPPFrameType.IPv6] = bytes => new IPv6Packet { Bytes = bytes }
        };

        /// <summary>
        /// EthernetFrameType
        /// </summary>
        public static readonly IDictionary<EthernetFrameType, Func<Memory<Byte>, Octets>> EthernetFrameTypeMap = new Dictionary<EthernetFrameType, Func<Memory<Byte>, Octets>>
        {
            [EthernetFrameType.IPv4] = bytes => new IPv4Packet { Bytes = bytes },
            [EthernetFrameType.IPv6] = bytes => new IPv6Packet { Bytes = bytes },
            [EthernetFrameType.ARP] = bytes => new ARPFrame { Bytes = bytes },
            [EthernetFrameType.VLAN] = bytes => new VLANFrame { Bytes = bytes },
            [EthernetFrameType.PPPoEDiscoveryStage] = bytes => new PPPoEFrame { Bytes = bytes },
            [EthernetFrameType.PPPoESessionStage] = bytes => new PPPoEFrame { Bytes = bytes },
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

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="ipPacketType">ipPacketType</param>
        /// <param name="bytes">数据</param>
        /// <returns></returns>
        public static Octets Create(IPPacketType ipPacketType, Memory<Byte> bytes)
        {
            if (IPPacketTypeMap.ContainsKey(ipPacketType))
            {
                return IPPacketTypeMap[ipPacketType](bytes);
            }

            return Default(bytes);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="pppFrameType">ipPacketType</param>
        /// <param name="bytes">数据</param>
        /// <returns></returns>
        public static Octets Create(PPPFrameType pppFrameType, Memory<Byte> bytes)
        {
            if (PPPFrameTypeMap.ContainsKey(pppFrameType))
            {
                return PPPFrameTypeMap[pppFrameType](bytes);
            }

            return Default(bytes);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="ethernetFrameType">ethernetFrameType</param>
        /// <param name="bytes">数据</param>
        /// <returns></returns>
        public static Octets Create(EthernetFrameType ethernetFrameType, Memory<Byte> bytes)
        {
            if (EthernetFrameTypeMap.ContainsKey(ethernetFrameType))
            {
                return EthernetFrameTypeMap[ethernetFrameType](bytes);
            }

            return Default(bytes);
        }
    }
}
