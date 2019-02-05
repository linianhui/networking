# CI
| CI Service | Build Platform | Stauts                          |
| ---------- | -------------- | ------------------------------- |
| AppVeyor   | Windows        | [![AppVeyor-Img]][AppVeyor-Url] |
| Travis     | Linux          | [![Travis-Img]][Travis-Url]     |
| Circle     | Docker         | [![Circle-Img]][Circle-Url]     |

# networking PDU analysis 

PDU : https://en.wikipedia.org/wiki/protocol_data_unit

| Layer       | Protocol   | PDU     |
| ----------- | ---------- | ------- |
| [Transport] | [TCP]      | Segment |
|             | [UDP]      |         |
| [Internet]  | [IPv4]     | Packet  |
|             | [ICMPv4]   |         |
|             | [IPv6]     |         |
|             | [ICMPv6]   |         |
| [DataLink]  | [Ethernet] | Frame   |
|             | [ARP]      |         |
|             | [PPP]      |         |
|             | [PPPoE]    |         |




[AppVeyor-Img]:https://ci.appveyor.com/api/projects/status/1yvioftypfn3vi48?svg=true
[AppVeyor-Url]:https://ci.appveyor.com/project/linianhui/networking

[Travis-Img]:https://travis-ci.org/linianhui/networking.svg?branch=master
[Travis-Url]:https://travis-ci.org/linianhui/networking

[Circle-Img]:https://circleci.com/gh/linianhui/networking.svg?style=svg
[Circle-Url]:https://circleci.com/gh/linianhui/networking



[Transport]:1-src/networking.model/transport/
[TCP]:1-src/networking.model/transport/tcpsegment.cs
[UDP]:1-src/networking.model/transport/udpsegment.cs

[Internet]:1-src/networking.model/internet/
[IPv4]:1-src/networking.model/internet/ipv4packet.cs
[ICMPv4]:1-src/networking.model/internet/icmpv4packet.cs
[IPv6]:1-src/networking.model/internet/ipv6packet.cs
[ICMPv6]:1-src/networking.model/internet/icmpv6packet.cs

[DataLink]:1-src/networking.model/datalink/
[ARP]:1-src/networking.model/datalink/arpframe.cs
[Ethernet]:1-src/networking.model/datalink/ethernetframe.cs
[PPP]:1-src/networking.model/datalink/pppframe.cs
[PPPoE]:1-src/networking.model/datalink/pppoeframe.cs