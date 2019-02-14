using System;

namespace Networking.Model.Transport
{
    /// <summary>
    /// 传输控制协议
    /// <see href="https://en.wikipedia.org/wiki/transmission_control_protocol"/>
    /// </summary>
    public partial class TCPSegment : TransportPDU
    {
        /// <summary>
        /// 源端口
        /// </summary>
        public UInt16 SourcePort
        {
            get
            {
                return ReadUInt16(Layout.SourcePortBegin);
            }
            set
            {
                WriteUInt16(Layout.SourcePortBegin, value);
            }
        }

        /// <summary>
        /// 目标端口
        /// </summary>
        public UInt16 DestinationPort
        {
            get
            {
                return ReadUInt16(Layout.DestinationPortBegin);
            }
            set
            {
                WriteUInt16(Layout.DestinationPortBegin, value);
            }
        }

        /// <summary>
        /// 序列号
        /// </summary>
        public UInt32 SYNNumber
        {
            get
            {
                return ReadUInt32(Layout.SYNNumberBegin);
            }
            set
            {
                WriteUInt32(Layout.SYNNumberBegin, value);
            }
        }

        /// <summary>
        /// 确认号
        /// </summary>
        public UInt32 ACKNumber
        {
            get
            {
                return ReadUInt32(Layout.ACKNumberBegin);
            }
            set
            {
                WriteUInt32(Layout.ACKNumberBegin, value);
            }
        }

        /// <summary>
        /// 首部长度，单位4 octets
        /// </summary>
        public Byte HeaderLength
        {
            get { return base.GetByte(Layout.HeaderLengthBegin, 0, 4); }
            set
            {
                var old = base.GetByte(Layout.HeaderLengthBegin);
                base.SetByte(Layout.HeaderLengthBegin, (Byte)(((Byte)value) << 4 | old & Bits.B_0000_1111));
            }
        }

        /// <summary>
        /// ECN-nonce
        /// </summary>
        public Boolean FlagNS
        {
            get { return base.GetBit(Layout.HeaderLengthBegin, Layout.FlagsNSBitIndex); }
            set { base.SetBit(Layout.HeaderLengthBegin, Layout.FlagsNSBitIndex, value); }
        }

        /// <summary>
        /// Congestion Window Reduced
        /// </summary>
        public Boolean FlagCWR
        {
            get { return base.GetBit(Layout.FlagsBegin, Layout.FlagsCWRBitIndex); }
            set { base.SetBit(Layout.FlagsBegin, Layout.FlagsCWRBitIndex, value); }
        }

        /// <summary>
        /// ECE-Echo
        /// </summary>
        public Boolean FlagECE
        {
            get { return base.GetBit(Layout.FlagsBegin, Layout.FlagsECEBitIndex); }
            set { base.SetBit(Layout.FlagsBegin, Layout.FlagsECEBitIndex, value); }
        }

        /// <summary>
        /// Urgent pointer
        /// </summary>
        public Boolean FlagURG
        {
            get { return base.GetBit(Layout.FlagsBegin, Layout.FlagsURGBitIndex); }
            set { base.SetBit(Layout.FlagsBegin, Layout.FlagsURGBitIndex, value); }
        }

        /// <summary>
        /// Acknowledgment
        /// </summary>
        public Boolean FlagACK
        {
            get { return base.GetBit(Layout.FlagsBegin, Layout.FlagsACKBitIndex); }
            set { base.SetBit(Layout.FlagsBegin, Layout.FlagsACKBitIndex, value); }
        }

        /// <summary>
        /// Push function
        /// </summary>
        public Boolean FlagPSH
        {
            get { return base.GetBit(Layout.FlagsBegin, Layout.FlagsPSHBitIndex); }
            set { base.SetBit(Layout.FlagsBegin, Layout.FlagsPSHBitIndex, value); }
        }

        /// <summary>
        /// Reset the connection
        /// </summary>
        public Boolean FlagRST
        {
            get { return base.GetBit(Layout.FlagsBegin, Layout.FlagsRSTBitIndex); }
            set { base.SetBit(Layout.FlagsBegin, Layout.FlagsRSTBitIndex, value); }
        }

        /// <summary>
        /// Synchronize sequence number
        /// </summary>
        public Boolean FlagSYN
        {
            get { return base.GetBit(Layout.FlagsBegin, Layout.FlagsSYNBitIndex); }
            set { base.SetBit(Layout.FlagsBegin, Layout.FlagsSYNBitIndex, value); }
        }

        /// <summary>
        /// Last packet from sender
        /// </summary>
        public Boolean FlagFIN
        {
            get { return base.GetBit(Layout.FlagsBegin, Layout.FlagsFINBitIndex); }
            set { base.SetBit(Layout.FlagsBegin, Layout.FlagsFINBitIndex, value); }
        }

        /// <summary>
        /// 窗口大小
        /// </summary>
        public UInt16 WindowsSize
        {
            get
            {
                return ReadUInt16(Layout.WindowsSizeBegin);
            }
            set
            {
                WriteUInt16(Layout.WindowsSizeBegin, value);
            }
        }

        /// <summary>
        /// 校验和
        /// </summary>
        public UInt16 Checksum
        {
            get
            {
                return ReadUInt16(Layout.ChecksumBegin);
            }
            set
            {
                WriteUInt16(Layout.ChecksumBegin, value);
            }
        }

        /// <summary>
        /// 紧急指针
        /// </summary>
        public UInt16 UrgentPointer
        {
            get
            {
                return ReadUInt16(Layout.UrgentPointerBegin);
            }
            set
            {
                WriteUInt16(Layout.UrgentPointerBegin, value);
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
                    Bytes = Slice(HeaderLength * 4)
                };

            }
        }
    }
}
