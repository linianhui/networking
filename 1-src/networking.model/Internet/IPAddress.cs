using System;

namespace Networking.Model.Internet
{
    /// <summary>
    /// IP地址
    /// </summary>
    public partial class IPAddress : Octets
    {
        /// <summary>
        /// 127.0.0.1
        /// </summary>
        public override String ToString()
        {
            if (base.Bytes.Length == 4)
            {
                return String.Join(".", base.Bytes.ToArray());
            }
            return base.ToString();
        }
    }
}
