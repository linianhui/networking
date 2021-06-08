using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.MQTTTests
{
    public class MQTT_Property_Id_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { 0, MQTTType.Reserved },
            new Object[] { 0, MQTTType.Connect },
            new Object[] { 0, MQTTType.ConnectACK },
            new Object[] { 0, MQTTType.Publish },
            new Object[] { 0x1234, MQTTType.PublishACK },
            new Object[] { 0x1234, MQTTType.PublishReceived },
            new Object[] { 0x1234, MQTTType.PublishRelease },
            new Object[] { 0x1234, MQTTType.PublishComplete },
            new Object[] { 0, MQTTType.Subscribe },
            new Object[] { 0, MQTTType.SubscribeACK },
            new Object[] { 0, MQTTType.Unsubscribe },
            new Object[] { 0x1234, MQTTType.UnsubscribeACK },
            new Object[] { 0, MQTTType.PingRequest },
            new Object[] { 0, MQTTType.PingResponse },
            new Object[] { 0, MQTTType.Disconnect },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(UInt16 expected, MQTTType input)
        {
            var mqtt = new MQTT
            {
                Bytes = new Byte[32]
            };
            mqtt.Type = input;
            mqtt.SetByte(2, 0x12);
            mqtt.SetByte(3, 0x34);

            mqtt.Id.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(UInt16 expected, MQTTType input)
        {
            var mqtt = new MQTT
            {
                Bytes = new Byte[32]
            };
            mqtt.Type = input;
            mqtt.Id = expected;

            mqtt.Id.Should().Be(expected);
        }
    }
}
