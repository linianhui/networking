using System;
using System.Linq;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.NameResolutionBlockTests
{
    public class NameResolutionBlock_Test
    {
        [Fact]
        public void name_resolution_block()
        {
            var nameResolutionBlock = new NameResolutionBlock
            {
                IsLittleEndian = false,
                Bytes = new Byte[] {
                    0x00,0x00,0x00,0x04,
                    0x00,0x00,0x00,0x24,
                    0x00,0x01,0x00,0x0E,
                    0x7F,0x00,0x00,0x01,
                    0x6C,0x6F,0x63,0x61,
                    0x6C,0x68,0x6F,0x73,
                    0x74,0x00,0x00,0x00,
                    0x00,0x00,0x00,0x00,
                    0x00,0x00,0x00,0x24
                }
            };

            nameResolutionBlock.Type.Should().Be(BlockType.NameResolution);
            nameResolutionBlock.IsLittleEndian.Should().Be(false);
            nameResolutionBlock.TotalLength.Should().Be(36);

            var records = nameResolutionBlock.GetRecords().ToList();
            records.Count.Should().Be(1);

            var record = records[0];
            record.Type.Should().Be(NameResolutionBlock.RecordType.IPv4);
            record.ValueLength.Should().Be(14);
            record.IP.ToString().Should().Be("127.0.0.1");
            record.Host.Should().Be("localhost");
        }
    }
}
