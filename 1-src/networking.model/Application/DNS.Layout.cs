using System;

namespace Networking.Model.Application
{
    public partial class DNS
    {
        /// <summary>
        /// 首部-布局信息
        /// <see href="https://tools.ietf.org/html/rfc1035#section-4.1.1"/>
        /// <para></para>
        /// <para>|                          DNS : Header                         |</para>
        /// <para>|- - - - - - - -+- - - 32 bits(4 octets) - - - -+- - - - - - - -|</para>
        /// <para>|0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7+0 1 2 3 4 5 6 7|</para>
        /// <para>+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+</para>
        /// <para>| Transaction ID(2 octets)      |Q|OpCode |A|T|R|R|  Z  | RCODE |</para>
        /// <para>|                               |R|4 bits |A|C|D|A|     |       |</para>
        /// <para>+---------------+---------------+---------------+---------------+</para>
        /// <para>| Queries Count                 | Answers Count                 |</para>
        /// <para>+---------------+---------------+---------------+---------------+</para>
        /// <para>| Authority RRs Count(2 octets) | Additional RRs Count(2 octets)|</para>
        /// <para>+---------------+---------------+---------------+---------------+</para>
        /// <para>QR     = 0 query; 1 response                                     </para>
        /// <para>OpCode = 0 standard query; 1 inverse query;                      </para>
        /// <para>         2 server status request; 3-15 reserved                  </para>
        /// <para>AA     = Authoritative Answer                                    </para>
        /// <para>TC     = TrunCation                                              </para>
        /// <para>RD     = Recursion Desired                                       </para>
        /// <para>RA     = Recursion Available                                     </para>
        /// <para>Z      = Reserved                                                </para>
        /// <para>RCODE  = Response code                                           </para>
        /// <para></para>
        /// </summary>
        public class Layout
        {

            /// <summary>
            /// Transaction Id-起始位置=0
            /// </summary>
            public const Int32 TransactionIdBegin = 0;

            /// <summary>
            /// Transaction Id-结束位置=2
            /// </summary>
            public const Int32 TransactionIdEnd = TransactionIdBegin + 2;


            /// <summary>
            /// Flags字节1-起始位置=2
            /// </summary>
            public const Int32 FlagsByte1Begin = TransactionIdEnd;

            /// <summary>
            /// Flags字节2-起始位置=3
            /// </summary>
            public const Int32 FlagsByte2Begin = FlagsByte1Begin + 1;

            /// <summary>
            /// Flags-结束位置=4
            /// </summary>
            public const Int32 FlagsEnd = FlagsByte2Begin + 1;

            /// <summary>
            /// 标志位-QR的bit索引位置=0
            /// </summary>
            public const Int32 FlagsTypeBitIndex = 0;

            /// <summary>
            /// 标志位-QR的bit的长度=1
            /// </summary>
            public const Int32 FlagsTypeBitLength = 1;

            /// <summary>
            /// 标志位-OpCode的bits索引位置=1
            /// </summary>
            public const Int32 FlagsOperationCodeBitIndex = 1;

            /// <summary>
            /// 标志位-OpCode的bits的长度=4
            /// </summary>
            public const Int32 FlagsOperationCodeBitLength = 4;

            /// <summary>
            /// 标志位-AA的bit索引位置=5
            /// </summary>
            public const Int32 FlagsAuthoritativeAnswerBitIndex = 5;

            /// <summary>
            /// 标志位-TC的bit索引位置=6
            /// </summary>
            public const Int32 FlagsTrunCationBitIndex = 6;

            /// <summary>
            /// 标志位-RD的bit索引位置=7
            /// </summary>
            public const Int32 FlagsRecursionDesiredBitIndex = 7;

            /// <summary>
            /// 标志位-RA的bit索引位置=0
            /// </summary>
            public const Int32 FlagsRecursionAvailableBitIndex = 0;

            /// <summary>
            /// 标志位-RCode的bits索引位置=4
            /// </summary>
            public const Int32 FlagsResponseCodeBitIndex = 4;

            /// <summary>
            /// 标志位-RCode的bits的长度=4
            /// </summary>
            public const Int32 FlagsResponseCodeBitLength = 4;


            /// <summary>
            /// Queries Count-起始位置=4
            /// </summary>
            public const Int32 QueriesCountBegin = FlagsEnd;

            /// <summary>
            /// Queries Count-结束位置=6
            /// </summary>
            public const Int32 QueriesCountEnd = QueriesCountBegin + 2;


            /// <summary>
            /// Answers Count-起始位置=6
            /// </summary>
            public const Int32 AnswersCountBegin = QueriesCountEnd;

            /// <summary>
            /// Answers Count-结束位置=8
            /// </summary>
            public const Int32 AnswersCountEnd = AnswersCountBegin + 2;


            /// <summary>
            /// Authority RRs Count-起始位置=8
            /// </summary>
            public const Int32 AuthorityRRsCountBegin = AnswersCountEnd;

            /// <summary>
            /// Authority RRs Count-结束位置=10
            /// </summary>
            public const Int32 AuthorityRRsCountEnd = AuthorityRRsCountBegin + 2;


            /// <summary>
            /// Additional RRs Count-起始位置=10
            /// </summary>
            public const Int32 AdditionalRRsCountBegin = AuthorityRRsCountEnd;

            /// <summary>
            /// Additional RRs Count-结束位置=12
            /// </summary>
            public const Int32 AdditionalRRsCountEnd = AdditionalRRsCountBegin + 2;
        }
    }
}
