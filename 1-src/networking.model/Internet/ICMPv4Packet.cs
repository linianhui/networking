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
                return (ICMPv4TypeCode)ReadUInt16(Layout.TypeCodeBegin, Endian.Big);
            }
            set
            {
                WriteUInt16(Layout.TypeCodeBegin, (UInt16)value, Endian.Big);
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
        /// Id
        /// </summary>
        public UInt16 Id
        {
            get
            {
                return ReadUInt16(Layout.IdBegin, Endian.Big);
            }
            set
            {
                WriteUInt16(Layout.IdBegin, value, Endian.Big);
            }
        }

        /// <summary>
        /// 序列号
        /// </summary>
        public UInt16 Sequence
        {
            get
            {
                return ReadUInt16(Layout.SequenceBegin, Endian.Big);
            }
            set
            {
                WriteUInt16(Layout.SequenceBegin, value, Endian.Big);
            }
        }
    }
}
