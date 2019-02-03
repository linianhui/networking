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
                return ReadUInt16(Layout.SourcePortBegin, Endian.Big);
            }
            set
            {
                WriteUInt16(Layout.SourcePortBegin, value, Endian.Big);
            }
        }

        /// <summary>
        /// 目标端口
        /// </summary>
        public UInt16 DestinationPort
        {
            get
            {
                return ReadUInt16(Layout.DestinationPortBegin, Endian.Big);
            }
            set
            {
                WriteUInt16(Layout.DestinationPortBegin, value, Endian.Big);
            }
        }

        /// <summary>
        /// 序列号
        /// </summary>
        public UInt32 Sequence
        {
            get
            {
                return ReadUInt32(Layout.SequenceBegin, Endian.Big);
            }
            set
            {
                WriteUInt32(Layout.SequenceBegin, value, Endian.Big);
            }
        }

        /// <summary>
        /// 确认号
        /// </summary>
        public UInt32 ACK
        {
            get
            {
                return ReadUInt32(Layout.ACKBegin, Endian.Big);
            }
            set
            {
                WriteUInt32(Layout.ACKBegin, value, Endian.Big);
            }
        }

        /// <summary>
        /// 首部长度，单位4 octets
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
                return ReadUInt16(Layout.WindowsSizeBegin, Endian.Big);
            }
            set
            {
                WriteUInt16(Layout.WindowsSizeBegin, value, Endian.Big);
            }
        }

        /// <summary>
        /// 校验和
        /// </summary>
        public UInt16 Checksum
        {
            get
            {
                return ReadUInt16(Layout.ChecksumBegin, Endian.Big);
            }
            set
            {
                WriteUInt16(Layout.ChecksumBegin, value, Endian.Big);
            }
        }

        /// <summary>
        /// 紧急指针
        /// </summary>
        public UInt16 UrgentPointer
        {
            get
            {
                return ReadUInt16(Layout.UrgentPointerBegin, Endian.Big);
            }
            set
            {
                WriteUInt16(Layout.UrgentPointerBegin, value, Endian.Big);
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
