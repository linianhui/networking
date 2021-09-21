# Docs

<https://linianhui.github.io/computer-networking>

# Networking [PDU] 

| Layer         | Protocol                                  | [PDU]  |
| ------------- | ----------------------------------------- | ------ |
| [Application] | [DHCP], [DNS], [VXLAN], [MQTT], [CoAP]    | Data   |
| [Transport]   | [TCP]Segment, [UDP]Datagram               |        |
| [Internet]    | [IPv4], [ICMPv4], [IPv6], [ICMPv6]        | Packet |
| [DataLink]    | [Ethernet], [ARP], [PPP], [PPPoE], [VLAN] | Frame  |

# Nuget

1. [![NuGet-Networking-Core-Img]][NuGet-Networking-Core-Url]
2. [![NuGet-Networking-Model-Img]][NuGet-Networking-Model-Url]
3. [![NuGet-Networking-Files-Img]][NuGet-Networking-Files-Url]
3. [![NuGet-Networking-Display-Img]][NuGet-Networking-Display-Url]

# CI

| CI Service     | Platform | Test Status                                 |
| -------------- | -------- | ------------------------------------------- |
| GitHub Actions | docker   | [![GitHub-Actions-Img]][GitHub-Actions-Url] |
| GitLab CI      | docker   | [![GitLab-CI-Img]][GitLab-CI-Url]           |

# Docker Build

```sh
docker run \
       --rm \
       --volume $(pwd):/src \
       --workdir /src \
       --env GIT_COMMIT_SHA=$(git rev-parse --short HEAD) \
       mcr.microsoft.com/dotnet/sdk:5.0 \
       ./cake.sh -target=pack
```



[PDU]:https://en.wikipedia.org/wiki/protocol_data_unit

[GitHub-Actions-Img]:https://github.com/linianhui/networking/workflows/test/badge.svg
[GitHub-Actions-Url]:https://github.com/linianhui/networking/actions

[GitLab-CI-Img]:https://gitlab.com/lnh/networking/badges/main/pipeline.svg
[GitLab-CI-Url]:https://gitlab.com/lnh/networking/commits/main

[NuGet-Networking-Core-Img]:https://img.shields.io/nuget/v/Networking.Core.svg?label=nuget+Networking.Core
[NuGet-Networking-Core-URL]:https://www.nuget.org/packages/Networking.Core

[NuGet-Networking-Model-Img]:https://img.shields.io/nuget/v/Networking.Model.svg?label=nuget+Networking.Model
[NuGet-Networking-Model-URL]:https://www.nuget.org/packages/Networking.Model

[NuGet-Networking-Files-Img]:https://img.shields.io/nuget/v/Networking.Files.svg?label=nuget+Networking.Files
[NuGet-Networking-Files-URL]:https://www.nuget.org/packages/Networking.Files

[NuGet-Networking-Display-Img]:https://img.shields.io/nuget/v/Networking.Display.svg?label=nuget+Networking.Display
[NuGet-Networking-Display-URL]:https://www.nuget.org/packages/Networking.Display



[Application]:/src/networking.model/Application/
[DHCP]:/src/networking.model/Application/DHCP.cs
[DNS]:/src/networking.model/Application/DNS.cs
[VXLAN]:/src/networking.model/Application/VXLAN.cs
[MQTT]:/src/networking.model/Application/MQTT.cs
[CoAP]:/src/networking.model/Application/CoAP.cs

[Transport]:/src/networking.model/Transport/
[TCP]:/src/networking.model/Transport/TCPSegment.cs
[UDP]:/src/networking.model/Transport/UDPDatagram.cs

[Internet]:/src/networking.model/Internet/
[IPv4]:/src/networking.model/Internet/IPv4Packet.cs
[ICMPv4]:/src/networking.model/Internet/ICMPv4Packet.cs
[IPv6]:/src/networking.model/Internet/IPv6Packet.cs
[ICMPv6]:/src/networking.model/Internet/ICMPv6Packet.cs

[DataLink]:/src/networking.model/DataLink/
[ARP]:/src/networking.model/DataLink/ARPFrame.cs
[Ethernet]:/src/networking.model/DataLink/EthernetFrame.cs
[PPP]:/src/networking.model/DataLink/PPPFrame.cs
[PPPoE]:/src/networking.model/DataLink/PPPoEFrame.cs
[VLAN]:/src/networking.model/DataLink/VLANFrame.cs
