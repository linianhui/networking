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
            get { return base[Layout.HeaderLengthBegin].GetRange(0, 4); }
            set
            {
                var old = base[Layout.HeaderLengthBegin];
                base[Layout.HeaderLengthBegin] = (Byte)(((Byte)value) << 4 | old & Bits.B_0000_1111);
            }
        }

        /// <summary>
        /// ECN-nonce
        /// </summary>
        public Boolean NS
        {
            get { return base[Layout.HeaderLengthBegin].GetBit(7); }
            set { base[Layout.HeaderLengthBegin] = base[Layout.HeaderLengthBegin].SetBit(7, value); }
        }

        /// <summary>
        /// Congestion Window Reduced
        /// </summary>
        public Boolean CWR
        {
            get { return base[Layout.FlagsBegin].GetBit(0); }
            set { base[Layout.FlagsBegin] = base[Layout.FlagsBegin].SetBit(0, value); }
        }

        /// <summary>
        /// ECE-Echo
        /// </summary>
        public Boolean ECE
        {
            get { return base[Layout.FlagsBegin].GetBit(1); }
            set { base[Layout.FlagsBegin] = base[Layout.FlagsBegin].SetBit(1, value); }
        }

        /// <summary>
        /// Urgent pointer
        /// </summary>
        public Boolean URG
        {
            get { return base[Layout.FlagsBegin].GetBit(2); }
            set { base[Layout.FlagsBegin] = base[Layout.FlagsBegin].SetBit(2, value); }
        }

        /// <summary>
        /// Acknowledgment
        /// </summary>
        public Boolean ACK
        {
            get { return base[Layout.FlagsBegin].GetBit(3); }
            set { base[Layout.FlagsBegin] = base[Layout.FlagsBegin].SetBit(3, value); }
        }

        /// <summary>
        /// Push function
        /// </summary>
        public Boolean PSH
        {
            get { return base[Layout.FlagsBegin].GetBit(4); }
            set { base[Layout.FlagsBegin] = base[Layout.FlagsBegin].SetBit(4, value); }
        }

        /// <summary>
        /// Reset the connection
        /// </summary>
        public Boolean RST
        {
            get { return base[Layout.FlagsBegin].GetBit(5); }
            set { base[Layout.FlagsBegin] = base[Layout.FlagsBegin].SetBit(5, value); }
        }

        /// <summary>
        /// Synchronize sequence number
        /// </summary>
        public Boolean SYN
        {
            get { return base[Layout.FlagsBegin].GetBit(6); }
            set { base[Layout.FlagsBegin] = base[Layout.FlagsBegin].SetBit(6, value); }
        }

        /// <summary>
        /// Last packet from sender
        /// </summary>
        public Boolean FIN
        {
            get { return base[Layout.FlagsBegin].GetBit(7); }
            set { base[Layout.FlagsBegin] = base[Layout.FlagsBegin].SetBit(7, value); }
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
