using System;

namespace Networking.Model.Internet
{
    /// <summary>
    /// ICMPv4类型编号
    /// <see href="https://en.wikipedia.org/wiki/Internet_Control_Message_Protocol#Datagram_structure"/>
    /// </summary>
    public enum ICMPv4TypeCode : UInt16
    {

        #region Echo

        /// <summary>
        /// Echo : Request
        /// </summary>
        EchoRequest = 0x0800,

        /// <summary>
        /// Echo : Response
        /// </summary>
        EchoResponse = 0x0000,

        #endregion


        #region Destination Unreachable

        /// <summary>
        /// Destination Unreachable : Destination network unreachable
        /// </summary>
        DestinationUnreachableOfNetwork = 0x0300,

        /// <summary>
        /// Destination Unreachable : Destination host unreachable
        /// </summary>
        DestinationUnreachableOfHost = 0x0301,

        /// <summary>
        /// Destination Unreachable : Destination protocol unreachable
        /// </summary>
        DestinationUnreachableOfProtocol = 0x0302,

        /// <summary>
        /// Destination Unreachable : Destination port unreachable
        /// </summary>
        DestinationUnreachableOfPort = 0x0303,

        /// <summary>
        /// Destination Unreachable : Fragmentation required, and DF flag set
        /// </summary>
        DestinationUnreachableOfFragmentationRequired = 0x0304,

        /// <summary>
        /// Destination Unreachable : Source route failed
        /// </summary>
        DestinationUnreachableOfSourceRouteFailed = 0x0305,

        /// <summary>
        /// Destination Unreachable : Destination network unknown
        /// </summary>
        DestinationUnreachableOfNetworkUnknown = 0x0306,

        /// <summary>
        /// Destination Unreachable : Destination host unknown
        /// </summary>
        DestinationUnreachableOfHostUnknown = 0x0307,

        /// <summary>
        /// Destination Unreachable : Source host isolated
        /// </summary>
        DestinationUnreachableOfSourceHostIsolated = 0x0308,

        /// <summary>
        /// Destination Unreachable : Network administratively prohibited
        /// </summary>
        DestinationUnreachableOfNetworkAdministrativelyProhibited = 0x0309,

        /// <summary>
        /// Destination Unreachable : Host administratively prohibited
        /// </summary>
        DestinationUnreachableOfHostAdministrativelyProhibited = 0x030A,

        /// <summary>
        /// Destination Unreachable : Network unreachable for ToS
        /// </summary>
        DestinationUnreachableOfNetworkTos = 0x030B,

        /// <summary>
        /// Destination Unreachable : Host unreachable for ToS
        /// </summary>
        DestinationUnreachableOfHostTos = 0x030C,

        /// <summary>
        /// Destination Unreachable : Communication administratively prohibited
        /// </summary>
        DestinationUnreachableOfCommunicationAdministrativelyProhibited = 0x030D,

        /// <summary>
        /// Destination Unreachable : Host Precedence Violation
        /// </summary>
        DestinationUnreachableOfHostPrecedenceViolation = 0x030E,

        /// <summary>
        /// Destination Unreachable : Precedence cutoff in effect
        /// </summary>
        DestinationUnreachableOfPrecedenceCutoffInEffect = 0x030F,

        #endregion

        #region Redirect Message

        /// <summary>
        /// Redirect Message : Redirect Datagram for the Network
        /// </summary>
        RedirectMessageOfNetwork = 0x0500,

        /// <summary>
        /// Redirect Message : Redirect Datagram for the Host
        /// </summary>
        RedirectMessageOfHost = 0x0501,

        /// <summary>
        /// Redirect Message : Redirect Datagram for the ToS and Network
        /// </summary>
        RedirectMessageOfTosAndNetwork = 0x0502,

        /// <summary>
        /// Redirect Message : Redirect Datagram for the ToS and Host
        /// </summary>
        RedirectMessageOfTosAndHost = 0x0503,

        #endregion


        #region Time Exceeded

        /// <summary>
        /// Time Exceeded : TTL expired in transit
        /// </summary>
        TimeExceededOfTTLExpiredInTransit = 0x0B00,

        /// <summary>
        /// Time Exceeded : Fragment reassembly time exceeded
        /// </summary>
        TimeExceededOfFragmentReassemblyTimeExceeded = 0x0B01,

        #endregion


        #region Timestamp

        /// <summary>
        /// Timestamp : Request
        /// </summary>
        TimestampRequest = 0x0D00,

        /// <summary>
        /// Timestamp : Response
        /// </summary>
        TimestampResponse = 0x0E00,

        #endregion


        #region Extended Echo

        /// <summary>
        /// Extended Echo Request : No Error
        /// </summary>
        ExtendedEchoRequest = 0x2A00,

        /// <summary>
        /// Extended Echo Response : No Error
        /// </summary>
        ExtendedEchoResponseOfNoError = 0x2B00,

        /// <summary>
        /// Extended Echo Response : Malformed Query
        /// </summary>
        ExtendedEchoResponseOfMalformedQuery = 0x2B01,

        /// <summary>
        /// Extended Echo Response : No Such Interface
        /// </summary>
        ExtendedEchoResponseOfNoSuchInterface = 0x2B02,

        /// <summary>
        /// Extended Echo Response : No Such Table Entry
        /// </summary>
        ExtendedEchoResponseOfNoSuchTableEntry = 0x2B03,

        /// <summary>
        /// Extended Echo Response : Multiple Interfaces Satisfy Query
        /// </summary>
        ExtendedEchoResponseOfMultipleInterfacesSatisfyQuery = 0x2B04,

        #endregion


    }
}
