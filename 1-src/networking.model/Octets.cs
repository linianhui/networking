using System;
using System.Buffers.Binary;

namespace Networking.Model
{
    /// <summary>
    /// 八位字节组
    /// <see href="https://en.wikipedia.org/wiki/octet_(computing)"/>
    /// </summary>
    public class Octets
    {
        /// <summary>
        /// 字节数据
        /// </summary>
        public Memory<Byte> Bytes { get; set; }

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public Memory<Byte> Read(Int32 index, Int32 length)
        {
            return Bytes.Slice(index, length);
        }

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="length">长度</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public void Write(Int32 index, Int32 length, Memory<Byte> value)
        {
            value.CopyTo(Read(index, length));
        }

        /// <summary>
        /// 读取<see cref="UInt16"/>[BigEndian]
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public UInt16 ReadUInt16BigEndian(Int32 index)
        {
            var span = Read(index, 2).Span;
            return BinaryPrimitives.ReadUInt16BigEndian(span);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return BitConverter.ToString(Bytes.ToArray());
        }
    }
}
