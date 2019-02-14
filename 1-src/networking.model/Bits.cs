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
        /// <param name="index">索引[0-7]</param>
        /// <returns></returns>
        public static Boolean GetBit(this Byte @this, Byte index)
        {
            CheckIndex(index);
            var bits = B_1000_0000 >> index;
            return (@this & bits) == bits;
        }

        /// <summary>
        /// 设置指定位置的bit[1=true,0=false]
        /// </summary>
        /// <param name="this">this</param>
        /// <param name="index">索引[0-7]</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static Byte SetBit(this Byte @this, Byte index, Boolean value)
        {
            CheckIndex(index);
            var bits = B_1000_0000 >> index;
            if (value)
            {
                return (Byte)(@this | bits);
            }
            return (Byte)(~((~@this) | bits));
        }

        /// <summary>
        /// 获取指定位置的bits
        /// </summary>
        /// <param name="this">this</param>
        /// <param name="index">索引[0-7]</param>
        /// <param name="length">长度[0-8]</param>
        /// <returns></returns>
        public static Byte GetSubByte(this Byte @this, Byte index, Byte length)
        {
            CheckIndexAndLength(index, length);

            var leftShiftResult = (Byte)(@this << index);
            var rightShift = 8 - length;
            return (Byte)(leftShiftResult >> rightShift);
        }

        private static void CheckIndexAndLength(Byte index, Byte length)
        {
            CheckIndex(index);
            if (index + length > 8)
            {
                throw new IndexOutOfRangeException(
                    $"{nameof(index)}+{nameof(length)}={index}+{length}={index + length} greater than 8.");
            }
        }

        private static void CheckIndex(Byte index)
        {
            if (index > 7)
            {
                throw new IndexOutOfRangeException($"{nameof(index)}={index} not in [0-7].");
            }
        }
    }
}
