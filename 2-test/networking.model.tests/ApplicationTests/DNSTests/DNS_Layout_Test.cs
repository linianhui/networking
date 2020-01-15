using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DNSTests
{
    public class DNS_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            DNS.Layout.TransactionIdBegin.Should().Be(0);
            DNS.Layout.TransactionIdEnd.Should().Be(2);

            DNS.Layout.FlagsByte1Begin.Should().Be(2);
            DNS.Layout.FlagsByte2Begin.Should().Be(3);
            DNS.Layout.FlagsEnd.Should().Be(4);
            DNS.Layout.FlagsTypeBitIndex.Should().Be(0);
            DNS.Layout.FlagsTypeBitLength.Should().Be(1);
            DNS.Layout.FlagsOperationCodeBitIndex.Should().Be(1);
            DNS.Layout.FlagsOperationCodeBitLength.Should().Be(4);
            DNS.Layout.FlagsAuthoritativeAnswerBitIndex.Should().Be(5);
            DNS.Layout.FlagsTrunCationBitIndex.Should().Be(6);
            DNS.Layout.FlagsRecursionDesiredBitIndex.Should().Be(7);
            DNS.Layout.FlagsRecursionAvailableBitIndex.Should().Be(0);
            DNS.Layout.FlagsResponseCodeBitIndex.Should().Be(4);
            DNS.Layout.FlagsResponseCodeBitLength.Should().Be(4);

            DNS.Layout.QueriesCountBegin.Should().Be(4);
            DNS.Layout.QueriesCountEnd.Should().Be(6);

            DNS.Layout.AnswersCountBegin.Should().Be(6);
            DNS.Layout.AnswersCountEnd.Should().Be(8);

            DNS.Layout.AuthorityRRsCountBegin.Should().Be(8);
            DNS.Layout.AuthorityRRsCountEnd.Should().Be(10);

            DNS.Layout.AdditionalRRsCountBegin.Should().Be(10);
            DNS.Layout.AdditionalRRsCountEnd.Should().Be(12);
        }
    }
}
