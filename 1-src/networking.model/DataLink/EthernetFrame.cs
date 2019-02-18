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
        /// 目标MAC地址
        /// </summary>
        public MACAddress DestinationMACAddress
        {
            get { return GetMAC(Layout.DestinationMACAddressBegin); }
            set { SetMAC(Layout.DestinationMACAddressBegin, value); }
        }

        /// <summary>
        /// 源MAC地址
        /// </summary>
        public MACAddress SourceMACAddress
        {
            get { return GetMAC(Layout.SourceMACAddressBegin); }
            set { SetMAC(Layout.SourceMACAddressBegin, value); }
        }

        /// <summary>
        /// 类型
        /// </summary>
        public EthernetFrameType Type
        {
            get { return (EthernetFrameType)GetUInt16(Layout.TypeBegin); }
            set { SetUInt16(Layout.TypeBegin, (UInt16)value); }
        }

        /// <summary>
        /// 负载信息
        /// </summary>
        public Octets Payload
        {
            get
            {
                switch (Type)
                {

                    case EthernetFrameType.IPv4:
                        return new IPv4Packet
                        {
                            Bytes = Slice(Layout.HeaderLength)
                        };
                    case EthernetFrameType.IPv6:
                        return new IPv6Packet
                        {
                            Bytes = Slice(Layout.HeaderLength)
                        };
                    case EthernetFrameType.ARP:
                        return new ARPFrame
                        {
                            Bytes = Slice(Layout.HeaderLength)
                        };
                    case EthernetFrameType.PPPoEDiscoveryStage:
                    case EthernetFrameType.PPPoESessionStage:
                        return new PPPoEFrame
                        {
                            Bytes = Slice(Layout.HeaderLength)
                        };
                    default:
                        return new Octets
                        {
                            Bytes = Slice(Layout.HeaderLength)
                        };
                }
            }
        }
    }
}
