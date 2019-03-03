using System;
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
        /// 是否小端字节序
        /// </summary>
        public Boolean IsLittleEndian { get; private set; }

        /// <summary>
        /// 文件首部
        /// </summary>
        public PcapFileHeader Header { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PcapFile(String file)
        {
            _stream = new FileStream(file, FileMode.Open, FileAccess.Read);
            Init();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PcapFile(Stream stream)
        {
            _stream = stream;
            Init();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PcapFile(Byte[] bytes)
        {
            _stream = new MemoryStream(bytes);
            Init();
        }

        private void Init()
        {
            if (ReadBytes(0, 1)[0] == 0xA1)
            {
                IsLittleEndian = false;
            }
            else
            {
                IsLittleEndian = true;
            }

            Header = new PcapFileHeader
            {
                IsLittleEndian = IsLittleEndian,
                Bytes = ReadBytes(0, PcapFileHeader.Layout.HeaderLength)
            };

            _offset = PcapFileHeader.Layout.HeaderLength;
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

        private PacketHeader ReadNextPacketHeader()
        {
            var packetHeaderBytes = ReadNextBytes(PacketHeader.Layout.HeaderLength);
            if (packetHeaderBytes.Length == 0)
            {
                return null;
            }

            return new PacketHeader
            {
                IsLittleEndian = IsLittleEndian,
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
            if (packetHeader.SavedLength > Header.PacketMaxLength)
            {
                return (Int32)Header.PacketMaxLength;
            }
            return (Int32)packetHeader.SavedLength;
        }


        /// <summary>
        /// 读取bytes
        /// </summary>
        private Byte[] ReadNextBytes(Int32 length)
        {
            var buffer = ReadBytes(_offset, length);
            _offset += length;
            return buffer;
        }

        /// <summary>
        /// 读取bytes
        /// </summary>
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
