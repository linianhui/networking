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
| AppVeyor       | windows  | [![AppVeyor-Img]][AppVeyor-Url]             |
| GitHub Actions | docker   | [![GitHub-Actions-Img]][GitHub-Actions-Url] |
| GitLab CI      | docker   | [![GitLab-CI-Img]][GitLab-CI-Url]           |

# Docker Build

```sh
docker run \
       --rm \
       --volume $(pwd):/src \
       --workdir /src \
       --env GIT_COMMIT_SHA=$(git rev-parse --short HEAD) \
       mcr.microsoft.com/dotnet/core/sdk:3.1-alpine \
       ./cake.sh -target=pack
```



[PDU]:https://en.wikipedia.org/wiki/protocol_data_unit

[AppVeyor-Img]:https://ci.appveyor.com/api/projects/status/1yvioftypfn3vi48?svg=true
[AppVeyor-Url]:https://ci.appveyor.com/project/linianhui/networking

[GitHub-Actions-Img]:https://github.com/linianhui/networking/workflows/test/badge.svg
[GitHub-Actions-Url]:https://github.com/linianhui/networking/actions

[GitLab-CI-Img]:https://gitlab.com/lnh/networking/badges/master/pipeline.svg
[GitLab-CI-Url]:https://gitlab.com/lnh/networking/commits/master

[NuGet-Networking-Core-Img]:https://img.shields.io/nuget/v/Networking.Core.svg?label=nuget+Networking.Core
[NuGet-Networking-Core-URL]:https://www.nuget.org/packages/Networking.Core

[NuGet-Networking-Model-Img]:https://img.shields.io/nuget/v/Networking.Model.svg?label=nuget+Networking.Model
[NuGet-Networking-Model-URL]:https://www.nuget.org/packages/Networking.Model

[NuGet-Networking-Files-Img]:https://img.shields.io/nuget/v/Networking.Files.svg?label=nuget+Networking.Files
[NuGet-Networking-Files-URL]:https://www.nuget.org/packages/Networking.Files

[NuGet-Networking-Display-Img]:https://img.shields.io/nuget/v/Networking.Display.svg?label=nuget+Networking.Display
[NuGet-Networking-Display-URL]:https://www.nuget.org/packages/Networking.Display



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
