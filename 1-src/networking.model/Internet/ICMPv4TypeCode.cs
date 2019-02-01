using System;

namespace Networking.Model.Internet
{
    /// <summary>
    /// ICMPv4类型编号
    /// <see href="https://en.wikipedia.org/wiki/internet_control_message_protocol#datagram_structure"/>
    /// </summary>
    public enum ICMPv4TypeCode : UInt16
    {

        #region Echo

        /// <summary>
        /// Echo Request
        /// </summary>
        EchoRequest = 0x0800,

        /// <summary>
        /// Echo Response
        /// </summary>
        EchoResponse = 0x0000,

        #endregion


        #region Destination unreachable

        /// <summary>
        /// Destination network unreachable
        /// </summary>
        DestinationUnreachableOfNetwork = 0x0300,

        /// <summary>
        /// Destination host unreachable
        /// </summary>
        DestinationUnreachableOfHost = 0x0301,

        /// <summary>
        /// Destination protocol unreachable
        /// </summary>
        DestinationUnreachableOfProtocol = 0x0302,

        /// <summary>
        /// Destination port unreachable
        /// </summary>
        DestinationUnreachableOfPort = 0x0303,

        /// <summary>
        /// Fragmentation required, and DF flag set 
        /// </summary>
        DestinationUnreachableOfFragmentationRequired = 0x0304,

        /// <summary>
        /// Source route failed 
        /// </summary>
        DestinationUnreachableOfSourceRouteFailed = 0x0305,

        /// <summary>
        /// Destination network unknown
        /// </summary>
        DestinationUnreachableOfNetworkUnknown  = 0x0306,

        /// <summary>
        /// Destination host unknown
        /// </summary>
        DestinationUnreachableOfHostUnknown = 0x0307,

        /// <summary>
        /// Source host isolated
        /// </summary>
        DestinationUnreachableOfSourceHostIsolated = 0x0308,

        /// <summary>
        /// Network administratively prohibited
        /// </summary>
        DestinationUnreachableOfNetworkAdministrativelyProhibited  = 0x0309,

        /// <summary>
        /// Host administratively prohibited 
        /// </summary>
        DestinationUnreachableOfHostAdministrativelyProhibited = 0x030A,

        /// <summary>
        /// Network unreachable for ToS
        /// </summary>
        DestinationUnreachableOfNetworkTos = 0x030B,

        /// <summary>
        /// Host unreachable for ToS
        /// </summary>
        DestinationUnreachableOfHostTos = 0x030C,

        /// <summary>
        /// Communication administratively prohibited
        /// </summary>
        DestinationUnreachableOfCommunicationAdministrativelyProhibited = 0x030D,

        /// <summary>
        /// Host Precedence Violation
        /// </summary>
        DestinationUnreachableOfHostPrecedenceViolation = 0x030E,

        /// <summary>
        /// Precedence cutoff in effect 
        /// </summary>
        DestinationUnreachableOfPrecedenceCutoffInEffect = 0x030F,

        #endregion
    }
}
