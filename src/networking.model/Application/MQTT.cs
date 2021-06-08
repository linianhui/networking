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

        /// <summary>
        ///  MQTT Control Packet type
        /// </summary>
        public MQTTType Type
        {
            get { return (MQTTType)base.GetByte(Layout.TypeBegin, Layout.TypeBitIndex, Layout.TypeBitLength); }
            set { base.SetByte(Layout.TypeBegin, Layout.TypeBitIndex, Layout.TypeBitLength, (Byte)value); }
        }

        /// <summary>
        /// Duplicate delivery of a PUBLISH Control Packet
        /// </summary>
        public Boolean Duplicate
        {
            get { return base.GetBoolean(Layout.FlagsBegin, Layout.FlagsDuplicateBitIndex); }
            set { base.SetBoolean(Layout.FlagsBegin, Layout.FlagsDuplicateBitIndex, value); }
        }

        /// <summary>
        /// Publish Quality of Service
        /// </summary>
        public Byte Qos
        {
            get { return base.GetByte(Layout.FlagsBegin, Layout.FlagsQoSBitIndex, Layout.FlagsQoSLength); }
            set { base.SetByte(Layout.FlagsBegin, Layout.FlagsQoSBitIndex, Layout.FlagsQoSLength, value); }
        }

        /// <summary>
        /// Publish Retain 
        /// </summary>
        public Boolean Retain
        {
            get { return base.GetBoolean(Layout.FlagsBegin, Layout.FlagsRetainBitIndex); }
            set { base.SetBoolean(Layout.FlagsBegin, Layout.FlagsRetainBitIndex, value); }
        }

        /// <summary>
        /// Identifier 
        /// </summary>
        public UInt16 Id
        {
            get
            {
                if (IdIndex == -1)
                {
                    return 0;
                }
                return base.GetUInt16(IdIndex);
            }
            set
            {
                if (IdIndex != -1)
                {
                    base.SetUInt16(IdIndex, value);
                }
            }
        }

        private Int32 IdIndex
        {
            get
            {
                if (Type == MQTTType.PublishACK
                    || Type == MQTTType.PublishReceived
                    || Type == MQTTType.PublishRelease
                    || Type == MQTTType.PublishComplete
                    || Type == MQTTType.UnsubscribeACK)
                {
                    return 2;
                }

                return -1;
            }
        }
    }
}
