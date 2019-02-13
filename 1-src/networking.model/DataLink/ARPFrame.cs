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
            get { return base[Layout.HardwareAddressLengthBegin]; }
            set { base[Layout.HardwareAddressLengthBegin] = value; }
        }

        /// <summary>
        /// 协议地址长度
        /// </summary>
        public Byte ProtocolAddressLength
        {
            get { return base[Layout.ProtocolAddressLengthBegin]; }
            set { base[Layout.ProtocolAddressLengthBegin] = value; }
        }

        /// <summary>
        /// 发送者MAC地址
        /// </summary>
        public MACAddress SenderMACAddress
        {
            get
            {
                return new MACAddress
                {
                    Bytes = base[Layout.SenderHardwareAddressBegin, MACAddress.Layout.Length]
                };
            }
            set
            {
                base[Layout.SenderHardwareAddressBegin, MACAddress.Layout.Length] = value.Bytes;
            }
        }

        /// <summary>
        /// 发送者IP地址
        /// </summary>
        public IPAddress SenderIPAddress
        {
            get
            {
                return new IPAddress
                {
                    Bytes = base[Layout.SenderProtocolAddressBegin, IPAddress.Layout.V4Length]
                };
            }
            set
            {
                base[Layout.SenderProtocolAddressBegin, IPAddress.Layout.V4Length] = value.Bytes;
            }
        }

        /// <summary>
        /// 接收者MAC地址
        /// </summary>
        public MACAddress TargetMACAddress
        {
            get
            {
                return new MACAddress
                {
                    Bytes = base[Layout.TargetHardwareAddressBegin, MACAddress.Layout.Length]
                };
            }
            set
            {
                base[Layout.TargetHardwareAddressBegin, MACAddress.Layout.Length] = value.Bytes;
            }
        }


        /// <summary>
        /// 接收者IP地址
        /// </summary>
        public IPAddress TargetIPAddress
        {
            get
            {
                return new IPAddress
                {
                    Bytes = base[Layout.TargetProtocolAddressBegin, IPAddress.Layout.V4Length]
                };
            }
            set
            {
                base[Layout.TargetProtocolAddressBegin, IPAddress.Layout.V4Length] = value.Bytes;
            }
        }

        /// <summary>
        /// 协议类型
        /// </summary>
        public EthernetFrameType ProtocolType
        {
            get
            {
                return (EthernetFrameType)ReadUInt16(Layout.ProtocolTypeBegin);
            }
            set
            {
                WriteUInt16(Layout.ProtocolTypeBegin, (UInt16)value);
            }
        }

        /// <summary>
        /// 硬件类型
        /// </summary>
        public HardwareType HardwareType
        {
            get
            {
                return (HardwareType)ReadUInt16(Layout.HardwareTypeBegin);
            }
            set
            {
                WriteUInt16(Layout.HardwareTypeBegin, (UInt16)value);
            }
        }

        /// <summary>
        /// 操作码
        /// </summary>
        public ARPOperationCode OperationCode
        {
            get
            {
                return (ARPOperationCode)ReadUInt16(Layout.OperationCodeBegin);
            }
            set
            {
                WriteUInt16(Layout.OperationCodeBegin, (UInt16)value);
            }
        }



    }
}
