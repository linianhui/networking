using System;
using System.Collections.Generic;
using System.IO;

namespace Networking.Files
{
    /// <summary>
    /// Packet Reader
    /// </summary>
    public abstract class PacketReader
    {
        private readonly Stream _stream;

        /// <summary>
        /// Offset
        /// </summary>
        public Int32 Offset { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        protected PacketReader(String filePath)
        {
            _stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        protected PacketReader(Stream stream)
        {
            _stream = stream;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        protected PacketReader(Byte[] bytes)
        {
            _stream = new MemoryStream(bytes);
        }

        /// <summary>
        /// 读取所有数据包
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<IPacket> ReadPackets();

        /// <summary>
        /// 向前读取指定的字节
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        protected Byte[] ReadBytes(Int32 length)
        {
            return ReadBytes(Offset, length);
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
            Offset += length;
            return buffer;
        }
    }
}
