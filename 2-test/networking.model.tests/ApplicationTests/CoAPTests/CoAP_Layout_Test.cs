using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.CoAPTests
{
    public class CoAP_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            CoAP.Layout.VersionBegin.Should().Be(0);
            CoAP.Layout.VersionBitsIndex.Should().Be(0);
            CoAP.Layout.VersionBitsLength.Should().Be(2);

            CoAP.Layout.TypeBegin.Should().Be(0);
            CoAP.Layout.TypeBitsIndex.Should().Be(2);
            CoAP.Layout.TypeBitsLength.Should().Be(2);

            CoAP.Layout.TokenLengthBegin.Should().Be(0);
            CoAP.Layout.TokenLengthBitsIndex.Should().Be(4);
            CoAP.Layout.TokenLengthBitsLength.Should().Be(4);

            CoAP.Layout.CodeBegin.Should().Be(1);
            CoAP.Layout.CodeEnd.Should().Be(2);
            CoAP.Layout.CodeCBitsIndex.Should().Be(0);
            CoAP.Layout.CodeCBitsLength.Should().Be(3);
            CoAP.Layout.CodeDDBitsIndex.Should().Be(3);
            CoAP.Layout.CodeDDBitsLength.Should().Be(5);


            CoAP.Layout.MessageIdBegin.Should().Be(2);
            CoAP.Layout.MessageIdEnd.Should().Be(4);

            CoAP.Layout.FixedHeaderLength.Should().Be(4);
        }
    }
}
