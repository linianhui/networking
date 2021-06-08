using System;

namespace Networking.Model.DataLink
{
    /// <summary>
    /// PPP over Ethernet
    /// <see href="https://en.wikipedia.org/wiki/Point-to-Point_Protocol_over_Ethernet"/>
    /// </summary>
    public partial class PPPoEFrame : Octets
    {

        /// <summary>
        /// 版本
        /// </summary>
        public Byte Version
        {
            get { return base.GetByte(Layout.VersionBegin, Layout.VersionBitIndex, Layout.VersionBitLength); }
            set { base.SetByte(Layout.VersionBegin, Layout.VersionBitIndex, Layout.VersionBitLength, value); }
        }

        /// <summary>
        /// 类型
        /// </summary>
        public Byte Type
        {
            get { return base.GetByte(Layout.TypeBegin, Layout.TypeBitIndex, Layout.TypeBitLength); }
            set { base.SetByte(Layout.TypeBegin, Layout.TypeBitIndex, Layout.TypeBitLength, value); }
        }

        /// <summary>
        /// 编号
        /// </summary>
        public PPPoEFrameCode Code
        {
            get { return (PPPoEFrameCode)base.GetByte(Layout.CodeBegin); }
            set { base.SetByte(Layout.CodeBegin, (Byte)value); }
        }

        /// <summary>
        /// 会话Id
        /// </summary>
        public UInt16 SessionId
        {
            get { return GetUInt16(Layout.SessionIdBegin); }
            set { SetUInt16(Layout.SessionIdBegin, value); }
        }

        /// <summary>
        /// 负载长度
        /// </summary>
        public UInt16 PayloadLength
        {
            get { return GetUInt16(Layout.PayloadLengthBegin); }
            set { SetUInt16(Layout.PayloadLengthBegin, value); }
        }

        /// <summary>
        /// 负载信息
        /// </summary>
        public PPPFrame Payload
        {
            get
            {
                var payloadBytes = GetBytes(Layout.HeaderLength);
                return new PPPFrame
                {
                    Bytes = payloadBytes
                };
            }
        }
    }
}
