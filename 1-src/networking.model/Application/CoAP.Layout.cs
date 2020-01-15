using System;

namespace Networking.Model.Application
{
    public partial class CoAP
    {
        /// <summary>
        /// <see cref="CoAP"/>的首部-布局信息
        /// <see href="https://tools.ietf.org/html/rfc7252#section-3"/>
        /// <see href="https://tools.ietf.org/html/rfc7252#section-12.1"/>
        /// <para></para>
        /// <para>|                             CoAP                              |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>| V | T |  TKL  | Code          | Message Id                    |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>| Token (if any, TKL bytes) ...                                 |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>| Options (if any) ...                                          |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>|1 1 1 1 1 1 1 1|    Payload (if any) ...                       |</para>
        /// <para>|- - - - - - - -+- - - - - - - -+- - - - - - - -+- - - - - - - -|</para>
        /// <para>V    = Version        2 bit                                      </para>
        /// <para>T    = Type           2 bit                                      </para>
        /// <para>TKL  = Token Length   4 bit                                      </para>
        /// <para>Code = c.dd        c= 3 bit  dd= 5 bit                           </para>
        /// <para></para>
        /// </summary>
        public class Layout
        {
            /// <summary>
            /// Version-起始位置=0
            /// </summary>
            public const Int32 VersionBegin = 0;

            /// <summary>
            /// Version-bits索引=0
            /// </summary>
            public const Int32 VersionBitsIndex = 0;

            /// <summary>
            /// Version-bits长度=2
            /// </summary>
            public const Int32 VersionBitsLength = 2;


            /// <summary>
            /// Type-起始位置=0
            /// </summary>
            public const Int32 TypeBegin = 0;

            /// <summary>
            /// Type-bits索引=2
            /// </summary>
            public const Int32 TypeBitsIndex = 2;

            /// <summary>
            /// Type-bits长度=2
            /// </summary>
            public const Int32 TypeBitsLength = 2;


            /// <summary>
            /// Token Length-起始位置=0
            /// </summary>
            public const Int32 TokenLengthBegin = 0;

            /// <summary>
            /// Token Length-bits索引=4
            /// </summary>
            public const Int32 TokenLengthBitsIndex = 4;

            /// <summary>
            /// Token Length-bits长度=4
            /// </summary>
            public const Int32 TokenLengthBitsLength = 4;


            /// <summary>
            /// Code-起始位置=1
            /// </summary>
            public const Int32 CodeBegin = 1;

            /// <summary>
            /// Code-结束位置=2
            /// </summary>
            public const Int32 CodeEnd = CodeBegin + 1;

            /// <summary>
            /// Code C-bits索引=0
            /// </summary>
            public const Int32 CodeCBitsIndex = 0;

            /// <summary>
            /// Code C-bits长度=3
            /// </summary>
            public const Int32 CodeCBitsLength = 3;

            /// <summary>
            /// Code DD-bits索引=3
            /// </summary>
            public const Int32 CodeDDBitsIndex = 3;

            /// <summary>
            /// Code DD-bits长度=5
            /// </summary>
            public const Int32 CodeDDBitsLength = 5;


            /// <summary>
            /// Message Id-起始位置=2
            /// </summary>
            public const Int32 MessageIdBegin = CodeEnd;

            /// <summary>
            /// Message Id-结束位置=4
            /// </summary>
            public const Int32 MessageIdEnd = MessageIdBegin + 2;

            /// <summary>
            /// 固定头部长度=4
            /// </summary>
            public const Int32 FixedHeaderLength = MessageIdEnd;
        }
    }
}
