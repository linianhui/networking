using System;

namespace Networking
{
    /// <summary>
    /// bit操作
    /// </summary>
    public static class Bits
    {
        /// <summary>
        /// 获取指定位置的bit[1=true,0=false]
        /// </summary>
        /// <param name="this">this</param>
        /// <param name="bitIndex">bit的索引[0-7]</param>
        /// <returns></returns>
        public static Boolean GetBoolean(this Byte @this, Int32 bitIndex)
        {
            return GetUInt32(@this, bitIndex + 24, 1) == 1;
        }

        /// <summary>
        /// 获取指定位置的bits组成的<see cref="Byte"/>
        /// </summary>
        /// <param name="this">this</param>
        /// <param name="bitIndex">bit的索引[0-7]</param>
        /// <param name="bitLength">bit的长度[0-8]</param>
        /// <returns></returns>
        public static Byte GetByte(this Byte @this, Int32 bitIndex, Int32 bitLength)
        {
            return (Byte)GetUInt32(@this, bitIndex + 24, bitLength);
        }

        /// <summary>
        /// 获取指定位置的bits组成的<see cref="UInt16"/>
        /// </summary>
        /// <param name="this">this</param>
        /// <param name="bitIndex">bit的索引[0-15]</param>
        /// <param name="bitLength">bit的长度[0-16]</param>
        /// <returns></returns>
        public static UInt16 GetUInt16(this UInt16 @this, Int32 bitIndex, Int32 bitLength)
        {
            return (UInt16)GetUInt32(@this, bitIndex + 16, bitLength);
        }

        /// <summary>
        /// 获取指定位置的bits组成的<see cref="UInt32"/>
        /// </summary>
        /// <param name="this">this</param>
        /// <param name="bitIndex">bit的索引[0-31]</param>
        /// <param name="bitLength">bit的长度[0-32]</param>
        /// <returns></returns>
        public static UInt32 GetUInt32(this UInt32 @this, Int32 bitIndex, Int32 bitLength)
        {
            if (bitLength == 0)
            {
                return 0;
            }

            var leftShiftResult = @this << bitIndex;
            var rightShiftLength = 32 - bitLength;
            return leftShiftResult >> rightShiftLength;
        }

        /// <summary>
        /// 设置指定位置的bit[1=true,0=false]
        /// </summary>
        /// <param name="this">this</param>
        /// <param name="bitIndex">bit的索引[0-7]</param>
        /// <param name="value">bit的值</param>
        /// <returns></returns>
        public static Byte SetBoolean(this Byte @this, Int32 bitIndex, Boolean value)
        {
            return (Byte)SetUInt32(@this, bitIndex + 24, 1, value ? 1u : 0u);
        }

        /// <summary>
        /// 设置指定位置的bits
        /// </summary>
        /// <param name="this">this</param>
        /// <param name="bitIndex">bit的索引[0-7]</param>
        /// <param name="bitLength">bit的长度[0-8]</param>
        /// <param name="value">值[8-bitLength~7]bits</param>
        /// <returns></returns>
        public static Byte SetByte(this Byte @this, Int32 bitIndex, Int32 bitLength, Byte value)
        {
            return (Byte)SetUInt32(@this, bitIndex + 24, bitLength, value);
        }

        /// <summary>
        /// 设置指定位置的bits
        /// </summary>
        /// <param name="this">this</param>
        /// <param name="bitIndex">bit的索引[0-15]</param>
        /// <param name="bitLength">bit的长度[0-16]</param>
        /// <param name="value">值[16-bitLength~15]bits</param>
        /// <returns></returns>
        public static UInt16 SetUInt16(this UInt16 @this, Int32 bitIndex, Int32 bitLength, UInt16 value)
        {
            return (UInt16)SetUInt32(@this, bitIndex + 16, bitLength, value);
        }

        /// <summary>
        /// 设置指定位置的bits
        /// </summary>
        /// <param name="this">this</param>
        /// <param name="bitIndex">bit的索引[0-31]</param>
        /// <param name="bitLength">bit的长度[0-32]</param>
        /// <param name="value">值[32-bitLength~31]bits</param>
        /// <returns></returns>
        public static UInt32 SetUInt32(this UInt32 @this, Int32 bitIndex, Int32 bitLength, UInt32 value)
        {
            var mask = ~0u << 32 - bitLength;
            mask >>= bitIndex;
            mask = ~mask;

            var bits = value << 32 - bitLength;
            bits >>= bitIndex;

            return @this & mask | bits;
        }
    }
}
