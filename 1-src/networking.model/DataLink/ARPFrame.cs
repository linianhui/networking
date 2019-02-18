using Networking.Model.Internet;
using System;
namespace Networking.Model.DataLink
{
    /// <summary>
    /// ARP Frame
    /// <see href="https://en.wikipedia.org/wiki/address_resolution_protocol"/>
    /// </summary>
    public partial class ARPFrame : Octets
    {
        /// <summary>
        /// 硬件地址长度
        /// </summary>
        public Byte HardwareAddressLength
        {
            get { return base.GetByte(Layout.HardwareAddressLengthBegin); }
            set { base.SetByte(Layout.HardwareAddressLengthBegin, value); }
        }

        /// <summary>
        /// 协议地址长度
        /// </summary>
        public Byte ProtocolAddressLength
        {
            get { return base.GetByte(Layout.ProtocolAddressLengthBegin); }
            set { base.SetByte(Layout.ProtocolAddressLengthBegin, value); }
        }

        /// <summary>
        /// 发送者MAC地址
        /// </summary>
        public MACAddress SenderMACAddress
        {
            get { return GetMAC(Layout.SenderHardwareAddressBegin); }
            set { SetMAC(Layout.SenderHardwareAddressBegin, value); }
        }

        /// <summary>
        /// 发送者IP地址
        /// </summary>
        public IPAddress SenderIPAddress
        {
            get { return GetIPv4(Layout.SenderProtocolAddressBegin); }
            set { SetIPv4(Layout.SenderProtocolAddressBegin, value); }
        }

        /// <summary>
        /// 接收者MAC地址
        /// </summary>
        public MACAddress TargetMACAddress
        {
            get { return GetMAC(Layout.TargetHardwareAddressBegin); }
            set { SetMAC(Layout.TargetHardwareAddressBegin, value); }
        }


        /// <summary>
        /// 接收者IP地址
        /// </summary>
        public IPAddress TargetIPAddress
        {
            get { return GetIPv4(Layout.TargetProtocolAddressBegin); }
            set { SetIPv4(Layout.TargetProtocolAddressBegin, value); }
        }

        /// <summary>
        /// 协议类型
        /// </summary>
        public EthernetFrameType ProtocolType
        {
            get
            {
                return (EthernetFrameType)GetUInt16(Layout.ProtocolTypeBegin);
            }
            set
            {
                SetUInt16(Layout.ProtocolTypeBegin, (UInt16)value);
            }
        }

        /// <summary>
        /// 硬件类型
        /// </summary>
        public HardwareType HardwareType
        {
            get
            {
                return (HardwareType)GetUInt16(Layout.HardwareTypeBegin);
            }
            set
            {
                SetUInt16(Layout.HardwareTypeBegin, (UInt16)value);
            }
        }

        /// <summary>
        /// 操作码
        /// </summary>
        public ARPOperationCode OperationCode
        {
            get
            {
                return (ARPOperationCode)GetUInt16(Layout.OperationCodeBegin);
            }
            set
            {
                SetUInt16(Layout.OperationCodeBegin, (UInt16)value);
            }
        }



    }
}
