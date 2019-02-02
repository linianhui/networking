using System;
using Networking.Model.Transport;

namespace Networking.Model.Internet
{
    /// <summary>
    /// ICMPv6=Internet Control Message Protocol v6
    /// <see href="https://tools.ietf.org/html/rfc4443"/>
    /// </summary>
    public partial class ICMPv6Packet : Octets
    {

        /// <summary>
        /// 编号
        /// </summary>
        public ICMPv6Type Type
        {
            get
            {
                return (ICMPv6Type)base[Layout.TypeBegin];
            }
            set
            {
                base[Layout.TypeBegin] = (Byte)value;
            }
        }


        /// <summary>
        /// 编号
        /// </summary>
        public Byte Code
        {
            get
            {
                return base[Layout.CodeBegin];
            }
            set
            {
                base[Layout.CodeBegin] = value;
            }
        }

        /// <summary>
        /// 类型编号
        /// </summary>
        public ICMPv6TypeCode TypeCode
        {
            get
            {
                return (ICMPv6TypeCode)ReadAsUInt16FromBigEndian(Layout.TypeCodeBegin);
            }
            set
            {
                WriteUInt16ToBigEndian(Layout.TypeCodeBegin, (UInt16)value);
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
        /// Id
        /// </summary>
        public UInt16 Id
        {
            get
            {
                return ReadAsUInt16FromBigEndian(Layout.IdBegin);
            }
            set
            {
                WriteUInt16ToBigEndian(Layout.IdBegin, value);
            }
        }

        /// <summary>
        /// 序列号
        /// </summary>
        public UInt16 Sequence
        {
            get
            {
                return ReadAsUInt16FromBigEndian(Layout.SequenceBegin);
            }
            set
            {
                WriteUInt16ToBigEndian(Layout.SequenceBegin, value);
            }
        }
    }
}
