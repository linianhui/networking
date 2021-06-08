using System;

namespace Networking.Model.DataLink
{

    /// <summary>
    /// <see cref="ARPFrame"/>操作码
    /// </summary>
    public enum ARPOperationCode : UInt16
    {
        /// <summary>
        /// Request
        /// </summary>
        Request = 1,

        /// <summary>
        /// Response
        /// </summary>
        Response = 2
    }
}
