using System;

namespace Networking.Model.Internet
{
    /// <summary>
    /// ICMPv6类型编号
    /// <see href="http://www.iana.org/assignments/icmpv6-parameters"/>
    /// </summary>
    public enum ICMPv6TypeCode : UInt16
    {
        #region Echo

        /// <summary>
        /// Echo Request
        /// </summary>
        EchoRequest = 0x8000,

        /// <summary>
        /// Echo Response
        /// </summary>
        EchoResponse = 0x8100,

        #endregion


        #region Destination Unreachable

        /// <summary>
        /// Destination Unreachable : no route to destination
        /// </summary>
        DestinationUnreachableOfNoRoute = 0x0100,

        #endregion


        #region Time Exceeded

        /// <summary>
        /// Time Exceeded : hop limit exceeded in transit
        /// </summary>
        TimeExceededOfHopLimitExceededInTransit = 0x0300,

        /// <summary>
        /// Time Exceeded : fragment reassembly time exceeded
        /// </summary>
        TimeExceededOfFragmentReassembly = 0x0301,

        #endregion
    }
}
