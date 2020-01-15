using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.DataLink;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.VLANFrameTests
{
    public class VLANFrame_Property_Payload_Test
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
            var vlanFrame = new VLANFrame
            {
                Bytes = new Byte[32]
            };

            vlanFrame.Type = input;

            vlanFrame.Payload.GetType().Should().Be(excepted);
        }
    }
}
