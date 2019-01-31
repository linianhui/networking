using System;

namespace Networking.Model.Internet
{
    public partial class IPAddress
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
    }
}
