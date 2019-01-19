using System;

namespace Networking.Model.DataLink
{
    public partial class EthernetFrame
    {
        /// <summary>
        /// 结构信息
        /// </summary>
        public class Structure
        {
            /// <summary>
            /// MAC地址长度
            /// </summary>
            public static readonly Int32 MACAddressLength = 6;

            /// <summary>
            /// 类型长度
            /// </summary>
            public static readonly Int32 TypeLength = 2;

            /// <summary>
            /// 目标MAC地址-起始位置
            /// </summary>
            public static readonly Int32 DestinationMACAddressBegin = 0;

            /// <summary>
            /// 目标MAC地址-结束位置
            /// </summary>
            public static readonly Int32 DestinationMACAddressEnd = DestinationMACAddressBegin + MACAddressLength;

            /// <summary>
            /// 源MAC地址-起始位置
            /// </summary>
            public static readonly Int32 SourceMACAddressBegin = DestinationMACAddressEnd;

            /// <summary>
            /// 源MAC地址-结束位置
            /// </summary>
            public static readonly Int32 SourceMACAddressEnd = SourceMACAddressBegin + MACAddressLength;

            /// <summary>
            /// 类型-起始位置
            /// </summary>
            public static readonly Int32 TypeBegin = SourceMACAddressEnd;

            /// <summary>
            /// 类型-结束位置
            /// </summary>
            public static readonly Int32 TypeEnd = TypeBegin + TypeLength;

            /// <summary>
            /// 头部信息-长度
            /// </summary>
            public static readonly Int32 HeaderLength = TypeEnd;
        }
    }
}
