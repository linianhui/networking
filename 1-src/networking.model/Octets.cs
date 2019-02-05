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
        /// 字节序
        /// </summary>
        public Endian Endian { get; set; } = Endian.Big;

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
        /// 读取<see cref="UInt16"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public UInt16 ReadUInt16(Int32 index)
        {
            var span = this[index, 2].Span;
            if (Endian == Endian.Little)
            {
                return BinaryPrimitives.ReadUInt16LittleEndian(span);
            }
            return BinaryPrimitives.ReadUInt16BigEndian(span);
        }

        /// <summary>
        /// 读取<see cref="UInt32"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public UInt32 ReadUInt32(Int32 index)
        {
            var span = this[index, 4].Span;
            if (Endian == Endian.Little)
            {
                return BinaryPrimitives.ReadUInt32LittleEndian(span);
            }
            return BinaryPrimitives.ReadUInt32BigEndian(span);
        }

        /// <summary>
        /// 写入<see cref="UInt16"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public void WriteUInt16(Int32 index, UInt16 value)
        {
            var span = this[index, 2].Span;
            if (Endian == Endian.Little)
            {
                BinaryPrimitives.WriteUInt16LittleEndian(span, value);
                return;
            }
            BinaryPrimitives.WriteUInt16BigEndian(span, value);
        }

        /// <summary>
        /// 写入<see cref="UInt32"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public void WriteUInt32(Int32 index, UInt32 value)
        {
            var span = this[index, 4].Span;
            if (Endian == Endian.Little)
            {
                BinaryPrimitives.WriteUInt32LittleEndian(span, value);
                return;
            }
            BinaryPrimitives.WriteUInt32BigEndian(span, value);
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
