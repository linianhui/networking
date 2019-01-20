using System;

namespace Networking.Model.DataLink
{
    /// <summary>
    /// Ethernet II(DIX) Frame
    /// <see href="https://en.wikipedia.org/wiki/ethernet_frame"/>
    /// </summary>
    public partial class EthernetFrame : DataLinkFrame
    {
        /// <summary>
        /// 目标MAC地址
        /// </summary>
        public MACAddress DestinationMACAddress
        {
            get
            {
                return new MACAddress
                {
                    Bytes = base[Layout.DestinationMACAddressBegin, MACAddress.Layout.Length]
                };
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
                return new MACAddress
                {
                    Bytes = base[Layout.SourceMACAddressBegin, MACAddress.Layout.Length]
                };
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
                return (EthernetFrameType)ReadAsUInt16FromBigEndian(Layout.TypeBegin);
            }
        }

        /// <summary>
        /// 负载信息
        /// </summary>
        public Octets Payload
        {
            get
            {
                if (Type == EthernetFrameType.ARP)
                {
                    return new ARPFrame
                    {
                        Bytes = Read(Layout.HeaderLength)
                    };
                }

                return new Octets
                {
                    Bytes = Read(Layout.HeaderLength)
                };
            }
        }
    }
}
