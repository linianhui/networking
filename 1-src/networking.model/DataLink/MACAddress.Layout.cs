using System;

namespace Networking.Model.DataLink
{
    public partial class MACAddress
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
    }
}
