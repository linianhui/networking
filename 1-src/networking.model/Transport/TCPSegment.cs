using System;

namespace Networking.Model.Transport
{
    /// <summary>
    /// 传输控制协议
    /// <see href="https://en.wikipedia.org/wiki/Transmission_Control_Protocol"/>
    /// </summary>
    public partial class TCPSegment : TransportPDU
    {
        /// <summary>
        /// 源端口
        /// </summary>
        public UInt16 SourcePort
        {
            get { return GetUInt16(Layout.SourcePortBegin); }
            set { SetUInt16(Layout.SourcePortBegin, value); }
        }

        /// <summary>
        /// 目标端口
        /// </summary>
        public UInt16 DestinationPort
        {
            get { return GetUInt16(Layout.DestinationPortBegin); }
            set { SetUInt16(Layout.DestinationPortBegin, value); }
        }

        /// <summary>
        /// 序列号
        /// </summary>
        public UInt32 SequenceNumber
        {
            get { return GetUInt32(Layout.SequenceNumberBegin); }
            set { SetUInt32(Layout.SequenceNumberBegin, value); }
        }

        /// <summary>
        /// 确认号
        /// </summary>
        public UInt32 AcknowledgmentNumber
        {
            get { return GetUInt32(Layout.AcknowledgmentNumberBegin); }
            set { SetUInt32(Layout.AcknowledgmentNumberBegin, value); }
        }

        /// <summary>
        /// 首部长度，单位4 octets
        /// </summary>
        public Byte HeaderLength
        {
            get { return base.GetByte(Layout.HeaderLengthBegin, 0, 4); }
            set { base.SetByte(Layout.HeaderLengthBegin, 0, 4, value); }
        }

        /// <summary>
        /// ECN-nonce
        /// </summary>
        public Boolean FlagNS
        {
            get { return base.GetBoolean(Layout.HeaderLengthBegin, Layout.FlagsNSBitIndex); }
            set { base.SetBoolean(Layout.HeaderLengthBegin, Layout.FlagsNSBitIndex, value); }
        }

        /// <summary>
        /// Congestion Window Reduced
        /// </summary>
        public Boolean FlagCWR
        {
            get { return base.GetBoolean(Layout.FlagsBegin, Layout.FlagsCWRBitIndex); }
            set { base.SetBoolean(Layout.FlagsBegin, Layout.FlagsCWRBitIndex, value); }
        }

        /// <summary>
        /// ECE-Echo
        /// </summary>
        public Boolean FlagECE
        {
            get { return base.GetBoolean(Layout.FlagsBegin, Layout.FlagsECEBitIndex); }
            set { base.SetBoolean(Layout.FlagsBegin, Layout.FlagsECEBitIndex, value); }
        }

        /// <summary>
        /// Urgent pointer
        /// </summary>
        public Boolean FlagURG
        {
            get { return base.GetBoolean(Layout.FlagsBegin, Layout.FlagsURGBitIndex); }
            set { base.SetBoolean(Layout.FlagsBegin, Layout.FlagsURGBitIndex, value); }
        }

        /// <summary>
        /// Acknowledgment
        /// </summary>
        public Boolean FlagACK
        {
            get { return base.GetBoolean(Layout.FlagsBegin, Layout.FlagsACKBitIndex); }
            set { base.SetBoolean(Layout.FlagsBegin, Layout.FlagsACKBitIndex, value); }
        }

        /// <summary>
        /// Push function
        /// </summary>
        public Boolean FlagPSH
        {
            get { return base.GetBoolean(Layout.FlagsBegin, Layout.FlagsPSHBitIndex); }
            set { base.SetBoolean(Layout.FlagsBegin, Layout.FlagsPSHBitIndex, value); }
        }

        /// <summary>
        /// Reset the connection
        /// </summary>
        public Boolean FlagRST
        {
            get { return base.GetBoolean(Layout.FlagsBegin, Layout.FlagsRSTBitIndex); }
            set { base.SetBoolean(Layout.FlagsBegin, Layout.FlagsRSTBitIndex, value); }
        }

        /// <summary>
        /// Synchronize sequence number
        /// </summary>
        public Boolean FlagSYN
        {
            get { return base.GetBoolean(Layout.FlagsBegin, Layout.FlagsSYNBitIndex); }
            set { base.SetBoolean(Layout.FlagsBegin, Layout.FlagsSYNBitIndex, value); }
        }

        /// <summary>
        /// Last packet from sender
        /// </summary>
        public Boolean FlagFIN
        {
            get { return base.GetBoolean(Layout.FlagsBegin, Layout.FlagsFINBitIndex); }
            set { base.SetBoolean(Layout.FlagsBegin, Layout.FlagsFINBitIndex, value); }
        }

        /// <summary>
        /// 窗口大小
        /// </summary>
        public UInt16 WindowsSize
        {
            get { return GetUInt16(Layout.WindowsSizeBegin); }
            set { SetUInt16(Layout.WindowsSizeBegin, value); }
        }

        /// <summary>
        /// 校验和
        /// </summary>
        public UInt16 Checksum
        {
            get { return GetUInt16(Layout.ChecksumBegin); }
            set { SetUInt16(Layout.ChecksumBegin, value); }
        }

        /// <summary>
        /// 紧急指针
        /// </summary>
        public UInt16 UrgentPointer
        {
            get { return GetUInt16(Layout.UrgentPointerBegin); }
            set { SetUInt16(Layout.UrgentPointerBegin, value); }
        }

        /// <summary>
        /// 负载信息
        /// </summary>
        public Octets Payload
        {
            get
            {
                var payloadBytes = GetBytes(HeaderLength * 4);
                return new Octets
                {
                    Bytes = payloadBytes
                };
            }
        }
    }
}
