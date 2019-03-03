using System;
using Networking.Model.Application;

namespace Networking.Model.Transport
{
    /// <summary>
    /// 用户数据报协议
    /// <see href="https://en.wikipedia.org/wiki/User_Datagram_Protocol"/>
    /// </summary>
    public partial class UDPDatagram : TransportPDU
    {
        /// <summary>
        /// 源端口
        /// </summary>
        public UInt16 SourcePort
        {
            get { return GetUInt16(Layout.SourcePortBegin); }
            set { SetUInt16(Layout.SourcePortBegin, value); }
        }

        /// <summary>
        /// 目标端口
        /// </summary>
        public UInt16 DestinationPort
        {
            get { return GetUInt16(Layout.DestinationPortBegin); }
            set { SetUInt16(Layout.DestinationPortBegin, value); }
        }

        /// <summary>
        /// 总长度
        /// </summary>
        public UInt16 TotalLength
        {
            get { return GetUInt16(Layout.TotalLengthBegin); }
            set { SetUInt16(Layout.TotalLengthBegin, value); }
        }

        /// <summary>
        /// 校验和
        /// </summary>
        public UInt16 Checksum
        {
            get { return GetUInt16(Layout.ChecksumBegin); }
            set { SetUInt16(Layout.ChecksumBegin, value); }
        }

        /// <summary>
        /// 负载信息
        /// </summary>
        public Octets Payload
        {
            get
            {
                var sourcePort = SourcePort;
                var destinationPort = DestinationPort;
                var payloadBytes = GetBytes(Layout.HeaderLength);
                if (DNS.ServerPort == sourcePort
                    || DNS.ServerPort == destinationPort)
                {
                    return new DNS
                    {
                        Bytes = payloadBytes
                    };
                }

                if (DHCP.ServerPort == sourcePort
                    || DHCP.ServerPort == destinationPort
                    || DHCP.ClientPort == sourcePort
                    || DHCP.ClientPort == destinationPort)
                {
                    return new DHCP
                    {
                        Bytes = payloadBytes
                    };
                }

                if (VXLAN.ServerPort == sourcePort
                    || VXLAN.ServerPort == destinationPort)
                {
                    return new VXLAN
                    {
                        Bytes = payloadBytes
                    };
                }


                return new Octets
                {
                    Bytes = payloadBytes
                };
            }
        }
    }
}
