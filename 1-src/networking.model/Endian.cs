using System;

namespace Networking.Model
{
    /// <summary>
    /// 字节序/端模式
    /// </summary>
    public enum Endian : Byte
    {
        /// <summary>
        /// 小端模式/主机字节序[高位字节存储在内存的高位]
        /// <para></para>
        /// <para>       0xA1B2C3D4        </para>
        /// <para>|  -  + 4 octets  +     |</para>
        /// <para>|  -  +  -  +  -  +  -  |</para>
        /// <para>|  0     1     2     3  |</para>
        /// <para>|  -  +  -  +  -  +  -  |</para>
        /// <para>| 0xD4  0xC3  0xB2  0xA1|</para>
        /// <para>|  -  +  -  +  -  +  -  |</para>
        /// <para></para>
        /// </summary>
        Little = 0,

        /// <summary>
        /// 大端模式/网络字节序[高位字节存储在内存的低位]
        /// <para></para>
        /// <para>       0xA1B2C3D4        </para>
        /// <para>|  -  + 4 octets  +     |</para>
        /// <para>|  -  +  -  +  -  +  -  |</para>
        /// <para>|  0     1     2     3  |</para>
        /// <para>|  -  +  -  +  -  +  -  |</para>
        /// <para>| 0xA1  0xB2  0xC3  0xD4|</para>
        /// <para>|  -  +  -  +  -  +  -  |</para>
        /// <para></para>
        /// </summary>
        Big = 1,
    }
}
