using System;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.NameResolutionBlockTests.RecordTests
{
    public class Record_Test
    {
        [Fact]
        public void record()
        {
            var record = new NameResolutionBlock.Record
            {
                IsLittleEndian = false,
                Bytes = new Byte[] {
                    0x00,0x01,0x00,0x0E,
                    0x7F,0x00,0x00,0x01,
                    0x6C,0x6F,0x63,0x61,
                    0x6C,0x68,0x6F,0x73,
                    0x74,0x00,0x00,0x00
                }
            };

            record.Type.Should().Be(NameResolutionBlock.RecordType.IPv4);
            record.ValueLength.Should().Be(14);
            record.IP.ToString().Should().Be("127.0.0.1");
            record.Host.Should().Be("localhost");
        }
    }
}
