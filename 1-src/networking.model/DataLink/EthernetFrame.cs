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
                    Bytes = base[Structure.DestinationMACAddressBegin, Structure.MACAddressLength]
                };
            }
            set
            {
                base[Structure.DestinationMACAddressBegin, Structure.MACAddressLength] = value.Bytes;
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
                    Bytes = base[Structure.SourceMACAddressBegin, Structure.MACAddressLength]
                };
            }
            set
            {
                base[Structure.SourceMACAddressBegin, Structure.MACAddressLength] = value.Bytes;
            }
        }

        /// <summary>
        /// 类型
        /// </summary>
        public EthernetFrameType Type
        {
            get
            {
                return (EthernetFrameType)ReadUInt16BigEndian(Structure.TypeBegin);
            }
        }
    }
}
