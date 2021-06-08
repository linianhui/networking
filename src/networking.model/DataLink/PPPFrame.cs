using System;

namespace Networking.Model.DataLink
{
    /// <summary>
    /// PPP = Point to Point
    /// <see href="https://en.wikipedia.org/wiki/Point-to-Point_Protocol"/>
    /// </summary>
    public partial class PPPFrame : DataLinkPDU
    {

        /// <summary>
        /// 类型
        /// </summary>
        public PPPFrameType Type
        {
            get { return (PPPFrameType)GetUInt16(Layout.TypeBegin); }
            set { SetUInt16(Layout.TypeBegin, (UInt16)value); }
        }

        /// <summary>
        /// 负载信息
        /// </summary>
        public Octets Payload
        {
            get
            {
                return PDUFactory.Create(Type, GetBytes(Layout.HeaderLength));
            }
        }
    }
}
