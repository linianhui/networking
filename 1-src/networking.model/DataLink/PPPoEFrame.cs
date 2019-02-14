using System;

namespace Networking.Model.DataLink
{
    /// <summary>
    /// PPP over Ethernet
    /// <see href="https://en.wikipedia.org/wiki/point-to-point_protocol_over_ethernet"/>
    /// </summary>
    public partial class PPPoEFrame : Octets
    {

        /// <summary>
        /// 版本
        /// </summary>
        public Byte Version
        {
            get { return base.GetByte(Layout.VersionBegin).GetRange(0, 4); }
            set
            {
                var old = base.GetByte(Layout.VersionBegin);
                base.SetByte(Layout.VersionBegin, (Byte)((value) << 4 | old & Bits.B_0000_1111));
            }
        }

        /// <summary>
        /// 类型
        /// </summary>
        public Byte Type
        {
            get { return base.GetByte(Layout.TypeBegin).GetRange(4, 4); }
            set
            {
                var old = base.GetByte(Layout.TypeBegin);
                base.SetByte(Layout.TypeBegin, (Byte)(old & Bits.B_1111_0000 | value & Bits.B_0000_1111));
            }
        }

        /// <summary>
        /// 编号
        /// </summary>
        public PPPoEFrameCode Code
        {
            get
            {
                return (PPPoEFrameCode)base.GetByte(Layout.CodeBegin);
            }
            set
            {
                base.SetByte(Layout.CodeBegin, (Byte)value);
            }
        }

        /// <summary>
        /// 会话Id
        /// </summary>
        public UInt16 SessionId
        {
            get
            {
                return ReadUInt16(Layout.SessionIdBegin);
            }
            set
            {
                WriteUInt16(Layout.SessionIdBegin, value);
            }
        }

        /// <summary>
        /// 负载长度
        /// </summary>
        public UInt16 PayloadLength
        {
            get
            {
                return ReadUInt16(Layout.PayloadLengthBegin);
            }
            set
            {
                WriteUInt16(Layout.PayloadLengthBegin, value);
            }
        }

        /// <summary>
        /// 负载信息
        /// </summary>
        public PPPFrame Payload
        {
            get
            {
                return new PPPFrame
                {
                    Bytes = Slice(Layout.HeaderLength)
                };
            }
        }
    }
}
