using System;
using Networking.Model.Internet;

namespace Networking.Model.DataLink
{
    /// <summary>
    /// PPP = Point to Point
    /// <see href="http://en.wikipedia.org/wiki/point-to-point_protocol"/>
    /// </summary>
    public partial class PPPFrame : DataLinkPDU
    {

        /// <summary>
        /// 类型
        /// </summary>
        public PPPFrameType Type
        {
            get
            {
                return (PPPFrameType)ReadUInt16(Layout.TypeBegin);
            }
            set
            {
                WriteUInt16(Layout.TypeBegin, (UInt16)value);
            }
        }

        /// <summary>
        /// 负载信息
        /// </summary>
        public Octets Payload
        {
            get
            {
                switch (Type)
                {

                    case PPPFrameType.IPv4:
                        return new IPv4Packet
                        {
                            Bytes = Slice(Layout.HeaderLength)
                        };
                    case PPPFrameType.IPv6:
                        return new IPv6Packet
                        {
                            Bytes = Slice(Layout.HeaderLength)
                        };
                    default:
                        return new Octets
                        {
                            Bytes = Slice(Layout.HeaderLength)
                        };
                }
            }
        }
    }
}
