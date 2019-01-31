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
                return (ICMPv4TypeCode)ReadAsUInt16FromBigEndian(Layout.TypeCodeBegin);
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

    }
}
