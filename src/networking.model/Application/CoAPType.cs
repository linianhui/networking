using System;

namespace Networking.Model.Application
{
    /// <summary>
    /// <see cref="CoAP"/>的类型
    /// </summary>
    public enum CoAPType : Byte
    {
        /// <summary>
        /// Confirmable
        /// </summary>
        Confirmable = 0,

        /// <summary>
        /// Non-confirmable
        /// </summary>
        NonConfirmable = 1,

        /// <summary>
        /// Acknowledgement 
        /// </summary>
        Acknowledgement = 2,

        /// <summary>
        /// Reset  
        /// </summary>
        Reset = 3
    }
}
