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
            get { return (IPVersion)base.GetByte(Layout.VersionBegin, 0, 4); }
            set
            {
                var old = base.GetByte(Layout.VersionBegin);
                base.SetByte(Layout.VersionBegin, (Byte)(((Byte)value) << 4 | old & Bits.B_0000_1111));
            }
        }

        /// <summary>
        /// 首部长度，单位4 octets
        /// </summary>
        public Byte HeaderLength
        {
            get { return base.GetByte(Layout.HeaderLengthBegin, 4, 4); }
            set
            {
                var old = base.GetByte(Layout.HeaderLengthBegin);
                base.SetByte(Layout.HeaderLengthBegin, (Byte)(old & Bits.B_1111_0000 | value & Bits.B_0000_1111));
            }
        }

        /// <summary>
        /// 总长度
        /// </summary>
        public UInt16 TotalLength
        {
            get
            {
                return GetUInt16(Layout.TotalLengthBegin);
            }
            set
            {
                SetUInt16(Layout.TotalLengthBegin, value);
            }
        }

        /// <summary>
        /// Id
        /// </summary>
        public UInt16 Id
        {
            get
            {
                return GetUInt16(Layout.IdBegin);
            }
            set
            {
                SetUInt16(Layout.IdBegin, value);
            }
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
            get
            {
                return GetUInt16(Layout.HeaderChecksumBegin);
            }
            set
            {
                SetUInt16(Layout.HeaderChecksumBegin, value);
            }
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
                    Bytes = base[Layout.SourceIPAddressBegin, IPAddress.Layout.V4Length]
                };
            }
            set
            {
                base[Layout.SourceIPAddressBegin, IPAddress.Layout.V4Length] = value.Bytes;
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
                    Bytes = base[Layout.DestinationIPAddressBegin, IPAddress.Layout.V4Length]
                };
            }
            set
            {
                base[Layout.DestinationIPAddressBegin, IPAddress.Layout.V4Length] = value.Bytes;
            }
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

                    case IPPacketType.ICMPv4:
                        return new ICMPv4Packet
                        {
                            Bytes = Slice(HeaderLength * 4)
                        };
                    case IPPacketType.TCP:
                        return new TCPSegment
                        {
                            Bytes = Slice(HeaderLength * 4)
                        };
                    case IPPacketType.UDP:
                        return new UDPDatagram
                        {
                            Bytes = Slice(HeaderLength * 4)
                        };
                    default:
                        return new Octets
                        {
                            Bytes = Slice(HeaderLength * 4)
                        };
                }
            }
        }

    }
}
