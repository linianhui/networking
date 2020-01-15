using System;
using System.Text;

namespace Networking.Files.PcapNG
{

    public partial class NameResolutionBlock
    {
        /// <summary>
        /// Name Resolution Block Record
        /// </summary>
        public partial class Record : Octets
        {
            /// <summary>
            /// Type
            /// </summary>
            public RecordType Type
            {
                get { return (RecordType)base.GetUInt16(Layout.RecordTypeBegin); }
            }

            /// <summary>
            /// Value Length
            /// </summary>
            public UInt16 ValueLength
            {
                get { return base.GetUInt16(Layout.RecordValueBegin); }
            }

            /// <summary>
            /// IP
            /// </summary>
            public IPAddress IP
            {
                get
                {
                    var ipAddressLength = GetIPAddressLength();
                    if (ipAddressLength == 0)
                    {
                        return null;
                    }

                    return new IPAddress
                    {
                        Bytes = GetBytes(Layout.RecordHeaderLength, ipAddressLength)
                    };
                }
            }

            /// <summary>
            /// Host
            /// </summary>
            public String Host
            {
                get
                {
                    var ipAddressLength = GetIPAddressLength();
                    if (ipAddressLength == 0)
                    {
                        return null;
                    }

                    var hostBytesBegin = Layout.RecordHeaderLength + ipAddressLength;
                    var hostBytesEnd = ValueLength - ipAddressLength;
                    var hostBytes = GetBytes(hostBytesBegin, hostBytesEnd).ToArray();
                    return Encoding.UTF8.GetString(hostBytes).TrimEnd('\0');
                }
            }

            private Int32 GetIPAddressLength()
            {
                switch (Type)
                {
                    case RecordType.IPv4:
                        return IPAddress.Layout.V4Length;
                    case RecordType.IPv6:
                        return IPAddress.Layout.V6Length;
                    default:
                        return 0;
                }
            }
        }
    }
}
