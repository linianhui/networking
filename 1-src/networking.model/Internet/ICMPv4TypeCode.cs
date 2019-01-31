using System;

namespace Networking.Model.Internet
{
    /// <summary>
    /// ICMPv4类型编号
    /// </summary>
    public enum ICMPv4TypeCode : UInt16
    {
        /// <summary>
        /// Echo Request
        /// </summary>
        EchoRequest = 0x0800,

        /// <summary>
        /// Echo Response
        /// </summary>
        EchoResponse = 0x0000,
    }
}
