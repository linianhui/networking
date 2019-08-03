using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Files.Pcap;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PacketReaderTests
{
    public class PacketReader_From_FilePath_Tests
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { "pcap.pcap", typeof(PcapFileReader)},
            new Object[] { "pcapng.pcapng", typeof(PcapNGFileReader)},
        };

        [Fact]
        public void From_Null_Should_Throw_ArgumentNullException()
        {
            Action action = () => PacketReader.From((String)null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void From_Not_Support_Magic_Bytes_Should_Throw_NotSupportedException()
        {
            Action action = () => PacketReader.From(BuildFilePath("error.pcap"));

            action.Should().Throw<NotSupportedException>()
                .WithMessage("not support file magic bytes 74-68-69-73.");
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void From(String input, Type expected)
        {
            PacketReader.From(BuildFilePath(input)).GetType().Should().Be(expected);
        }

        private static String BuildFilePath(String fileName)
        {
            return AppContext.BaseDirectory + "/PacketReaderTests/" + fileName;
        }
    }
}
