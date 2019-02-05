using System;
using System.IO;

namespace Networking.Utils.Pcap
{
    /// <summary>
    /// *.pcap文件
    /// <see href="https://wiki.wireshark.org/development/libpcapfileformat"/>
    /// </summary>
    public class PcapFile
    {
        private Stream _stream;
        private Int32 _offset;
        private PcapFileHeader _header;

        /// <summary>
        /// 文件首部
        /// </summary>
        public PcapFileHeader Header
        {
            get
            {
                if (this._header == null)
                {
                    this._header = new PcapFileHeader
                    {
                        Bytes = ReadBytes(0, PcapFileHeader.Layout.HeaderLength)
                    };
                }
                return this._header;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PcapFile(String file)
        {
            this._stream = new FileStream(file, FileMode.Open, FileAccess.Read);
            this._offset = PcapFileHeader.Layout.HeaderLength;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PcapFile(Stream stream)
        {
            this._stream = stream;
            this._offset = PcapFileHeader.Layout.HeaderLength;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PcapFile(Byte[] bytes)
        {
            this._stream = new MemoryStream(bytes);
            this._offset = PcapFileHeader.Layout.HeaderLength;
        }

        /// <summary>
        /// 读取下一个数据包
        /// </summary>
        public Packet ReadNextPacket()
        {
            PacketHeader packetHeader = ReadNextPacketHeader();
            if (packetHeader == null)
            {
                return null;
            }

            Byte[] packetDataBytes = ReadNextPacketDataBytes(packetHeader);
            if (packetDataBytes.Length == 0)
            {
                return null;
            }

            return new Packet(Header, packetHeader, packetDataBytes);
        }

        private PacketHeader ReadNextPacketHeader()
        {
            Byte[] packetHeaderBytes = ReadNextBytes(PacketHeader.Layout.HeaderLength);
            if (packetHeaderBytes.Length == 0)
            {
                return null;
            }

            return new PacketHeader
            {
                Endian = Header.Endian,
                Bytes = packetHeaderBytes
            };
        }

        private Byte[] ReadNextPacketDataBytes(PacketHeader packetHeader)
        {
            Int32 dataActualLength = ComputeDataActualLength(packetHeader);
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
            Byte[] buffer = ReadBytes(this._offset, length);
            this._offset += length;
            return buffer;
        }

        /// <summary>
        /// 读取bytes
        /// </summary>
        private Byte[] ReadBytes(Int32 offset, Int32 length)
        {
            if (offset + length > this._stream.Length)
            {
                return new Byte[0];
            }
            this._stream.Seek(offset, SeekOrigin.Begin);
            Byte[] buffer = new Byte[length];
            this._stream.Read(buffer, 0, length);
            return buffer;
        }
    }
}