using System;

namespace Networking.Model.Internet
{
    /// <summary>
    /// ICMPv6类型
    /// <see href="http://www.iana.org/assignments/icmpv6-parameters"/>
    /// </summary>
    public enum ICMPv6Type : Byte
    {
        /// <summary>
        /// Destination Unreachable
        /// </summary>
        DestinationUnreachable = 1,

        /// <summary>
        /// Time Exceeded
        /// </summary>
        TimeExceeded = 3,

        /// <summary>
        /// Echo Request
        /// </summary>
        EchoRequest = 128,

        /// <summary>
        /// Echo Response
        /// </summary>
        EchoResponse = 129,
    }
}
