using System;

namespace Networking.Model.Application
{
    /// <summary>
    /// Dynamic Host Configuration Protocol
    /// <see href="https://en.wikipedia.org/wiki/Dynamic_Host_Configuration_Protocol"/>
    /// <see href="https://tools.ietf.org/html/rfc2131"/>
    /// </summary>
    public partial class DHCP : Octets
    {
        /// <summary>
        /// 服务端端口号=68
        /// </summary>
        public const UInt16 ClientPort = 68;

        /// <summary>
        /// 服务端端口号=67
        /// </summary>
        public const UInt16 ServerPort = 67;

        /// <summary>
        /// Operation Code
        /// </summary>
        public Byte OperationCode
        {
            get { return base.GetByte(Layout.OperationCodeBegin); }
            set { base.SetByte(Layout.OperationCodeBegin, value); }
        }

        /// <summary>
        /// Hardware Type
        /// </summary>
        public Byte HardwareType
        {
            get { return base.GetByte(Layout.HardwareTypeBegin); }
            set { base.SetByte(Layout.HardwareTypeBegin, value); }
        }

        /// <summary>
        /// Hardware Length
        /// </summary>
        public Byte HardwareLength
        {
            get { return base.GetByte(Layout.HardwareLengthBegin); }
            set { base.SetByte(Layout.HardwareLengthBegin, value); }
        }

        /// <summary>
        /// Transaction Id
        /// </summary>
        public UInt32 TransactionId
        {
            get { return base.GetUInt32(Layout.TransactionIdBegin); }
            set { base.SetUInt32(Layout.TransactionIdBegin, value); }
        }

        /// <summary>
        /// Seconds
        /// </summary>
        public UInt16 Seconds
        {
            get { return base.GetUInt16(Layout.SecondsBegin); }
            set { base.SetUInt16(Layout.SecondsBegin, value); }
        }

        /// <summary>
        /// Flags
        /// </summary>
        public UInt16 Flags
        {
            get { return base.GetUInt16(Layout.FlagsBegin); }
            set { base.SetUInt16(Layout.FlagsBegin, value); }
        }

        /// <summary>
        /// Client IP Address
        /// </summary>
        public IPAddress ClientIPAddress
        {
            get { return this.GetIPv4(Layout.ClientIPAddressBegin); }
            set { this.SetIPv4(Layout.ClientIPAddressBegin, value); }
        }

        /// <summary>
        /// Your Client IP Address
        /// </summary>
        public IPAddress YourClientIPAddress
        {
            get { return this.GetIPv4(Layout.YourClientIPAddressBegin); }
            set { this.SetIPv4(Layout.YourClientIPAddressBegin, value); }
        }

        /// <summary>
        /// Server IP Address
        /// </summary>
        public IPAddress ServerIPAddress
        {
            get { return this.GetIPv4(Layout.ServerIPAddressBegin); }
            set { this.SetIPv4(Layout.ServerIPAddressBegin, value); }
        }

        /// <summary>
        /// Gateway IP Address
        /// </summary>
        public IPAddress GatewayIPAddress
        {
            get { return this.GetIPv4(Layout.GatewayIPAddressBegin); }
            set { this.SetIPv4(Layout.GatewayIPAddressBegin, value); }
        }

        /// <summary>
        /// Gateway IP Address
        /// </summary>
        public MACAddress ClientHardwareAddress
        {
            get { return this.GetMAC(Layout.ClientHardwareAddressBegin); }
            set { this.SetMAC(Layout.ClientHardwareAddressBegin, value); }
        }
    }
}
