using System;
using System.Collections.Generic;
using System.IO;

namespace Networking.Files.Pcap
{
    /// <summary>
    /// *.pcap文件
    /// <see href="https://wiki.wireshark.org/Development/LibpcapFileFormat"/>
    /// <see href="https://wiki.wireshark.org/SampleCaptures"/>
    /// </summary>
    public class PcapFile
    {
        private readonly Stream _stream;
        private Int32 _offset;

        /// <summary>
        /// 文件首部
        /// </summary>
        public PcapFileHeader Header { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PcapFile(String filePath)
        {
            _stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            ReadFileHeader();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PcapFile(Stream stream)
        {
            _stream = stream;
            ReadFileHeader();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PcapFile(Byte[] bytes)
        {
            _stream = new MemoryStream(bytes);
            ReadFileHeader();
        }

        private void ReadFileHeader()
        {
            _offset = 0;
            var headerBytes = ReadNextBytes(PcapFileHeader.Layout.HeaderLength);
            Header = new PcapFileHeader(headerBytes);
        }

        /// <summary>
        /// 读取下一个数据包
        /// </summary>
        public Packet ReadNextPacket()
        {
            var packetHeader = ReadNextPacketHeader();
            if (packetHeader == null)
            {
                return null;
            }

            var packetDataBytes = ReadNextPacketDataBytes(packetHeader);
            if (packetDataBytes.Length == 0)
            {
                return null;
            }

            return new Packet(Header, packetHeader, packetDataBytes);
        }

        /// <summary>
        /// 读取所有数据包
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Packet> ReadAllPackets()
        {
            var packet = ReadNextPacket();
            while (packet != null)
            {
                yield return packet;
                packet = ReadNextPacket();
            }
        }

        private PacketHeader ReadNextPacketHeader()
        {
            var packetHeaderBytes = ReadNextBytes(PacketHeader.Layout.HeaderLength);
            if (packetHeaderBytes.Length == 0)
            {
                return null;
            }

            return new PacketHeader
            {
                IsLittleEndian = Header.IsLittleEndian,
                Bytes = packetHeaderBytes
            };
        }

        private Byte[] ReadNextPacketDataBytes(PacketHeader packetHeader)
        {
            var dataActualLength = ComputeDataActualLength(packetHeader);
            return ReadNextBytes(dataActualLength);
        }

        private Int32 ComputeDataActualLength(PacketHeader packetHeader)
        {
            if (Header.MaxCapturedLength != 0 && packetHeader.CapturedLength > Header.MaxCapturedLength)
            {
                return (Int32)Header.MaxCapturedLength;
            }
            return (Int32)packetHeader.CapturedLength;
        }

        private Byte[] ReadNextBytes(Int32 length)
        {
            var buffer = ReadBytes(_offset, length);
            _offset += length;
            return buffer;
        }

        private Byte[] ReadBytes(Int32 offset, Int32 length)
        {
            if (offset + length > _stream.Length)
            {
                return new Byte[0];
            }
            _stream.Seek(offset, SeekOrigin.Begin);
            var buffer = new Byte[length];
            _stream.Read(buffer, 0, length);
            return buffer;
        }
    }
}
