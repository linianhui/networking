using System;

namespace Networking.Model.Application
{
    /// <summary>
    /// MQTT : Message Queuing Telemetry Transport
    /// <see href="http://mqtt.org/"/>
    /// </summary>
    public partial class MQTT : Octets
    {
        /// <summary>
        /// 服务端端口号=1883
        /// </summary>
        public const UInt16 ServerPort = 1883;

        /// <summary>
        /// 服务端端口号-TLS=8883
        /// </summary>
        public const UInt16 ServerTLSPort = 8883;
    }
}
