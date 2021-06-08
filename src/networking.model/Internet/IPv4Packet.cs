using System;

namespace Networking.Model.Internet
{
    /// <summary>
    /// IPv4-Packet
    /// <see href="https://en.wikipedia.org/wiki/Ipv4"/>
    /// </summary>
    public partial class IPv4Packet : InternetPDU
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
        /// 首部长度，单位4 octets
        /// </summary>
        public Byte HeaderLength
        {
            get { return GetByte(Layout.HeaderLengthBegin, Layout.HeaderLengthBitIndex, Layout.HeaderLengthBitLength); }
            set { SetByte(Layout.HeaderLengthBegin, Layout.HeaderLengthBitIndex, Layout.HeaderLengthBitLength, value); }
        }

        /// <summary>
        /// Differentiated Services Code Point
        /// </summary>
        public Byte DSCP
        {
            get { return base.GetByte(Layout.DSCPBegin, Layout.DSCPBitIndex, Layout.DSCPBitLength); }
            set { base.SetByte(Layout.DSCPBegin, Layout.DSCPBitIndex, Layout.DSCPBitLength, value); }
        }

        /// <summary>
        /// Explicit Congestion Notification
        /// </summary>
        public Byte ECN
        {
            get { return base.GetByte(Layout.ECNBegin, Layout.ECNBitIndex, Layout.ECNBitLength); }
            set { base.SetByte(Layout.ECNBegin, Layout.ECNBitIndex, Layout.ECNBitLength, value); }
        }

        /// <summary>
        /// 总长度
        /// </summary>
        public UInt16 TotalLength
        {
            get { return GetUInt16(Layout.TotalLengthBegin); }
            set { SetUInt16(Layout.TotalLengthBegin, value); }
        }

        /// <summary>
        /// Id
        /// </summary>
        public UInt16 Id
        {
            get { return GetUInt16(Layout.IdBegin); }
            set { SetUInt16(Layout.IdBegin, value); }
        }

        /// <summary>
        /// Don't Fragment
        /// </summary>
        public Boolean FlagDF
        {
            get { return base.GetBoolean(Layout.FlagsBegin, Layout.FlagsDFBitIndex); }
            set { base.SetBoolean(Layout.FlagsBegin, Layout.FlagsDFBitIndex, value); }
        }

        /// <summary>
        /// More Fragments
        /// </summary>
        public Boolean FlagMF
        {
            get { return base.GetBoolean(Layout.FlagsBegin, Layout.FlagsMFBitIndex); }
            set { base.SetBoolean(Layout.FlagsBegin, Layout.FlagsMFBitIndex, value); }
        }

        /// <summary>
        /// Fragment Offset
        /// </summary>
        public UInt16 FragmentOffset
        {
            get { return base.GetUInt16(Layout.FragmentOffsetBegin, Layout.FragmentOffsetBitIndex, Layout.FragmentOffsetBitLength); }
            set { base.SetUInt16(Layout.FragmentOffsetBegin, Layout.FragmentOffsetBitIndex, Layout.FragmentOffsetBitLength, value); }
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
            get { return GetUInt16(Layout.HeaderChecksumBegin); }
            set { SetUInt16(Layout.HeaderChecksumBegin, value); }
        }

        /// <summary>
        /// 源IP地址
        /// </summary>
        public IPAddress SourceIPAddress
        {
            get { return this.GetIPv4(Layout.SourceIPAddressBegin); }
            set { this.SetIPv4(Layout.SourceIPAddressBegin, value); }
        }

        /// <summary>
        /// 目标IP地址
        /// </summary>
        public IPAddress DestinationIPAddress
        {
            get { return this.GetIPv4(Layout.DestinationIPAddressBegin); }
            set { this.SetIPv4(Layout.DestinationIPAddressBegin, value); }
        }

        /// <summary>
        /// 负载信息
        /// </summary>
        public Octets Payload
        {
            get
            {
                return PDUFactory.Create(Type, GetBytes(HeaderLength * 4));
            }
        }
    }
}
