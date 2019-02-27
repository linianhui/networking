using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.DataLink;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.IEEE8021QFrameTests
{
    public class IEEE8021QFrame_Property_Payload_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { EthernetFrameType.ARP , typeof(ARPFrame) },
            new Object[] { EthernetFrameType.IPv4 , typeof(IPv4Packet) },
            new Object[] { EthernetFrameType.IPv6 , typeof(IPv6Packet) },
            new Object[] { EthernetFrameType.PPPoEDiscoveryStage , typeof(PPPoEFrame) },
            new Object[] { EthernetFrameType.PPPoESessionStage , typeof(PPPoEFrame) },
            new Object[] { EthernetFrameType.IEEE8021Q , typeof(IEEE8021QFrame) },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(EthernetFrameType input, Type excepted)
        {
            var ieee8021QFrame = new IEEE8021QFrame
            {
                Bytes = new Byte[32]
            };

            ieee8021QFrame.Type = input;

            ieee8021QFrame.Payload.GetType().Should().Be(excepted);
        }
    }
}
