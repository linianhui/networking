using System;
using System.IO;
using Networking.Files.Pcap;
using Networking.Files.PcapNG;

namespace Networking.Files
{
    public partial class PacketReader
    {
        /// <summary>
        /// From
        /// </summary>
        /// <param name="filePath">绝对文件路径</param>
        /// <returns></returns>
        public static PacketReader From(String filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }
            return From(new FileStream(filePath, FileMode.Open, FileAccess.Read));
        }

        /// <summary>
        /// From
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns></returns>
        public static PacketReader From(Byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            return From(new MemoryStream(bytes));
        }

        /// <summary>
        /// From
        /// </summary>
        /// <param name="stream">流</param>
        /// <returns></returns>
        public static PacketReader From(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            Byte[] ReadMagicBytes()
            {
                var bytes = new Byte[4];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(bytes, 0, 4);
                stream.Seek(0, SeekOrigin.Begin);
                return bytes;
            }

            var magicBytes = ReadMagicBytes();
            var magicNumber = BitConverter.ToUInt32(magicBytes, 0);
            if (PcapFileReader.MagicNumbers.Contains(magicNumber))
            {
                return new PcapFileReader(stream);
            }

            if (PcapNGFileReader.MagicNumbers.Contains(magicNumber))
            {
                return new PcapNGFileReader(stream);
            }

            throw new NotSupportedException($"not support file magic bytes {BitConverter.ToString(magicBytes)}.");
        }
    }
}
