# Networking [PDU] 

| Layer         | Protocol                                  | [PDU]  |
| ------------- | ----------------------------------------- | ------ |
| [Application] | [DHCP], [DNS], [VXLAN], [MQTT], [CoAP]    | Data   |
| [Transport]   | [TCP]Segment, [UDP]Datagram               |        |
| [Internet]    | [IPv4], [ICMPv4], [IPv6], [ICMPv6]        | Packet |
| [DataLink]    | [Ethernet], [ARP], [PPP], [PPPoE], [VLAN] | Frame  |

# CI

| CI Service | Build Platform | Stauts                          |
| ---------- | -------------- | ------------------------------- |
| AppVeyor   | Windows        | [![AppVeyor-Img]][AppVeyor-Url] |
| Travis     | Linux          | [![Travis-Img]][Travis-Url]     |
| Circle     | Docker         | [![Circle-Img]][Circle-Url]     |




[PDU]:https://en.wikipedia.org/wiki/protocol_data_unit

[AppVeyor-Img]:https://ci.appveyor.com/api/projects/status/1yvioftypfn3vi48?svg=true
[AppVeyor-Url]:https://ci.appveyor.com/project/linianhui/networking

[Travis-Img]:https://travis-ci.org/linianhui/networking.svg?branch=master
[Travis-Url]:https://travis-ci.org/linianhui/networking

[Circle-Img]:https://circleci.com/gh/linianhui/networking.svg?style=svg
[Circle-Url]:https://circleci.com/gh/linianhui/networking




[Application]:/1-src/networking.model/Application/
[DHCP]:/1-src/networking.model/Application/DHCP.cs
[DNS]:/1-src/networking.model/Application/DNS.cs
[VXLAN]:/1-src/networking.model/Application/VXLAN.cs
[MQTT]:/1-src/networking.model/Application/MQTT.cs
[CoAP]:/1-src/networking.model/Application/CoAP.cs

[Transport]:/1-src/networking.model/Transport/
[TCP]:/1-src/networking.model/Transport/TCPSegment.cs
[UDP]:/1-src/networking.model/Transport/UDPDatagram.cs

[Internet]:/1-src/networking.model/Internet/
[IPv4]:/1-src/networking.model/Internet/IPv4Packet.cs
[ICMPv4]:/1-src/networking.model/Internet/ICMPv4Packet.cs
[IPv6]:/1-src/networking.model/Internet/IPv6Packet.cs
[ICMPv6]:/1-src/networking.model/Internet/ICMPv6Packet.cs

[DataLink]:/1-src/networking.model/DataLink/
[ARP]:/1-src/networking.model/DataLink/ARPFrame.cs
[Ethernet]:/1-src/networking.model/DataLink/EthernetFrame.cs
[PPP]:/1-src/networking.model/DataLink/PPPFrame.cs
[PPPoE]:/1-src/networking.model/DataLink/PPPoEFrame.cs
[VLAN]:/1-src/networking.model/DataLink/VLANFrame.cs