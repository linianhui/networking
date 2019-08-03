using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Files.Pcap;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PacketReaderTests
{
    public class PacketReader_From_ByteArray_Tests
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { new Byte[] { 0xA1, 0xB2, 0xC3, 0xD4 }, typeof(PcapFileReader)},
            new Object[] { new Byte[] { 0xD4, 0xC3, 0xB2, 0xA1 }, typeof(PcapFileReader)},
            new Object[] { new Byte[] { 0xA1, 0xB2, 0x3C, 0x4D }, typeof(PcapFileReader)},
            new Object[] { new Byte[] { 0x4D, 0x3C, 0xB2, 0xA1 }, typeof(PcapFileReader)},
            new Object[] { new Byte[] { 0x0A, 0x0D, 0x0D, 0x0A }, typeof(PcapNGFileReader)},
        };

        [Fact]
        public void From_Null_Should_Throw_ArgumentNullException()
        {
            Action action = () => PacketReader.From((Byte[])null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void From_Not_Support_Magic_Bytes_Should_Throw_NotSupportedException()
        {
            Action action = () => PacketReader.From(new Byte[] { 1, 2, 3, 4 });

            action.Should().Throw<NotSupportedException>()
                .WithMessage("not support file magic bytes 01-02-03-04.");
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void From(Byte[] input, Type expected)
        {
            PacketReader.From(input).GetType().Should().Be(expected);
        }
    }
}
