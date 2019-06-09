using System;
using Networking.Files.Pcap;

// ReSharper disable once CheckNamespace
namespace Networking.Model.Tests
{
    /// <summary>
    /// *.pcap文件扩展方法
    /// </summary>
    public static class PcapExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <param name="fileName"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static void PcapFileForEach(this Object @this, String fileName, Action<Byte[]> action)
        {
            var type = @this.GetType();
            var resourceFileName = type.Namespace + "." + fileName;
            var stream = type.Assembly.GetManifestResourceStream(resourceFileName);
            var pcapFile = new PcapFile(stream);

            foreach (var packet in pcapFile.ReadAllPackets())
            {
                action(packet.Data);
            }
        }
    }
}
