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
            get { return (IPVersion)(base[Layout.VersionBegin] >> 4); }
            set
            {
                var old = base[Layout.VersionBegin];
                base[Layout.VersionBegin] = (Byte)(((Byte)value) << 4 | old & Bits.B_0000_1111);
            }
        }

        /// <summary>
        /// 首部长度，单位4 octets
        /// </summary>
        public Byte HeaderLength
        {
            get { return (Byte)(base[Layout.HeaderLengthBegin] & Bits.B_0000_1111); }
            set
            {
                var old = base[Layout.HeaderLengthBegin];
                base[Layout.HeaderLengthBegin] = (Byte)(old & Bits.B_1111_0000 | value & Bits.B_0000_1111);
            }
        }

        /// <summary>
        /// 总长度
        /// </summary>
        public UInt16 TotalLength
        {
            get
            {
                return ReadUInt16(Layout.TotalLengthBegin);
            }
            set
            {
                WriteUInt16(Layout.TotalLengthBegin, value);
            }
        }

        /// <summary>
        /// Id
        /// </summary>
        public UInt16 Id
        {
            get
            {
                return ReadUInt16(Layout.IdBegin);
            }
            set
            {
                WriteUInt16(Layout.IdBegin, value);
            }
        }

        /// <summary>
        /// Time to Live
        /// </summary>
        public Byte TTL
        {
            get { return base[Layout.TTLBegin]; }
            set { base[Layout.TTLBegin] = value; }
        }

        /// <summary>
        /// 协议类型
        /// </summary>
        public IPPacketType Type
        {
            get { return (IPPacketType)base[Layout.TypeBegin]; }
            set { base[Layout.TypeBegin] = (Byte)value; }
        }

        /// <summary>
        /// 首部校验和
        /// </summary>
        public UInt16 HeaderChecksum
        {
            get
            {
                return ReadUInt16(Layout.HeaderChecksumBegin);
            }
            set
            {
                WriteUInt16(Layout.HeaderChecksumBegin, value);
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
