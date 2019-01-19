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
        /// 读取或写入
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public Byte this[Int32 index]
        {
            get { return Bytes.Span[index]; }
            set { Bytes.Span[index] = value; }
        }

        /// <summary>
        /// 读取或写入
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public Memory<Byte> this[Int32 index, Int32 length]
        {
            get { return Bytes.Slice(index, length); }
            set { value.CopyTo(Bytes.Slice(index, length)); }
        }

        /// <summary>
        /// 读取为<see cref="UInt16"/>[BigEndian]
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public UInt16 ReadAsUInt16FromBigEndian(Int32 index)
        {
            var span = this[index, 2].Span;
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
