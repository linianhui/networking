using System;

namespace Networking.Model.Application
{
    /// <summary>
    /// <see cref="MQTT"/>的类型
    /// </summary>
    public enum MQTTType : Byte
    {
        /// <summary>
        /// Forbidden : Reserved
        /// </summary>
        Reserved = 0,

        /// <summary>
        /// Client to Server : Client request to connect to Server
        /// </summary>
        Connect = 1,

        /// <summary>
        /// Server to Client : Connect acknowledgment
        /// </summary>
        ConnectACK = 2,

        /// <summary>
        /// Both : Publish message
        /// </summary>
        Publish = 3,

        /// <summary>
        /// Both : Publish acknowledgment
        /// </summary>
        PublishACK = 4,

        /// <summary>
        /// Both : Publish received
        /// </summary>
        PublishReceived = 5,

        /// <summary>
        /// Both : Publish release
        /// </summary>
        PublishRelease = 6,

        /// <summary>
        /// Both : Publish complete
        /// </summary>
        PublishComplete = 7,

        /// <summary>
        /// Client to Server : Client subscribe request
        /// </summary>
        Subscribe = 8,

        /// <summary>
        /// Server to Client : Subscribe acknowledgment
        /// </summary>
        SubscribeACK = 9,

        /// <summary>
        /// Client to Server : Client unsubscribe request
        /// </summary>
        Unsubscribe = 10,

        /// <summary>
        /// Server to Client : Unsubscribe acknowledgment
        /// </summary>
        UnsubscribeACK = 11,

        /// <summary>
        /// Client to Server : Client ping request
        /// </summary>
        PingRequest = 12,

        /// <summary>
        /// Server to Client : Server ping response
        /// </summary>
        PingResponse = 13,

        /// <summary>
        /// Client to Server : Client is disconnecting
        /// </summary>
        Disconnect = 14,
    }
}
