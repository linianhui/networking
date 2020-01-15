using System;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.SectionHeaderBlockTests
{
    public class SectionHeaderBlock_Test
    {
        [Fact]
        public void section_header_block()
        {
            var sectionHeaderBlock = new SectionHeaderBlock
            {
                IsLittleEndian = true,
                Bytes = new Byte[] {
                    0x0A,0x0D,0x0D,0x0A,
                    0x00,0x00,0x00,0x14,
                    0x4D,0x3C,0x2B,0x1A,
                    0x01,0x00,0x00,0x00,
                    0xC8,0x67,0x00,0x00
                }
            };

            sectionHeaderBlock.Should().NotBeAssignableTo<IPacket>();
            sectionHeaderBlock.IsPacket.Should().Be(false);
            sectionHeaderBlock.MagicNumber.Should().Be(0x1A2B3C4D);
            sectionHeaderBlock.MajorVersion.Should().Be(1);
            sectionHeaderBlock.MinorVersion.Should().Be(0);
            sectionHeaderBlock.SectionLength.Should().Be(26568);
        }
    }
}
