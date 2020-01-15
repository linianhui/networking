using System;

namespace Networking.Model.DataLink
{
    /// <summary>
    /// Ethernet II(DIX) Frame
    /// <see href="https://en.wikipedia.org/wiki/Ethernet_frame"/>
    /// </summary>
    public partial class EthernetFrame : DataLinkPDU
    {
        /// <summary>
        /// 目标MAC地址
        /// </summary>
        public MACAddress DestinationMACAddress
        {
            get { return this.GetMAC(Layout.DestinationMACAddressBegin); }
            set { this.SetMAC(Layout.DestinationMACAddressBegin, value); }
        }

        /// <summary>
        /// 源MAC地址
        /// </summary>
        public MACAddress SourceMACAddress
        {
            get { return this.GetMAC(Layout.SourceMACAddressBegin); }
            set { this.SetMAC(Layout.SourceMACAddressBegin, value); }
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
                return PDUFactory.Create(Type, GetBytes(Layout.HeaderLength));
            }
        }
    }
}
