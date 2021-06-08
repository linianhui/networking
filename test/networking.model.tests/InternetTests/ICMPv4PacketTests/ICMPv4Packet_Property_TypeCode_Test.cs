using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.ICMPv4PacketTests
{
    public class ICMPv4Packet_Property_TypeCode_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { new Byte[]{ 0x08, 0x00 }, ICMPv4TypeCode.EchoRequest },
            new Object[] { new Byte[]{ 0x00, 0x00 }, ICMPv4TypeCode.EchoResponse },
            new Object[] { new Byte[]{ 0x03, 0x00 }, ICMPv4TypeCode.DestinationUnreachableOfNetwork },
            new Object[] { new Byte[]{ 0x03, 0x01 }, ICMPv4TypeCode.DestinationUnreachableOfHost },
            new Object[] { new Byte[]{ 0x03, 0x02 }, ICMPv4TypeCode.DestinationUnreachableOfProtocol },
            new Object[] { new Byte[]{ 0x03, 0x03 }, ICMPv4TypeCode.DestinationUnreachableOfPort },
            new Object[] { new Byte[]{ 0x03, 0x04 }, ICMPv4TypeCode.DestinationUnreachableOfFragmentationRequired },
            new Object[] { new Byte[]{ 0x03, 0x05 }, ICMPv4TypeCode.DestinationUnreachableOfSourceRouteFailed },
            new Object[] { new Byte[]{ 0x03, 0x06 }, ICMPv4TypeCode.DestinationUnreachableOfNetworkUnknown },
            new Object[] { new Byte[]{ 0x03, 0x07 }, ICMPv4TypeCode.DestinationUnreachableOfHostUnknown },
            new Object[] { new Byte[]{ 0x03, 0x08 }, ICMPv4TypeCode.DestinationUnreachableOfSourceHostIsolated },
            new Object[] { new Byte[]{ 0x03, 0x09 }, ICMPv4TypeCode.DestinationUnreachableOfNetworkAdministrativelyProhibited },
            new Object[] { new Byte[]{ 0x03, 0x0A }, ICMPv4TypeCode.DestinationUnreachableOfHostAdministrativelyProhibited },
            new Object[] { new Byte[]{ 0x03, 0x0B }, ICMPv4TypeCode.DestinationUnreachableOfNetworkTos },
            new Object[] { new Byte[]{ 0x03, 0x0C }, ICMPv4TypeCode.DestinationUnreachableOfHostTos },
            new Object[] { new Byte[]{ 0x03, 0x0D }, ICMPv4TypeCode.DestinationUnreachableOfCommunicationAdministrativelyProhibited },
            new Object[] { new Byte[]{ 0x03, 0x0E }, ICMPv4TypeCode.DestinationUnreachableOfHostPrecedenceViolation },
            new Object[] { new Byte[]{ 0x03, 0x0F }, ICMPv4TypeCode.DestinationUnreachableOfPrecedenceCutoffInEffect },
            new Object[] { new Byte[]{ 0x05, 0x00 }, ICMPv4TypeCode.RedirectMessageOfNetwork },
            new Object[] { new Byte[]{ 0x05, 0x01 }, ICMPv4TypeCode.RedirectMessageOfHost },
            new Object[] { new Byte[]{ 0x05, 0x02 }, ICMPv4TypeCode.RedirectMessageOfTosAndNetwork },
            new Object[] { new Byte[]{ 0x05, 0x03 }, ICMPv4TypeCode.RedirectMessageOfTosAndHost },
            new Object[] { new Byte[]{ 0x0B, 0x00 }, ICMPv4TypeCode.TimeExceededOfTTLExpiredInTransit },
            new Object[] { new Byte[]{ 0x0B, 0x01 }, ICMPv4TypeCode.TimeExceededOfFragmentReassemblyTimeExceeded },
            new Object[] { new Byte[]{ 0x0D, 0x00 }, ICMPv4TypeCode.TimestampRequest },
            new Object[] { new Byte[]{ 0x0E, 0x00 }, ICMPv4TypeCode.TimestampResponse },
            new Object[] { new Byte[]{ 0x2A, 0x00 }, ICMPv4TypeCode.ExtendedEchoRequest },
            new Object[] { new Byte[]{ 0x2B, 0x00 }, ICMPv4TypeCode.ExtendedEchoResponseOfNoError },
            new Object[] { new Byte[]{ 0x2B, 0x01 }, ICMPv4TypeCode.ExtendedEchoResponseOfMalformedQuery },
            new Object[] { new Byte[]{ 0x2B, 0x02 }, ICMPv4TypeCode.ExtendedEchoResponseOfNoSuchInterface },
            new Object[] { new Byte[]{ 0x2B, 0x03 }, ICMPv4TypeCode.ExtendedEchoResponseOfNoSuchTableEntry },
            new Object[] { new Byte[]{ 0x2B, 0x04 }, ICMPv4TypeCode.ExtendedEchoResponseOfMultipleInterfacesSatisfyQuery },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte[] input, ICMPv4TypeCode expected)
        {
            var icmpv4Packet = new ICMPv4Packet
            {
                Bytes = new Byte[32]
            };

            icmpv4Packet.SetBytes(0, 2, input);

            icmpv4Packet.TypeCode.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte[] expected, ICMPv4TypeCode input)
        {
            var icmpv4Packet = new ICMPv4Packet
            {
                Bytes = new Byte[32]
            };

            icmpv4Packet.TypeCode = input;
            icmpv4Packet.GetBytes(0, 2).ToArray().Should().Equal(expected);
            icmpv4Packet.TypeCode.Should().Be(input);
        }
    }
}
