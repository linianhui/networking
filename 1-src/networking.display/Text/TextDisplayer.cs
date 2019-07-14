using System;
using System.Collections.Generic;
using System.IO;
using Networking.Model.DataLink;
using Networking.Model.Internet;
using Networking.Model.Transport;

namespace Networking.Display.Text
{
    internal class TextDisplayer : IDisplayer
    {
        private readonly TextWriter _textWriter;

        public TextDisplayer(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public void NewLine(String message)
        {
            _textWriter.WriteLine(message);
        }

        public void Display(EthernetFrame ethernetFrame)
        {
            NewLine($"ethernet : {ethernetFrame.SourceMACAddress,17} > {ethernetFrame.DestinationMACAddress,-17} type={ethernetFrame.Type}");
            DisplayEthernetFramePayload(ethernetFrame.Type, ethernetFrame.Payload);
        }

        public void Display(IPv4Packet ipv4Packet)
        {
            NewLine($"ipv4     : {ipv4Packet.SourceIPAddress,17} > {ipv4Packet.DestinationIPAddress,-17} type={ipv4Packet.Type,-6} ttl={ipv4Packet.TTL,-3}");
            DisplayIPv4PacketPayload(ipv4Packet.Type, ipv4Packet.Payload);
        }

        public void Display(UDPDatagram udpDatagram)
        {
            NewLine($"udp      : {udpDatagram.SourcePort,17} > {udpDatagram.DestinationPort,-17}");
        }

        public void Display(TCPSegment tcpSegment)
        {
            NewLine($"tcp      : {tcpSegment.SourcePort,17} > {tcpSegment.DestinationPort,-17} win ={tcpSegment.WindowsSize,-6} seq={tcpSegment.SequenceNumber,-10} ack={tcpSegment.AcknowledgmentNumber,-10} flags=[{BuildFlags(tcpSegment)}]");
        }

        public void Display(ARPFrame arpFrame)
        {
            NewLine($"arp      : {arpFrame.SenderMACAddress,-17} {arpFrame.SenderIPAddress,-15} > {arpFrame.TargetMACAddress,17} {arpFrame.TargetIPAddress,-15} operation_code={arpFrame.OperationCode}");
        }

        public void Display(VLANFrame vlanFrame)
        {
            NewLine($"vlan     : vid={vlanFrame.VID,-5} type={vlanFrame.Type,-20}");
            DisplayEthernetFramePayload(vlanFrame.Type, vlanFrame.Payload);
        }

        public void Display(IPv6Packet ipv6Packet)
        {
            NewLine($"ipv6     : {ipv6Packet.SourceIPAddress} > {ipv6Packet.DestinationIPAddress}");
        }

        public void Display(ICMPv4Packet icmpv4Packet)
        {
            NewLine($"icmpv4   : id={icmpv4Packet.Id,-10} seq={icmpv4Packet.Sequence,-10} type_code={icmpv4Packet.TypeCode}");
        }

        public void Display(PPPoEFrame pppoeFrame)
        {
            NewLine($"pppoe    : version={pppoeFrame.Version,-3} type={pppoeFrame.Type,-3} code=[{pppoeFrame.Code,-4}] session_id={pppoeFrame.SessionId,-10} payload_length={pppoeFrame.PayloadLength}");
            Display(pppoeFrame.Payload);
        }

        public void Display(PPPFrame pppFrame)
        {
            NewLine($"ppp      : type={pppFrame.Type}");
            DisplayPPPFramePayload(pppFrame.Type, pppFrame.Payload);
        }

        private void DisplayEthernetFramePayload(EthernetFrameType ethernetFrameType, Octets ethernetFramePayload)
        {
            switch (ethernetFrameType)
            {
                case EthernetFrameType.IPv4:
                    Display((IPv4Packet)ethernetFramePayload);
                    break;
                case EthernetFrameType.ARP:
                    Display((ARPFrame)ethernetFramePayload);
                    break;
                case EthernetFrameType.IPv6:
                    Display((IPv6Packet)ethernetFramePayload);
                    break;
                case EthernetFrameType.VLAN:
                    Display((VLANFrame)ethernetFramePayload);
                    break;
                case EthernetFrameType.PPPoEDiscoveryStage:
                case EthernetFrameType.PPPoESessionStage:
                    Display((PPPoEFrame)ethernetFramePayload);
                    break;
            }
        }

        private void DisplayIPv4PacketPayload(IPPacketType ipPacketType, Octets ipPacketPayload)
        {
            switch (ipPacketType)
            {
                case IPPacketType.ICMPv4:
                    Display((ICMPv4Packet)ipPacketPayload);
                    break;
                case IPPacketType.UDP:
                    Display((UDPDatagram)ipPacketPayload);
                    break;
                case IPPacketType.TCP:
                    Display((TCPSegment)ipPacketPayload);
                    break;
            }
        }

        private void DisplayPPPFramePayload(PPPFrameType pppFrameType, Octets pppFramePayload)
        {
            switch (pppFrameType)
            {
                case PPPFrameType.IPv4:
                    Display((IPv4Packet)pppFramePayload);
                    break;
                case PPPFrameType.IPv6:
                    Display((IPv6Packet)pppFramePayload);
                    break;
            }
        }

        private static String BuildFlags(TCPSegment tcpSegment)
        {
            var flagList = new List<String>();
            if (tcpSegment.FlagNS)
            {
                flagList.Add("NS");
            }

            if (tcpSegment.FlagCWR)
            {
                flagList.Add("CWR");
            }

            if (tcpSegment.FlagECE)
            {
                flagList.Add("ECE");
            }

            if (tcpSegment.FlagURG)
            {
                flagList.Add("URG");
            }

            if (tcpSegment.FlagACK)
            {
                flagList.Add("ACK");
            }

            if (tcpSegment.FlagPSH)
            {
                flagList.Add("PSH");
            }

            if (tcpSegment.FlagRST)
            {
                flagList.Add("RST");
            }

            if (tcpSegment.FlagSYN)
            {
                flagList.Add("SYN");
            }

            if (tcpSegment.FlagFIN)
            {
                flagList.Add("FIN");
            }

            return String.Join(",", flagList.ToArray());
        }
    }
}
