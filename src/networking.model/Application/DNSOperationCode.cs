using System;

namespace Networking.Model.Application
{
    /// <summary>
    /// <see cref="DNS"/>的操作类型
    /// </summary>
    public enum DNSOperationCode : Byte
    {
        /// <summary>
        /// Standard Query
        /// </summary>
        StandardQuery = 0,

        /// <summary>
        /// Inverse Query
        /// </summary>
        InverseQuery = 1,

        /// <summary>
        /// Server status request
        /// </summary>
        ServerStatusRequest = 2
    }
}
