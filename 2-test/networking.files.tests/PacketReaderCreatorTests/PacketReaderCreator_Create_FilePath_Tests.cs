using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Files.Pcap;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PacketReaderCreatorTests
{
    public class PacketReaderCreator_Create_FilePath_Tests
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { "pcap.pcap", typeof(PcapFileReader)},
            new Object[] { "pcapng.pcapng", typeof(PcapNGFileReader)},
        };

        [Fact]
        public void From_Null_Should_Throw_ArgumentNullException()
        {
            Action action = () => PacketReaderCreator.Create((String)null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void From_Not_Support_Magic_Bytes_Should_Throw_NotSupportedException()
        {
            Action action = () => PacketReaderCreator.Create(BuildFilePath("error.pcap"));

            action.Should().Throw<NotSupportedException>()
                .WithMessage("not support file magic bytes 74-68-69-73.");
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void From(String input, Type expected)
        {
            PacketReaderCreator.Create(BuildFilePath(input)).GetType().Should().Be(expected);
        }

        private static String BuildFilePath(String fileName)
        {
            return AppContext.BaseDirectory
                   + "/PacketReaderCreatorTests/"
                   + fileName;
        }
    }
}
