using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.MQTTTests
{
    public class MQTT_Property_Retain_Test
    {
        [Fact]
        public void Get()
        {
            var mqtt = new MQTT
            {
                Bytes = new Byte[2]
            };
            mqtt.SetByte(0, 0b_0000_0001);

            mqtt.Retain.Should().Be(true);
        }

        [Fact]
        public void Set()
        {
            var mqtt = new MQTT
            {
                Bytes = new Byte[2]
            };

            mqtt.Retain = true;
            mqtt.GetByte(0).Should().Be(0b_0000_0001);

            mqtt.Retain = false;
            mqtt.GetByte(0).Should().Be(0b_0000_0000);
        }
    }
}
