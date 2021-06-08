using System;

namespace Networking.Files
{
    /// <summary>
    /// <see cref="UInt64"/>的扩展方法
    /// </summary>
    public static class UInt64Extensions
    {
        private static readonly DateTimeOffset _zero = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

        /// <summary>
        /// 获取<see cref="DateTimeOffset"/>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this UInt64 @this)
        {
            return _zero.AddTicks((Int64)@this / 100);
        }

        /// <summary>
        /// 获取<see cref="DateTimeOffset"/>的ToString
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static String ToDateTimeOffsetString(this UInt64 @this)
        {
            return @this.ToDateTimeOffset().ToString("yyyy-MM-dd HH:mm:ss.fffffff");
        }
    }
}
