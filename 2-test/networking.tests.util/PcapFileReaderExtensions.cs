using System;
using System.IO;
using Networking.Files;
using Networking.Files.Pcap;
using Networking.Files.PcapNG;

namespace Networking
{
    /// <summary>
    /// <see cref="PcapFileReader"/>
    /// </summary>
    public static class PcapFileReaderExtensions
    {
        /// <summary>
        /// 获取<see cref="PcapFileReader"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static PcapFileReader GetPcapFileReader(this Object @this, String fileName)
        {
            return new PcapFileReader(GetResourceStream(@this, fileName));
        }

        /// <summary>
        /// 获取<see cref="PcapNGFileReader"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static PcapNGFileReader GetPcapNGFileReader(this Object @this, String fileName)
        {
            return new PcapNGFileReader(GetResourceStream(@this, fileName));
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
