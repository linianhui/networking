using System;
using System.Buffers.Binary;

namespace Networking
{
    /// <summary>
    /// 八位字节组
    /// <see href="https://en.wikipedia.org/wiki/Octet_(computing)"/>
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
        /// 获取指定位置的bit[1=true,0=false]
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="bitIndex">bit的索引[0-7]</param>
        /// <returns></returns>
        public Boolean GetBoolean(Int32 index, Int32 bitIndex)
        {
            return GetByte(index).GetBoolean(bitIndex);
        }

        /// <summary>
        /// 获取<see cref="Byte"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="bitIndex">bit的索引</param>
        /// <param name="bitLength">bit的长度</param>
        /// <returns></returns>
        public Byte GetByte(Int32 index, Int32 bitIndex, Int32 bitLength)
        {
            return GetByte(index).GetByte(bitIndex, bitLength);
        }

        /// <summary>
        /// 获取<see cref="Byte"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public Byte GetByte(Int32 index)
        {
            if (OutOfRange(index, 1))
            {
                return 0;
            }
            return Bytes.Span[index];
        }

        /// <summary>
        /// 读取Bytes
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public Memory<Byte> GetBytes(Int32 index)
        {
            if (OutOfRange(index, 1))
            {
                return new Byte[0];
            }
            return Bytes.Slice(index);
        }

        /// <summary>
        /// 读取Bytes
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public Memory<Byte> GetBytes(Int32 index, Int32 length)
        {
            if (OutOfRange(index, length))
            {
                return new Byte[length];
            }
            return Bytes.Slice(index, length);
        }

        /// <summary>
        /// 获取<see cref="UInt16"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public UInt16 GetUInt16(Int32 index)
        {
            var span = GetBytes(index, 2).Span;
            if (IsLittleEndian)
            {
                return BinaryPrimitives.ReadUInt16LittleEndian(span);
            }
            return BinaryPrimitives.ReadUInt16BigEndian(span);
        }

        /// <summary>
        /// 获取<see cref="UInt16"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="bitIndex">bit的索引</param>
        /// <param name="bitLength">bit的长度</param>
        /// <returns></returns>
        public UInt16 GetUInt16(Int32 index, Int32 bitIndex, Int32 bitLength)
        {
            return GetUInt16(index).GetUInt16(bitIndex, bitLength);
        }

        /// <summary>
        /// 获取<see cref="UInt32"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public UInt32 GetUInt32(Int32 index)
        {
            var span = GetBytes(index, 4).Span;
            if (IsLittleEndian)
            {
                return BinaryPrimitives.ReadUInt32LittleEndian(span);
            }
            return BinaryPrimitives.ReadUInt32BigEndian(span);
        }

        /// <summary>
        /// 获取<see cref="UInt32"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="bitIndex">bit的索引</param>
        /// <param name="bitLength">bit的长度</param>
        /// <returns></returns>
        public UInt32 GetUInt32(Int32 index, Int32 bitIndex, Int32 bitLength)
        {
            return GetUInt32(index).GetUInt32(bitIndex, bitLength);
        }

        /// <summary>
        /// 获取<see cref="MACAddress"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public MACAddress GetMAC(Int32 index)
        {
            return new MACAddress
            {
                Bytes = GetBytes(index, MACAddress.Layout.Length)
            };
        }

        /// <summary>
        /// 获取IPv4<see cref="IPAddress"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public IPAddress GetIPv4(Int32 index)
        {
            return new IPAddress
            {
                Bytes = GetBytes(index, IPAddress.Layout.V4Length)
            };
        }

        /// <summary>
        /// 获取IPv6<see cref="IPAddress"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public IPAddress GetIPv6(Int32 index)
        {
            return new IPAddress
            {
                Bytes = GetBytes(index, IPAddress.Layout.V6Length)
            };
        }

        /// <summary>
        /// 设置指定位置的bit[1=true,0=false]
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="bitIndex">bit的索引[0-7]</param>
        /// <param name="value">bit的值</param>
        /// <returns></returns>
        public Byte SetBoolean(Int32 index, Int32 bitIndex, Boolean value)
        {
            var oldValue = GetByte(index);
            var newValue = oldValue.SetBoolean(bitIndex, value);
            return SetByte(index, newValue);
        }

        /// <summary>
        /// 设置<see cref="Byte"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="bitIndex">bit的索引</param>
        /// <param name="bitLength">bit的长度</param>
        /// <param name="value">byte的值</param>
        /// <returns></returns>
        public Byte SetByte(Int32 index, Int32 bitIndex, Int32 bitLength, Byte value)
        {
            var oldValue = GetByte(index);
            var newValue = oldValue.SetByte(bitIndex, bitLength, value);
            return SetByte(index, newValue);
        }

        /// <summary>
        /// 设置<see cref="Byte"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="byteValue">byte的值</param>
        /// <returns></returns>
        public Byte SetByte(Int32 index, Byte byteValue)
        {
            Bytes.Span[index] = byteValue;
            return byteValue;
        }

        /// <summary>
        /// 设置<see cref="UInt16"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="bitIndex">bit的索引</param>
        /// <param name="bitLength">bit的长度</param>
        /// <param name="value">UInt16的值</param>
        /// <returns></returns>
        public UInt16 SetUInt16(Int32 index, Int32 bitIndex, Int32 bitLength, UInt16 value)
        {
            var oldValue = GetUInt16(index);
            var newValue = oldValue.SetUInt16(bitIndex, bitLength, value);
            return SetUInt16(index, newValue);
        }

        /// <summary>
        /// 设置<see cref="UInt16"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public UInt16 SetUInt16(Int32 index, UInt16 value)
        {
            var span = GetBytes(index, 2).Span;
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
        /// <param name="bitIndex">bit的索引</param>
        /// <param name="bitLength">bit的长度</param>
        /// <param name="value">UInt32的值</param>
        /// <returns></returns>
        public UInt32 SetUInt32(Int32 index, Int32 bitIndex, Int32 bitLength, UInt32 value)
        {
            var oldValue = GetUInt32(index);
            var newValue = oldValue.SetUInt32(bitIndex, bitLength, value);
            return SetUInt32(index, newValue);
        }

        /// <summary>
        /// 设置<see cref="UInt32"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public UInt32 SetUInt32(Int32 index, UInt32 value)
        {
            var span = GetBytes(index, 4).Span;
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
        /// 设置<see cref="MACAddress"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public void SetMAC(Int32 index, MACAddress value)
        {
            SetBytes(index, MACAddress.Layout.Length, value.Bytes);
        }

        /// <summary>
        /// 设置IPv4<see cref="IPAddress"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public void SetIPv4(Int32 index, IPAddress value)
        {
            SetBytes(index, IPAddress.Layout.V4Length, value.Bytes);
        }

        /// <summary>
        /// 设置IPv6<see cref="IPAddress"/>
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public void SetIPv6(Int32 index, IPAddress value)
        {
            SetBytes(index, IPAddress.Layout.V6Length, value.Bytes);
        }

        /// <summary>
        /// 读取或写入
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="length">长度</param>
        /// <param name="bytes">bytes</param>
        /// <returns></returns>
        public void SetBytes(Int32 index, Int32 length, Memory<Byte> bytes)
        {
            bytes.CopyTo(Bytes.Slice(index, length));
        }

        /// <summary>
        /// 12-34-56-78-89-AB-CD-EF
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return BitConverter.ToString(Bytes.ToArray());
        }

        private Boolean OutOfRange(Int32 index, Int32 length)
        {
            return index + length > Length;
        }
    }
}
