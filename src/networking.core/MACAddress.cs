using System;

namespace Networking
{
    /// <summary>
    /// MAC地址
    /// </summary>
    public partial class MACAddress : Octets
    {
        /// <summary>
        /// 首部-布局信息
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// MAC地址长度=6
            /// </summary>
            public const Int32 Length = 6;
        }

        /// <summary>
        /// 12:34:56:67:89:AB
        /// </summary>
        public override String ToString()
        {
            return base.ToString().Replace("-", ":");
        }
    }
}
