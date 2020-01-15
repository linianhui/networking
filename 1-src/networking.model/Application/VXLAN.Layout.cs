using System;

namespace Networking.Model.Application
{
    public partial class VXLAN
    {
        /// <summary>
        /// <see cref="VXLAN"/>的首部-布局信息
        /// <see href="https://tools.ietf.org/html/rfc7348"/>
        /// <para></para>
        /// <para>|                          VXLAN Header                         |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|R|R|R|R|I|R|R|R|            Reserved                           |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|      VXLAN Network Identifier (VNI) 24 bits   |   Reserved    |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para></para>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// Tag-起始位置=0
            /// </summary>
            public const Int32 TagBegin = 0;

            /// <summary>
            /// I-bits索引=4
            /// </summary>
            public const Int32 TagIBitIndex = 4;


            /// <summary>
            /// VNI-起始位置=4
            /// </summary>
            public const Int32 VNIBegin = 4;

            /// <summary>
            /// VNI-bits索引=0
            /// </summary>
            public const Int32 VNIBitIndex = 0;

            /// <summary>
            /// VNI-bits长度=24
            /// </summary>
            public const Int32 VNIBitLength = 24;



            /// <summary>
            /// 首部信息-长度=8
            /// </summary>
            public const Int32 HeaderLength = 8;
        }
    }
}
