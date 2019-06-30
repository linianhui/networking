using System;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.SectionHeaderBodyTests
{
    public class SectionHeaderBody_Test
    {
        [Fact]
        public void Get()
        {
            var sectionHeaderBody = new SectionHeaderBody
            {
                IsLittleEndian = true,
                Bytes = new Byte[] {
                    0x4D,0x3C,0x2B,0x1A,
                    0x01,0x00,0x00,0x00,
                    0xC8,0x67,0x00,0x00
                }
            };

            sectionHeaderBody.MagicNumber.Should().Be(0x1A2B3C4D);
            sectionHeaderBody.MajorVersion.Should().Be(1);
            sectionHeaderBody.MinorVersion.Should().Be(0);
            sectionHeaderBody.SectionLength.Should().Be(26568);
        }
    }
}
