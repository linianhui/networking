using System;
using Networking.Files;
using Networking.Files.Pcap;

namespace Networking
{
    /// <summary>
    /// *.pcap文件扩展方法
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
            var type = @this.GetType();
            var resourceFileName = type.Namespace + "." + fileName;
            var stream = type.Assembly.GetManifestResourceStream(resourceFileName);
            return new PcapFileReader(stream);
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
