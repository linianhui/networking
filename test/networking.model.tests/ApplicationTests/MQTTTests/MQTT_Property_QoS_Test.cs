using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.MQTTTests
{
    public class MQTT_Property_QoS_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { 0b_0000_0000, 0 },
            new Object[] { 0b_0000_0010, 1 },
            new Object[] { 0b_0000_0100, 2 }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte input, Byte expected)
        {
            var mqtt = new MQTT
            {
                Bytes = new Byte[32]
            };

            mqtt.SetByte(0, input);

            mqtt.Qos.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte expected, Byte input)
        {
            var mqtt = new MQTT
            {
                Bytes = new Byte[32]
            };

            mqtt.Qos = input;
            mqtt.GetByte(0).Should().Be(expected);
            mqtt.Qos.Should().Be(input);
        }
    }
}
