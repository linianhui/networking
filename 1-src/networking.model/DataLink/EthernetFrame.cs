using System;

namespace Networking.Model.DataLink
{
    /// <summary>
    ///
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
                    Bytes = Read(Structure.DestinationMACAddressBegin, Structure.MACAddressLength)
                };
            }
            set
            {
                Write(Structure.DestinationMACAddressBegin, Structure.MACAddressLength, value.Bytes);
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
                    Bytes = Read(Structure.SourceMACAddressBegin, Structure.MACAddressLength)
                };
            }
            set
            {
                Write(Structure.SourceMACAddressBegin, Structure.MACAddressLength, value.Bytes);
            }
        }
    }
}
