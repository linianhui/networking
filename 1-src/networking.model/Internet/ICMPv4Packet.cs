using System;

namespace Networking.Model.Internet
{
    /// <summary>
    /// ICMPv4=Internet Control Message Protocol
    /// <see href="https://en.wikipedia.org/wiki/Internet_Control_Message_Protocol"/>
    /// </summary>
    public partial class ICMPv4Packet : Octets
    {
        /// <summary>
        /// 类型编号
        /// </summary>
        public ICMPv4TypeCode TypeCode
        {
            get { return (ICMPv4TypeCode)GetUInt16(Layout.TypeCodeBegin); }
            set { SetUInt16(Layout.TypeCodeBegin, (UInt16)value); }
        }

        /// <summary>
        /// 校验和
        /// </summary>
        public UInt16 Checksum
        {
            get { return GetUInt16(Layout.ChecksumBegin); }
            set { SetUInt16(Layout.ChecksumBegin, value); }
        }

        /// <summary>
        /// Id
        /// </summary>
        public UInt16 Id
        {
            get { return GetUInt16(Layout.IdBegin); }
            set { SetUInt16(Layout.IdBegin, value); }
        }

        /// <summary>
        /// 序列号
        /// </summary>
        public UInt16 Sequence
        {
            get { return GetUInt16(Layout.SequenceBegin); }
            set { SetUInt16(Layout.SequenceBegin, value); }
        }
    }
}
