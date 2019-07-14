using System;
using Networking.Model.DataLink;
using Networking.Model.Internet;
using Networking.Model.Transport;

namespace Networking.Display
{
    /// <summary>
    /// 显示器
    /// </summary>
    public interface IDisplayer
    {
        /// <summary>
        /// 新行
        /// </summary>
        void NewLine(String message = "");

        /// <summary>
        /// 显示
        /// </summary>
        void Display(EthernetFrame ethernetFrame);

        /// <summary>
        /// 显示
        /// </summary>
        void Display(ARPFrame arpFrame);

        /// <summary>
        /// 显示
        /// </summary>
        void Display(IPv4Packet ipv4Packet);

        /// <summary>
        /// 显示
        /// </summary>
        void Display(ICMPv4Packet icmpv4Packet);

        /// <summary>
        /// 显示
        /// </summary>
        void Display(UDPDatagram udpDatagram);

        /// <summary>
        /// 显示
        /// </summary>
        void Display(TCPSegment tcpSegment);

        /// <summary>
        /// 显示
        /// </summary>
        void Display(IPv6Packet ipv6Packet);

        /// <summary>
        /// 显示
        /// </summary>
        void Display(VLANFrame vlanFrame);

        /// <summary>
        /// 显示
        /// </summary>
        void Display(PPPoEFrame pppoeFrame);

        /// <summary>
        /// 显示
        /// </summary>
        void Display(PPPFrame pppFrame);
    }
}
