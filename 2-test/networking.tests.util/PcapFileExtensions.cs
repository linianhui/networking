using System;
using Networking.Files.Pcap;

namespace Networking
{
    /// <summary>
    /// *.pcap文件扩展方法
    /// </summary>
    public static class PcapFileExtensions
    {
        /// <summary>
        /// 获取<see cref="PcapFile"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static PcapFile GetPcapFile(this Object @this, String fileName)
        {
            var type = @this.GetType();
            var resourceFileName = type.Namespace + "." + fileName;
            var stream = type.Assembly.GetManifestResourceStream(resourceFileName);
            return new PcapFile(stream);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <param name="fileName"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static void PcapFileForEach(this Object @this, String fileName, Action<Memory<Byte>> action)
        {
            var pcapFile = @this.GetPcapFile(fileName);

            foreach (var packet in pcapFile.ReadAllPackets())
            {
                action(packet.Payload);
            }
        }
    }
}
