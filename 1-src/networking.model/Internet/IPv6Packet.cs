using System;

namespace Networking.Model.Internet
{
    /// <summary>
    /// IPv6-Packet
    /// <see href="https://en.wikipedia.org/wiki/IPv6"/>
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
        /// Traffic Class
        /// </summary>
        public UInt16 TrafficClass
        {
            get { return base.GetUInt16(Layout.TrafficClassBegin, Layout.TrafficClassBitIndex, Layout.TrafficClassBitLength); }
            set { base.SetUInt16(Layout.TrafficClassBegin, Layout.TrafficClassBitIndex, Layout.TrafficClassBitLength, value); }
        }

        /// <summary>
        /// Flow Label
        /// </summary>
        public UInt32 FlowLabel
        {
            get { return base.GetUInt32(Layout.FlowLabelBegin, Layout.FlowLabelBitIndex, Layout.FlowLabelBitLength); }
            set { base.SetUInt32(Layout.FlowLabelBegin, Layout.FlowLabelBitIndex, Layout.FlowLabelBitLength, value); }
        }

        /// <summary>
        /// 负载部分长度
        /// </summary>
        public UInt16 PayloadLength
        {
            get { return GetUInt16(Layout.PayloadLengthBegin); }
            set { SetUInt16(Layout.PayloadLengthBegin, value); }
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
            get { return this.GetIPv6(Layout.SourceIPAddressBegin); }
            set { this.SetIPv6(Layout.SourceIPAddressBegin, value); }
        }


        /// <summary>
        /// 目标IP地址
        /// </summary>
        public IPAddress DestinationIPAddress
        {
            get { return this.GetIPv6(Layout.DestinationIPAddressBegin); }
            set { this.SetIPv6(Layout.DestinationIPAddressBegin, value); }
        }


        /// <summary>
        /// 负载信息
        /// </summary>
        public Octets Payload
        {
            get
            {
                var payloadBytes = GetBytes(Layout.HeaderLength);
                return new Octets
                {
                    Bytes = payloadBytes
                };
            }
        }

    }
}
