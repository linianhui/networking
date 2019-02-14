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
        /// <param name="index">索引</param>
        /// <returns></returns>
        public static Boolean GetBit(this Byte @this, Byte index)
        {
            return (@this >> (7 - index) & 1) == 1;
        }

        /// <summary>
        /// 设置指定位置的bit[1=true,0=false]
        /// </summary>
        /// <param name="this">this</param>
        /// <param name="index">索引</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static Byte SetBit(this Byte @this, Byte index, Boolean value)
        {
            var byteValue = B_1000_0000 >> index;
            if (value)
            {
                return (Byte)(@this | byteValue);
            }
            return (Byte)~(~@this | byteValue);
        }
    }
}
