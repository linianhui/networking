using System;

namespace Networking.Model.Transport
{
    /// <summary>
    /// 传输控制协议
    /// <see href="https://en.wikipedia.org/wiki/transmission_control_protocol"/>
    /// </summary>
    public partial class TCPSegment : TransportSegment
    {
        /// <summary>
        /// 源端口
        /// </summary>
        public UInt16 SourcePort
        {
            get
            {
                return ReadAsUInt16FromBigEndian(Layout.SourcePortBegin);
            }
            set
            {
                WriteUInt16ToBigEndian(Layout.SourcePortBegin, value);
            }
        }

        /// <summary>
        /// 目标端口
        /// </summary>
        public UInt16 DestinationPort
        {
            get
            {
                return ReadAsUInt16FromBigEndian(Layout.DestinationPortBegin);
            }
            set
            {
                WriteUInt16ToBigEndian(Layout.DestinationPortBegin, value);
            }
        }

        /// <summary>
        /// 序列号
        /// </summary>
        public UInt32 Sequence
        {
            get
            {
                return ReadAsUInt32FromBigEndian(Layout.SequenceBegin);
            }
            set
            {
                WriteUInt32ToBigEndian(Layout.SequenceBegin, value);
            }
        }

        /// <summary>
        /// 确认号
        /// </summary>
        public UInt32 ACK
        {
            get
            {
                return ReadAsUInt32FromBigEndian(Layout.ACKBegin);
            }
            set
            {
                WriteUInt32ToBigEndian(Layout.ACKBegin, value);
            }
        }

        /// <summary>
        /// 头部长度，单位4 octets
        /// </summary>
        public Byte HeaderLength
        {
            get { return (Byte)(base[Layout.HeaderLengthBegin] >> 4); }
            set
            {
                var old = base[Layout.HeaderLengthBegin];
                base[Layout.HeaderLengthBegin] = (Byte)(((Byte)value) << 4 | old & 0x0F);
            }
        }

        /// <summary>
        /// 窗口大小
        /// </summary>
        public UInt16 WindowsSize
        {
            get
            {
                return ReadAsUInt16FromBigEndian(Layout.WindowsSizeBegin);
            }
            set
            {
                WriteUInt16ToBigEndian(Layout.WindowsSizeBegin, value);
            }
        }

        /// <summary>
        /// 校验和
        /// </summary>
        public UInt16 Checksum
        {
            get
            {
                return ReadAsUInt16FromBigEndian(Layout.ChecksumBegin);
            }
            set
            {
                WriteUInt16ToBigEndian(Layout.ChecksumBegin, value);
            }
        }

        /// <summary>
        /// 紧急指针
        /// </summary>
        public UInt16 UrgentPointer
        {
            get
            {
                return ReadAsUInt16FromBigEndian(Layout.UrgentPointerBegin);
            }
            set
            {
                WriteUInt16ToBigEndian(Layout.UrgentPointerBegin, value);
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
