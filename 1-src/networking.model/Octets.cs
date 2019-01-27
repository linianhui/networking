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
        /// 长度
        /// </summary>
        public Int32 Length
        {
            get { return Bytes.Length; }
        }

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
        /// 读取
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public Memory<Byte> Slice(Int32 index)
        {
            return Bytes.Slice(index);
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
        /// 写入[BigEndian]
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public void WriteUInt16ToBigEndian(Int32 index, UInt16 value)
        {
            var span = this[index, 2].Span;
            BinaryPrimitives.WriteUInt16BigEndian(span, value);
        }

        /// <summary>
        /// 12-34-56-78-89-AB-CD-EF
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return BitConverter.ToString(Bytes.ToArray());
        }
    }
}
