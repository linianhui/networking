using System;

namespace Networking.Model.DataLink
{
    /// <summary>
    /// <see cref="PPPoEFrame"/>的编号
    /// </summary>
    public enum PPPoEFrameCode : Byte
    {
        /// <summary>
        /// PPPoE Active Discovery Offer
        /// </summary>
        PADO = 0x07,

        /// <summary>
        /// PPPoE Active Discovery Initiation
        /// </summary>
        PADI = 0x09,

        /// <summary>
        /// PPPoE Active Discovery Request
        /// </summary>
        PADR = 0x19,

        /// <summary>
        /// PPPoE Active Discovery Session Confirmation
        /// </summary>
        PADS = 0x65,
    }
}
