using System;

namespace Networking.Model.Internet
{
    /// <summary>
    /// IPv6-Packet
    /// <see href="https://en.wikipedia.org/wiki/ipv6"/>
    /// </summary>
    public partial class IPv6Packet : InternetPDU
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
        /// 负载部分长度
        /// </summary>
        public UInt16 PayloadLength
        {
            get
            {
                return GetUInt16(Layout.PayloadLengthBegin);
            }
            set
            {
                SetUInt16(Layout.PayloadLengthBegin, value);
            }
        }

        /// <summary>
        /// 下一个首部
        /// </summary>
        public Byte NextHeader
        {
            get { return base.GetByte(Layout.NextHeaderBegin); }
            set { base.SetByte(Layout.NextHeaderBegin, value); }
        }

        /// <summary>
        /// 跳数限制
        /// </summary>
        public Byte HopLimit
        {
            get { return base.GetByte(Layout.HopLimitBegin); }
            set { base.SetByte(Layout.HopLimitBegin, value); }
        }

        /// <summary>
        /// 源IP地址
        /// </summary>
        public IPAddress SourceIPAddress
        {
            get
            {
                return new IPAddress
                {
                    Bytes = base[Layout.SourceIPAddressBegin, IPAddress.Layout.V6Length]
                };
            }
            set
            {
                base[Layout.SourceIPAddressBegin, IPAddress.Layout.V6Length] = value.Bytes;
            }
        }


        /// <summary>
        /// 目标IP地址
        /// </summary>
        public IPAddress DestinationIPAddress
        {
            get
            {
                return new IPAddress
                {
                    Bytes = base[Layout.DestinationIPAddressBegin, IPAddress.Layout.V6Length]
                };
            }
            set
            {
                base[Layout.DestinationIPAddressBegin, IPAddress.Layout.V6Length] = value.Bytes;
            }
        }


        /// <summary>
        /// 负载信息
        /// </summary>
        public Octets Payload
        {
            get
            {

                return new Octets
                {
                    Bytes = Slice(Layout.HeaderLength)
                };

            }
        }

    }
}
