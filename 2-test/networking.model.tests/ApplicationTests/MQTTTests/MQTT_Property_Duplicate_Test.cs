using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.MQTTTests
{
    public class MQTT_Property_Duplicate_Test
    {
        [Fact]
        public void Get()
        {
            var mqtt = new MQTT
            {
                Bytes = new Byte[2]
            };
            mqtt.SetByte(0, 0b_0000_1000);

            mqtt.Duplicate.Should().Be(true);
        }

        [Fact]
        public void Set()
        {
            var mqtt = new MQTT
            {
                Bytes = new Byte[2]
            };

            mqtt.Duplicate = true;
            mqtt.GetByte(0).Should().Be(0b_0000_1000);

            mqtt.Duplicate = false;
            mqtt.GetByte(0).Should().Be(0b_0000_0000);
        }
    }
}
