using System;

namespace Networking.Model.Application
{
    /// <summary>
    /// <see cref="DNS"/>的响应码
    /// </summary>
    public enum DNSResponseCode : Byte
    {
        /// <summary>
        /// No error condition
        /// </summary>
        NoError = 0,

        /// <summary>
        /// Format error
        /// </summary>
        FormatError = 1,

        /// <summary>
        /// Server failure
        /// </summary>
        ServerFailure = 2,

        /// <summary>
        /// Name Error
        /// </summary>
        NameError = 3,

        /// <summary>
        /// Not Implemented.
        /// </summary>
        NotImplemented = 4,

        /// <summary>
        /// Refused
        /// </summary>
        Refused = 5
    }
}
