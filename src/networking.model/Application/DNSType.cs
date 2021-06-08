using System;

namespace Networking.Model.Application
{
    /// <summary>
    /// <see cref="DNS"/>的类型
    /// </summary>
    public enum DNSType : Byte
    {
        /// <summary>
        /// Query
        /// </summary>
        Query = 0,

        /// <summary>
        /// Response
        /// </summary>
        Response = 1,
    }
}
