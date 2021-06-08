using System;

namespace Networking
{
    /// <summary>
    /// IP地址
    /// </summary>
    public partial class IPAddress : Octets
    {
        /// <summary>
        /// 首部-布局信息
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// V4地址长度=4
            /// </summary>
            public const Int32 V4Length = 4;

            /// <summary>
            /// V6地址长度=16
            /// </summary>
            public const Int32 V6Length = 16;
        }

        /// <summary>
        /// 获取版本
        /// </summary>
        public IPVersion Version
        {
            get
            {
                switch (base.Length)
                {
                    case Layout.V4Length:
                        return IPVersion.IPv4;
                    case Layout.V6Length:
                        return IPVersion.IPv6;
                    default:
                        throw new NotSupportedException($"not support ip length={base.Length}");
                }
            }
        }

        /// <summary>
        /// <para>IPv4 127.0.0.1</para>
        /// <para>IPv6 127.0.0.1</para>
        /// </summary>
        public override String ToString()
        {
            switch (base.Length)
            {
                case Layout.V4Length:
                    return String.Join(".", base.Bytes.ToArray());
                case Layout.V6Length:
                    return base.ToString().Replace("-", ":");
                default:
                    return base.ToString();
            }

        }
    }
}
