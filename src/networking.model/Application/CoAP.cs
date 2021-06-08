using System;

namespace Networking.Model.Application
{
    /// <summary>
    /// CoAP : Constrained Application Protocol
    /// <see href="https://coap.technology/"/>
    /// </summary>
    public partial class CoAP : Octets
    {
        /// <summary>
        /// 服务端端口号=5683
        /// </summary>
        public const UInt16 ServerPort = 5683;

        /// <summary>
        /// Version
        /// </summary>
        public Byte Version
        {
            get { return base.GetByte(Layout.VersionBegin, Layout.VersionBitsIndex, Layout.VersionBitsLength); }
            set { base.SetByte(Layout.VersionBegin, Layout.VersionBitsIndex, Layout.VersionBitsLength, value); }
        }

        /// <summary>
        /// Type
        /// </summary>
        public CoAPType Type
        {
            get { return (CoAPType)base.GetByte(Layout.TypeBegin, Layout.TypeBitsIndex, Layout.TypeBitsLength); }
            set { base.SetByte(Layout.TypeBegin, Layout.TypeBitsIndex, Layout.TypeBitsLength, (Byte)value); }
        }

        /// <summary>
        /// Token Length
        /// </summary>
        public Byte TokenLength
        {
            get { return base.GetByte(Layout.TokenLengthBegin, Layout.TokenLengthBitsIndex, Layout.TokenLengthBitsLength); }
            set { base.SetByte(Layout.TokenLengthBegin, Layout.TokenLengthBitsIndex, Layout.TokenLengthBitsLength, value); }
        }

        /// <summary>
        /// Code
        /// </summary>
        public CoAPCode Code
        {
            get { return (CoAPCode)base.GetByte(Layout.CodeBegin); }
            set { base.SetByte(Layout.CodeBegin, (Byte)value); }
        }

        /// <summary>
        /// Code c
        /// </summary>
        public Byte CodeC
        {
            get { return base.GetByte(Layout.CodeBegin, Layout.CodeCBitsIndex, Layout.CodeCBitsLength); }
        }

        /// <summary>
        /// Code dd
        /// </summary>
        public Byte CodeDD
        {
            get { return base.GetByte(Layout.CodeBegin, Layout.CodeDDBitsIndex, Layout.CodeDDBitsLength); }
        }

        /// <summary>
        /// MessageId
        /// </summary>
        public UInt16 MessageId
        {
            get { return base.GetUInt16(Layout.MessageIdBegin); }
            set { base.SetUInt16(Layout.MessageIdBegin, value); }
        }

        /// <summary>
        /// Token
        /// </summary>
        public Octets Token
        {
            get
            {
                var tokenLength = TokenLength;
                if (tokenLength <= 0)
                {
                    return null;
                }

                var tokenBytes = GetBytes(Layout.FixedHeaderLength, tokenLength);
                return new Octets
                {
                    Bytes = tokenBytes
                };
            }
        }
    }
}
