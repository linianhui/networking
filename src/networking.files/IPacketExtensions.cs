using Networking.Model;

namespace Networking.Files
{
    /// <summary>
    /// <see cref="IPacket"/>的扩展方法
    /// </summary>
    public static class IPacketExtensions
    {
        /// <summary>
        /// 转换为PDU
        /// </summary>
        /// <returns>PDU基类</returns>
        public static Octets ToPDU(this IPacket @this)
        {
            return PDUFactory.Create(@this.DataLinkType, @this.Payload);
        }
    }
}
