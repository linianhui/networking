using System;
using Networking.Model.Internet;

namespace Networking.Model.DataLink
{
    /// <summary>
    /// Ethernet II(DIX) Frame
    /// <see href="https://en.wikipedia.org/wiki/ethernet_frame"/>
    /// </summary>
    public partial class EthernetFrame : DataLinkPDU
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public EthernetFrame(Memory<byte> bytes) : base(bytes)
        {
        }

        /// <summary>
        /// 目标MAC地址
        /// </summary>
        public MACAddress DestinationMACAddress
        {
            get
            {
                return new MACAddress(base[Layout.DestinationMACAddressBegin, MACAddress.Layout.Length]);
            }
            set
            {
                base[Layout.DestinationMACAddressBegin, MACAddress.Layout.Length] = value.Bytes;
            }
        }

        /// <summary>
        /// 源MAC地址
        /// </summary>
        public MACAddress SourceMACAddress
        {
            get
            {
                return new MACAddress(base[Layout.SourceMACAddressBegin, MACAddress.Layout.Length]);
            }
            set
            {
                base[Layout.SourceMACAddressBegin, MACAddress.Layout.Length] = value.Bytes;
            }
        }

        /// <summary>
        /// 类型
        /// </summary>
        public EthernetFrameType Type
        {
            get
            {
                return (EthernetFrameType)ReadUInt16(Layout.TypeBegin);
            }
            set
            {
                WriteUInt16(Layout.TypeBegin, (UInt16)value);
            }
        }

        /// <summary>
        /// 负载信息
        /// </summary>
        public Octets Payload
        {
            get
            {
                Memory<byte> payloadBytes = Slice(Layout.HeaderLength);
                switch (Type)
                {
                    case EthernetFrameType.IPv4:
                        return new IPv4Packet(payloadBytes);
                    case EthernetFrameType.IPv6:
                        return new IPv6Packet(payloadBytes);
                    case EthernetFrameType.ARP:
                        return new ARPFrame(payloadBytes);
                    case EthernetFrameType.PPPoEDiscoveryStage:
                    case EthernetFrameType.PPPoESessionStage:
                        return new PPPoEFrame(payloadBytes);
                    default:
                        return new Octets(payloadBytes);
                }
            }
        }
    }
}
