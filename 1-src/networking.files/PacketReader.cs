using System;
using System.Collections.Generic;
using System.IO;

namespace Networking.Files
{
    /// <summary>
    /// Packet Reader
    /// </summary>
    public abstract class PacketReader : IPacketReader
    {
        private readonly Stream _stream;

        /// <summary>
        /// Position
        /// </summary>
        public Int32 Position { get; protected set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        protected PacketReader(Stream stream)
        {
            _stream = stream;
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
            return ReadBytes(Position, length);
        }

        private Byte[] ReadBytes(Int32 position, Int32 length)
        {
            if (position + length > _stream.Length)
            {
                return new Byte[0];
            }
            var bytes = new Byte[length];
            _stream.Seek(position, SeekOrigin.Begin);
            _stream.Read(bytes, 0, length);
            Position += length;
            return bytes;
        }
    }
}
