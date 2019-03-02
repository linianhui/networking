using System;

namespace Networking.Model.DataLink
{
    /// <summary>
    /// VXLAN : RFC7348
    /// <see href="https://en.wikipedia.org/wiki/Virtual_Extensible_LAN"/>
    /// <see href="https://tools.ietf.org/html/rfc7348"/>
    /// </summary>
    public partial class VXLANFrame : Octets
    {
        /// <summary>
        /// I
        /// </summary>
        public Boolean I
        {
            get { return base.GetBoolean(Layout.TagBegin, Layout.TagIBitIndex); }
            set { base.SetBoolean(Layout.TagBegin, Layout.TagIBitIndex, value); }
        }

        /// <summary>
        /// VXLAN Network Identifier
        /// </summary>
        public UInt32 VNI
        {
            get { return base.GetUInt32(Layout.VNIBegin, Layout.VNIBitIndex, Layout.VNIBitLength); }
            set { base.SetUInt32(Layout.VNIBegin, Layout.VNIBitIndex, Layout.VNIBitLength, value); }
        }

        /// <summary>
        /// 负载信息
        /// </summary>
        public EthernetFrame Payload
        {
            get
            {
                return new EthernetFrame
                {
                    Bytes = GetBytes(Layout.HeaderLength)
                };
            }
        }
    }
}
