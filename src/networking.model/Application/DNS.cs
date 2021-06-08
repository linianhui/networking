using System;

namespace Networking.Model.Application
{
    /// <summary>
    /// Domain Name System
    /// <see href="https://en.wikipedia.org/wiki/Domain_Name_System"/>
    /// <see href="https://tools.ietf.org/html/rfc1035"/>
    /// </summary>
    public partial class DNS : Octets
    {
        /// <summary>
        /// 服务端端口号=53
        /// </summary>
        public const UInt16 ServerPort = 53;

        /// <summary>
        /// Transaction Id
        /// </summary>
        public UInt16 TransactionId
        {
            get { return base.GetUInt16(Layout.TransactionIdBegin); }
            set { base.SetUInt16(Layout.TransactionIdBegin, value); }
        }

        /// <summary>
        /// Type
        /// </summary>
        public DNSType Type
        {
            get { return (DNSType)base.GetByte(Layout.FlagsByte1Begin, Layout.FlagsTypeBitIndex, Layout.FlagsTypeBitLength); }
            set { base.SetByte(Layout.FlagsByte1Begin, Layout.FlagsTypeBitIndex, Layout.FlagsTypeBitLength, (Byte)value); }
        }

        /// <summary>
        /// Operation Code
        /// </summary>
        public DNSOperationCode OperationCode
        {
            get { return (DNSOperationCode)GetByte(Layout.FlagsByte1Begin, Layout.FlagsOperationCodeBitIndex, Layout.FlagsOperationCodeBitLength); }
            set { SetByte(Layout.FlagsByte1Begin, Layout.FlagsOperationCodeBitIndex, Layout.FlagsOperationCodeBitLength, (Byte)value); }
        }

        /// <summary>
        /// Authoritative Answer
        /// </summary>
        public Boolean AuthoritativeAnswer
        {
            get { return base.GetBoolean(Layout.FlagsByte1Begin, Layout.FlagsAuthoritativeAnswerBitIndex); }
            set { base.SetBoolean(Layout.FlagsByte1Begin, Layout.FlagsAuthoritativeAnswerBitIndex, value); }
        }

        /// <summary>
        /// TrunCation
        /// </summary>
        public Boolean TrunCation
        {
            get { return base.GetBoolean(Layout.FlagsByte1Begin, Layout.FlagsTrunCationBitIndex); }
            set { base.SetBoolean(Layout.FlagsByte1Begin, Layout.FlagsTrunCationBitIndex, value); }
        }

        /// <summary>
        /// Recursion Desired
        /// </summary>
        public Boolean RecursionDesired
        {
            get { return base.GetBoolean(Layout.FlagsByte1Begin, Layout.FlagsRecursionDesiredBitIndex); }
            set { base.SetBoolean(Layout.FlagsByte1Begin, Layout.FlagsRecursionDesiredBitIndex, value); }
        }

        /// <summary>
        /// Recursion Available
        /// </summary>
        public Boolean RecursionAvailable
        {
            get { return base.GetBoolean(Layout.FlagsByte2Begin, Layout.FlagsRecursionAvailableBitIndex); }
            set { base.SetBoolean(Layout.FlagsByte2Begin, Layout.FlagsRecursionAvailableBitIndex, value); }
        }

        /// <summary>
        /// Response Code
        /// </summary>
        public DNSResponseCode ResponseCode
        {
            get { return (DNSResponseCode)GetByte(Layout.FlagsByte2Begin, Layout.FlagsResponseCodeBitIndex, Layout.FlagsResponseCodeBitLength); }
            set { SetByte(Layout.FlagsByte2Begin, Layout.FlagsResponseCodeBitIndex, Layout.FlagsResponseCodeBitLength, (Byte)value); }
        }


        /// <summary>
        /// Queries Count
        /// </summary>
        public UInt16 QueriesCount
        {
            get { return base.GetUInt16(Layout.QueriesCountBegin); }
            set { base.SetUInt16(Layout.QueriesCountBegin, value); }
        }

        /// <summary>
        /// Answers Count
        /// </summary>
        public UInt16 AnswersCount
        {
            get { return base.GetUInt16(Layout.AnswersCountBegin); }
            set { base.SetUInt16(Layout.AnswersCountBegin, value); }
        }

        /// <summary>
        /// Authority RRs Count
        /// </summary>
        public UInt16 AuthorityRRsCount
        {
            get { return base.GetUInt16(Layout.AuthorityRRsCountBegin); }
            set { base.SetUInt16(Layout.AuthorityRRsCountBegin, value); }
        }

        /// <summary>
        /// Additional RRs Count
        /// </summary>
        public UInt16 AdditionalRRsCount
        {
            get { return base.GetUInt16(Layout.AdditionalRRsCountBegin); }
            set { base.SetUInt16(Layout.AdditionalRRsCountBegin, value); }
        }

    }
}
