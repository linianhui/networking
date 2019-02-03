using System;

namespace Networking.Model.Transport
{
    /// <summary>
    /// 用户数据报协议
    /// <see href="https://en.wikipedia.org/wiki/user_datagram_protocol"/>
    /// </summary>
    public partial class UDPSegment : TransportSegment
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
        /// 总长度
        /// </summary>
        public UInt16 TotalLength
        {
            get
            {
                return ReadUInt16(Layout.TotalLengthBegin, Endian.Big);
            }
            set
            {
                WriteUInt16(Layout.TotalLengthBegin, value, Endian.Big);
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
        /// 负载信息
        /// </summary>
        public Octets Payload
        {
            get
            {
                return new Octets
                {
                    Bytes = Slice(8)
                };
            }
        }
    }
}
