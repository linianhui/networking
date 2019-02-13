using System;

namespace Networking.Model.Internet
{
    /// <summary>
    /// IP地址
    /// </summary>
    public partial class IPAddress : Octets
    {
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
