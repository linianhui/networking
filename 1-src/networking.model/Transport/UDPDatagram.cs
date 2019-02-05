using System;

namespace Networking.Model.Transport
{
    /// <summary>
    /// 用户数据报协议
    /// <see href="https://en.wikipedia.org/wiki/user_datagram_protocol"/>
    /// </summary>
    public partial class UDPDatagram : TransportSegment
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
