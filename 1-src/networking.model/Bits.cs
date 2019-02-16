using System;

namespace Networking.Model
{
    /// <summary>
    /// bit操作
    /// </summary>
    public static class Bits
    {
        /// <summary>
        /// 15=0x0F=0B_0000_1111
        /// </summary>
        public const Byte B_0000_1111 = 0B_0000_1111;

        /// <summary>
        /// 128=0x80=0B_1000_0000
        /// </summary>
        public const Byte B_1000_0000 = 0B_1000_0000;

        /// <summary>
        /// 240=0xF0=0B_1111_0000
        /// </summary>
        public const Byte B_1111_0000 = 0B_1111_0000;

        /// <summary>
        /// 获取指定位置的bit[1=true,0=false]
        /// </summary>
        /// <param name="this">this</param>
        /// <param name="bitIndex">bit的索引[0-7]</param>
        /// <returns></returns>
        public static Boolean GetBit(this Byte @this, Int32 bitIndex)
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
        /// <param name="bitValue">bit的值</param>
        /// <returns></returns>
        public static Byte SetBit(this Byte @this, Int32 bitIndex, Boolean bitValue)
        {
            var bits = B_1000_0000 >> bitIndex;
            if (bitValue)
            {
                return (Byte)(@this | bits);
            }
            return (Byte)(@this & ((Byte)~bits));
        }
    }
}
