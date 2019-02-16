using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.BitsTests
{
    public class Bits_Test
    {

        [Fact]
        public void Constant()
        {
            Bits.B_0000_1111.Should().Be(0B_0000_1111);
            Bits.B_0000_1111.Should().Be(15);
            Bits.B_0000_1111.Should().Be(0x0F);

            Bits.B_1000_0000.Should().Be(0B_1000_0000);
            Bits.B_1000_0000.Should().Be(128);
            Bits.B_1000_0000.Should().Be(0x80);

            Bits.B_1111_0000.Should().Be(0B_1111_0000);
            Bits.B_1111_0000.Should().Be(240);
            Bits.B_1111_0000.Should().Be(0xF0);
        }
    }
}
