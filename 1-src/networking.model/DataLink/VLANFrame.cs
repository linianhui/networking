using System;

namespace Networking.Model.DataLink
{
    /// <summary>
    /// VLAN : IEEE_802.1Q
    /// <see href="https://en.wikipedia.org/wiki/Virtual_LAN"/>
    /// <see href="https://en.wikipedia.org/wiki/IEEE_802.1Q"/>
    /// </summary>
    public partial class VLANFrame : Octets
    {
        /// <summary>
        /// Priority code point
        /// </summary>
        public Byte PCP
        {
            get { return base.GetByte(Layout.PCPBegin, Layout.PCPBitIndex, Layout.PCPBitLength); }
            set { base.SetByte(Layout.PCPBegin, Layout.PCPBitIndex, Layout.PCPBitLength, value); }
        }

        /// <summary>
        /// Drop eligible indicator
        /// </summary>
        public Boolean DEI
        {
            get { return base.GetBoolean(Layout.DEIBegin, Layout.DEIBitIndex); }
            set { base.SetBoolean(Layout.DEIBegin, Layout.DEIBitIndex, value); }
        }

        /// <summary>
        /// VLAN identifier
        /// </summary>
        public UInt16 VID
        {
            get { return base.GetUInt16(Layout.VIDBegin, Layout.VIDBitIndex, Layout.VIDBitLength); }
            set { base.SetUInt16(Layout.VIDBegin, Layout.VIDBitIndex, Layout.VIDBitLength, value); }
        }


        /// <summary>
        /// 类型
        /// </summary>
        public EthernetFrameType Type
        {
            get { return (EthernetFrameType)GetUInt16(Layout.TypeBegin); }
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
