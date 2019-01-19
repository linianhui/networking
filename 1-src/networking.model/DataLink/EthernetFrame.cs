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
                    Bytes = base[Layout.DestinationMACAddressBegin, Layout.MACAddressLength]
                };
            }
            set
            {
                base[Layout.DestinationMACAddressBegin, Layout.MACAddressLength] = value.Bytes;
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
                    Bytes = base[Layout.SourceMACAddressBegin, Layout.MACAddressLength]
                };
            }
            set
            {
                base[Layout.SourceMACAddressBegin, Layout.MACAddressLength] = value.Bytes;
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
    }
}
