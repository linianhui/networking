using System;

namespace Networking.Model.DataLink
{
    /// <summary>
    /// MAC地址
    /// </summary>
    public partial class MACAddress : Octets
    {
        /// <summary>
        /// 12:34:56:67:89:AB
        /// </summary>
        public override String ToString()
        {
            return base.ToString().Replace("-", ":");
        }
    }
}
