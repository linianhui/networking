using System;
using Networking.Model.Transport;

namespace Networking.Model.Internet
{
    /// <summary>
    /// IPv4-Packet
    /// <see href="https://en.wikipedia.org/wiki/ipv4"/>
    /// </summary>
    public partial class IPv4Packet : InternetPDU
    {
        /// <summary>
        /// 版本
        /// </summary>
        public IPVersion Version
        {
            get { return (IPVersion)base.GetByte(Layout.VersionBegin, Layout.VersionBitIndex, Layout.VersionBitLength); }
            set { base.SetByte(Layout.VersionBegin, Layout.VersionBitIndex, Layout.VersionBitLength, (Byte)value); }
        }

        /// <summary>
        /// 首部长度，单位4 octets
        /// </summary>
        public Byte HeaderLength
        {
            get { return GetByte(Layout.HeaderLengthBegin, Layout.HeaderLengthBitIndex, Layout.HeaderLengthBitLength); }
            set { SetByte(Layout.HeaderLengthBegin, Layout.HeaderLengthBitIndex, Layout.HeaderLengthBitLength, value); }
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
        /// Id
        /// </summary>
        public UInt16 Id
        {
            get { return GetUInt16(Layout.IdBegin); }
            set { SetUInt16(Layout.IdBegin, value); }
        }

        /// <summary>
        /// Time to Live
        /// </summary>
        public Byte TTL
        {
            get { return base.GetByte(Layout.TTLBegin); }
            set { base.SetByte(Layout.TTLBegin, value); }
        }

        /// <summary>
        /// 协议类型
        /// </summary>
        public IPPacketType Type
        {
            get { return (IPPacketType)base.GetByte(Layout.TypeBegin); }
            set { base.SetByte(Layout.TypeBegin, (Byte)value); }
        }

        /// <summary>
        /// 首部校验和
        /// </summary>
        public UInt16 HeaderChecksum
        {
            get { return GetUInt16(Layout.HeaderChecksumBegin); }
            set { SetUInt16(Layout.HeaderChecksumBegin, value); }
        }

        /// <summary>
        /// 源IP地址
        /// </summary>
        public IPAddress SourceIPAddress
        {
            get { return GetIPv4(Layout.SourceIPAddressBegin); }
            set { SetIPv4(Layout.SourceIPAddressBegin, value); }
        }

        /// <summary>
        /// 目标IP地址
        /// </summary>
        public IPAddress DestinationIPAddress
        {
            get { return GetIPv4(Layout.DestinationIPAddressBegin); }
            set { SetIPv4(Layout.DestinationIPAddressBegin, value); }
        }

        /// <summary>
        /// 负载信息
        /// </summary>
        public Octets Payload
        {
            get
            {
                var payloadBytes = GetBytes(HeaderLength * 4);
                switch (Type)
                {
                    case IPPacketType.ICMPv4:
                        return new ICMPv4Packet
                        {
                            Bytes = payloadBytes
                        };
                    case IPPacketType.TCP:
                        return new TCPSegment
                        {
                            Bytes = payloadBytes
                        };
                    case IPPacketType.UDP:
                        return new UDPDatagram
                        {
                            Bytes = payloadBytes
                        };
                    default:
                        return new Octets
                        {
                            Bytes = payloadBytes
                        };
                }
            }
        }
    }
}
