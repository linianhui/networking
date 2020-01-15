using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.DataLink;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.EthernetFrameTests
{
    public class EthernetFrame_Property_Payload_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { EthernetFrameType.ARP , typeof(ARPFrame) },
            new Object[] { EthernetFrameType.IPv4 , typeof(IPv4Packet) },
            new Object[] { EthernetFrameType.IPv6 , typeof(IPv6Packet) },
            new Object[] { EthernetFrameType.PPPoEDiscoveryStage , typeof(PPPoEFrame) },
            new Object[] { EthernetFrameType.PPPoESessionStage , typeof(PPPoEFrame) },
            new Object[] { EthernetFrameType.VLAN , typeof(VLANFrame) },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(EthernetFrameType input, Type excepted)
        {
            var ethernetFrame = new EthernetFrame
            {
                Bytes = new Byte[64]
            };

            ethernetFrame.Type = input;

            ethernetFrame.Payload.GetType().Should().Be(excepted);
        }
    }
}
