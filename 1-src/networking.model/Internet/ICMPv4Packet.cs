using System;
using Networking.Model.Transport;

namespace Networking.Model.Internet
{
    /// <summary>
    /// ICMPv4=Internet Control Message Protocol
    /// <see href="http://en.wikipedia.org/wiki/internet_control_message_protocol"/>
    /// </summary>
    public partial class ICMPv4Packet : Octets
    {

        /// <summary>
        /// 类型编号
        /// </summary>
        public ICMPv4TypeCode TypeCode
        {
            get
            {
                return (ICMPv4TypeCode)ReadUInt16BigEndian(Layout.TypeCodeBegin);
            }
            set
            {
                WriteUInt16BigEndian(Layout.TypeCodeBegin, (UInt16)value);
            }
        }

        /// <summary>
        /// 校验和
        /// </summary>
        public UInt16 Checksum
        {
            get
            {
                return ReadUInt16BigEndian(Layout.ChecksumBegin);
            }
            set
            {
                WriteUInt16BigEndian(Layout.ChecksumBegin, value);
            }
        }

        /// <summary>
        /// Id
        /// </summary>
        public UInt16 Id
        {
            get
            {
                return ReadUInt16BigEndian(Layout.IdBegin);
            }
            set
            {
                WriteUInt16BigEndian(Layout.IdBegin, value);
            }
        }

        /// <summary>
        /// 序列号
        /// </summary>
        public UInt16 Sequence
        {
            get
            {
                return ReadUInt16BigEndian(Layout.SequenceBegin);
            }
            set
            {
                WriteUInt16BigEndian(Layout.SequenceBegin, value);
            }
        }
    }
}
