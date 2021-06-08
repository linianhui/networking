using System;
using System.IO;
using Networking.Files;
using Networking.Files.Pcap;
using Networking.Files.PcapNG;

namespace Networking
{
    /// <summary>
    /// <see cref="PcapPacketReader"/>
    /// </summary>
    public static class PacketReaderExtensions
    {
        /// <summary>
        /// 获取<see cref="PcapPacketReader"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static PcapPacketReader GetPcapPacketReader(this Object @this, String fileName)
        {
            return GetPacketReader(@this, fileName) as PcapPacketReader;
        }

        /// <summary>
        /// 获取<see cref="PcapNGPacketReader"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static PcapNGPacketReader GetPcapNGPacketReader(this Object @this, String fileName)
        {
            return GetPacketReader(@this, fileName) as PcapNGPacketReader;
        }

        /// <summary>
        /// 获取<see cref="PacketReader"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static IPacketReader GetPacketReader(Object @this, String fileName)
        {
            return (new PacketReaderFactory()).Create(GetResourceStream(@this, fileName));
        }

        private static Stream GetResourceStream(Object @this, String fileName)
        {
            var type = @this.GetType();
            var resourceFileName = type.Namespace + "." + fileName;
            return type.Assembly.GetManifestResourceStream(resourceFileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static void ForEach(this PacketReader @this, Action<Memory<Byte>> action)
        {
            foreach (var packet in @this.ReadPackets())
            {
                action(packet.Payload);
            }
        }
    }
}
