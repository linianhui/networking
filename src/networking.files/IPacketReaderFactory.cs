using System;
using System.IO;

namespace Networking.Files
{
    /// <summary>
    /// <see cref="IPacketReader"/>
    /// </summary>
    public interface IPacketReaderFactory
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="filePath">绝对文件路径</param>
        /// <returns></returns>
        IPacketReader Create(String filePath);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns></returns>
        IPacketReader Create(Byte[] bytes);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="stream">流</param>
        /// <returns></returns>
        IPacketReader Create(Stream stream);
    }
}
