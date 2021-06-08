using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.MQTTTests
{
    public class MQTT_Property_Type_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { 0b_0000_0000, MQTTType.Reserved },
            new Object[] { 0b_0001_0000, MQTTType.Connect },
            new Object[] { 0b_0010_0000, MQTTType.ConnectACK },
            new Object[] { 0b_0011_0000, MQTTType.Publish },
            new Object[] { 0b_0100_0000, MQTTType.PublishACK },
            new Object[] { 0b_0101_0000, MQTTType.PublishReceived },
            new Object[] { 0b_0110_0000, MQTTType.PublishRelease },
            new Object[] { 0b_0111_0000, MQTTType.PublishComplete },
            new Object[] { 0b_1000_0000, MQTTType.Subscribe },
            new Object[] { 0b_1001_0000, MQTTType.SubscribeACK },
            new Object[] { 0b_1010_0000, MQTTType.Unsubscribe },
            new Object[] { 0b_1011_0000, MQTTType.UnsubscribeACK },
            new Object[] { 0b_1100_0000, MQTTType.PingRequest },
            new Object[] { 0b_1101_0000, MQTTType.PingResponse },
            new Object[] { 0b_1110_0000, MQTTType.Disconnect },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte input, MQTTType expected)
        {
            var mqtt = new MQTT
            {
                Bytes = new Byte[32]
            };

            mqtt.SetByte(0, input);

            mqtt.Type.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte expected, MQTTType input)
        {
            var mqtt = new MQTT
            {
                Bytes = new Byte[32]
            };

            mqtt.Type = input;
            mqtt.GetByte(0).Should().Be(expected);
            mqtt.Type.Should().Be(input);
        }
    }
}
