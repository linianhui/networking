using System;
using System.Buffers.Binary;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// 
    /// </summary>
    internal static class Timestamp
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isLittleEndian"></param>
        /// <param name="isNanosecnod"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        internal static UInt64 ToTimestampNanosecond(Boolean isLittleEndian, Boolean isNanosecnod,
            ReadOnlySpan<Byte> bytes)
        {
            var timestampNanosecond = 0UL;
            if (isLittleEndian)
            {
                var bytesLE = new Byte[8];
                bytesLE[0] = bytes[4];
                bytesLE[1] = bytes[5];
                bytesLE[2] = bytes[6];
                bytesLE[3] = bytes[7];
                bytesLE[4] = bytes[0];
                bytesLE[5] = bytes[1];
                bytesLE[6] = bytes[2];
                bytesLE[7] = bytes[3];
                timestampNanosecond = BinaryPrimitives.ReadUInt64LittleEndian(bytesLE);
            }
            else
            {
                timestampNanosecond = BinaryPrimitives.ReadUInt64BigEndian(bytes);
            }

            if (isNanosecnod == false)
            {
                timestampNanosecond *= 1000;
            }

            return timestampNanosecond;
        }
    }
}
