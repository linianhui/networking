using System;

namespace Networking
{
    /// <summary>
    /// byte扩展方法
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        /// 填充到指定的长度
        /// </summary>
        /// <param name="this"></param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static Byte[] PaddingEndToLength(this Byte[] @this, Int32 length)
        {
            var result = new Byte[length];
            @this.CopyTo(result, 0);
            return result;
        }
    }
}
