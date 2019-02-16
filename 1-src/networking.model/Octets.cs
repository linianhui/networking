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
        /// 是否小端字节序
        /// <para></para>
        /// <para>       0xA1B2C3D4                                           </para>
        /// <para>|  -  + 4 octets  +     |                                   </para>
        /// <para>|  -  +  -  +  -  +  -  |                                   </para>
        /// <para>|  0     1     2     3  | 内存增长方向                        </para>
        /// <para>|  -  +  -  +  -  +  -  |                                   </para>
        /// <para>| 0xA1  0xB2  0xC3  0xD4| 大端模式/网络字节序[高位字节存储在低位] </para>
        /// <para>|  -  +  -  +  -  +  -  |                                   </para>
        /// <para>| 0xD4  0xC3  0xB2  0xA1| 小端模式/主机字节序[高位字节存储在高位] </para>
        /// <para>|  -  +  -  +  -  +  -  |                                   </para>
        /// <para></para>
        /// </summary>
        public Boolean IsLittleEndian { get; set; } = false;

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
        /// 获取指定位置的bit[1=true,0=false]
        /// </summary>
        /// <param name="byteIndex">Byte的索引</param>
        /// <param name="bitIndex">bit的索引[0-7]</param>
        /// <returns></returns>
        public Boolean GetBit(Int32 byteIndex, Int32 bitIndex)
        {
            return GetByte(byteIndex).GetBit(bitIndex);
        }

        /// <summary>
        /// 获取<see cref="Byte"/>
        /// </summary>
        /// <param name="byteIndex">byte的索引</param>
        /// <returns></returns>
        public Byte GetByte(Int32 byteIndex)
        {
            return Bytes.Span[byteIndex];
        }

        /// <summary>
        /// 获取<see cref="Byte"/>
        /// </summary>
        /// <param name="byteIndex">byte的索引</param>
        /// <param name="bitIndex">bit的索引</param>
        /// <param name="bitLength">bit的长度</param>
        /// <returns></returns>
        public Byte GetByte(Int32 byteIndex, Int32 bitIndex, Int32 bitLength)
        {
            return GetByte(byteIndex).GetByte(bitIndex, bitLength);
        }

        /// <summary>
        /// 获取<see cref="UInt16"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public UInt16 GetUInt16(Int32 index)
        {
            var span = this[index, 2].Span;
            if (IsLittleEndian)
            {
                return BinaryPrimitives.ReadUInt16LittleEndian(span);
            }
            return BinaryPrimitives.ReadUInt16BigEndian(span);
        }

        /// <summary>
        /// 获取<see cref="UInt32"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public UInt32 GetUInt32(Int32 index)
        {
            var span = this[index, 4].Span;
            if (IsLittleEndian)
            {
                return BinaryPrimitives.ReadUInt32LittleEndian(span);
            }
            return BinaryPrimitives.ReadUInt32BigEndian(span);
        }

        /// <summary>
        /// 设置指定位置的bit[1=true,0=false]
        /// </summary>
        /// <param name="byteIndex">Byte的索引</param>
        /// <param name="bitIndex">bit的索引[0-7]</param>
        /// <param name="value">bit的值</param>
        /// <returns></returns>
        public Byte SetBit(Int32 byteIndex, Int32 bitIndex, Boolean value)
        {
            var oldValue = GetByte(byteIndex);
            var newValue = oldValue.SetBit(bitIndex, value);
            return SetByte(byteIndex, newValue);
        }

        /// <summary>
        /// 设置<see cref="Byte"/>
        /// </summary>
        /// <param name="byteIndex">byte的索引</param>
        /// <param name="byteValue">byte的值</param>
        /// <returns></returns>
        public Byte SetByte(Int32 byteIndex, Byte byteValue)
        {
            Bytes.Span[byteIndex] = byteValue;
            return byteValue;
        }

        /// <summary>
        /// 设置<see cref="UInt16"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public UInt16 SetUInt16(Int32 index, UInt16 value)
        {
            var span = this[index, 2].Span;
            if (IsLittleEndian)
            {
                BinaryPrimitives.WriteUInt16LittleEndian(span, value);
            }
            else
            {
                BinaryPrimitives.WriteUInt16BigEndian(span, value);
            }
            return value;
        }

        /// <summary>
        /// 设置<see cref="UInt32"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public UInt32 SetUInt32(Int32 index, UInt32 value)
        {
            var span = this[index, 4].Span;
            if (IsLittleEndian)
            {
                BinaryPrimitives.WriteUInt32LittleEndian(span, value);
            }
            else
            {
                BinaryPrimitives.WriteUInt32BigEndian(span, value);
            }
            return value;
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
