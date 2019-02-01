using Networking.Model.Internet;
using System;
namespace Networking.Model.DataLink
{
    /// <summary>
    /// ARP Frame
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
                return (EthernetFrameType)ReadAsUInt16FromBigEndian(Layout.ProtocolTypeBegin);
            }
            set
            {
                WriteUInt16ToBigEndian(Layout.ProtocolTypeBegin, (UInt16)value);
            }
        }

        /// <summary>
        /// 硬件类型
        /// </summary>
        public HardwareType HardwareType
        {
            get
            {
                return (HardwareType)ReadAsUInt16FromBigEndian(Layout.HardwareTypeBegin);
            }
            set
            {
                WriteUInt16ToBigEndian(Layout.HardwareTypeBegin, (UInt16)value);
            }
        }

        /// <summary>
        /// 操作码
        /// </summary>
        public ARPOperationCode OperationCode
        {
            get
            {
                return (ARPOperationCode)ReadAsUInt16FromBigEndian(Layout.OperationCodeBegin);
            }
            set
            {
                WriteUInt16ToBigEndian(Layout.OperationCodeBegin, (UInt16)value);
            }
        }



    }
}
