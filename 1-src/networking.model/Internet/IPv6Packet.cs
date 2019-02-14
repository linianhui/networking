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
            get { return (IPVersion)(base[Layout.VersionBegin] >> 4); }
            set
            {
                var old = base[Layout.VersionBegin];
                base[Layout.VersionBegin] = (Byte)(((Byte)value) << 4 | old & Bits.B_0000_1111);
            }
        }

        /// <summary>
        /// 负载部分长度
        /// </summary>
        public UInt16 PayloadLength
        {
            get
            {
                return ReadUInt16(Layout.PayloadLengthBegin);
            }
            set
            {
                WriteUInt16(Layout.PayloadLengthBegin, value);
            }
        }

        /// <summary>
        /// 下一个首部
        /// </summary>
        public Byte NextHeader
        {
            get { return base[Layout.NextHeaderBegin]; }
            set { base[Layout.NextHeaderBegin] = value; }
        }

        /// <summary>
        /// 跳数限制
        /// </summary>
        public Byte HopLimit
        {
            get { return base[Layout.HopLimitBegin]; }
            set { base[Layout.HopLimitBegin] = value; }
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
