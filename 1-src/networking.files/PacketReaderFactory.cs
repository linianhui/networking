using System;
using System.IO;
using Networking.Files.Pcap;
using Networking.Files.PcapNG;

namespace Networking.Files
{
    /// <summary>
    /// <see cref="IPacketReader"/>
    /// </summary>
    public class PacketReaderFactory : IPacketReaderFactory
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="filePath">绝对文件路径</param>
        /// <returns></returns>
        public IPacketReader Create(String filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }
            return Create(new FileStream(filePath, FileMode.Open, FileAccess.Read));
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns></returns>
        public IPacketReader Create(Byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            return Create(new MemoryStream(bytes));
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="stream">流</param>
        /// <returns></returns>
        public IPacketReader Create(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var magicBytes = ReadMagicBytes(stream);
            var magicNumber = BitConverter.ToUInt32(magicBytes, 0);
            if (PcapPacketReader.MagicNumbers.Contains(magicNumber))
            {
                return new PcapPacketReader(stream);
            }

            if (PcapNGPacketReader.MagicNumbers.Contains(magicNumber))
            {
                return new PcapNGPacketReader(stream);
            }

            throw new NotSupportedException($"not support file magic bytes {BitConverter.ToString(magicBytes)}.");
        }

        private static Byte[] ReadMagicBytes(Stream stream)
        {
            var bytes = new Byte[4];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, 4);
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
    }
}
