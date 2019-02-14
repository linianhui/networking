using System;

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
                return (ICMPv6Type)base.GetByte(Layout.TypeBegin);
            }
            set
            {
                base.SetByte(Layout.TypeBegin, (Byte)value);
            }
        }


        /// <summary>
        /// 编号
        /// </summary>
        public Byte Code
        {
            get
            {
                return base.GetByte(Layout.CodeBegin);
            }
            set
            {
                base.SetByte(Layout.CodeBegin, value);
            }
        }

        /// <summary>
        /// 类型编号
        /// </summary>
        public ICMPv6TypeCode TypeCode
        {
            get
            {
                return (ICMPv6TypeCode)ReadUInt16(Layout.TypeCodeBegin);
            }
            set
            {
                WriteUInt16(Layout.TypeCodeBegin, (UInt16)value);
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
        /// Id
        /// </summary>
        public UInt16 Id
        {
            get
            {
                return ReadUInt16(Layout.IdBegin);
            }
            set
            {
                WriteUInt16(Layout.IdBegin, value);
            }
        }

        /// <summary>
        /// 序列号
        /// </summary>
        public UInt16 Sequence
        {
            get
            {
                return ReadUInt16(Layout.SequenceBegin);
            }
            set
            {
                WriteUInt16(Layout.SequenceBegin, value);
            }
        }
    }
}
