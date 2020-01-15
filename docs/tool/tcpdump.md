# 安装

```sh
apt install -y tcpdump
```

# Options

| option                             | description                                                                              |
| ---------------------------------- | ---------------------------------------------------------------------------------------- |
| -h, --help                         | show help                                                                                |
| --version                          | show version                                                                             |
| -A                                 | Print each packet (minus its link level header) in ASCII. Handy for capturing web pages. |
| -c                                 | Exit after receiving count packets.                                                      |
| -s,--snapshot-length               | Snarf snaplen bytes of data from each packet                                             |
| -S,--absolute-tcp-sequence-numbers | Print absolute, rather than relative, TCP sequence numbers.                              |

# 抓包
```sh
# 抓包到文件
tcpdump port 80 -w http-80.pcap

# 解析80端口的包
tcpdump port 80 -A 
```

# 参考

https://www.tcpdump.org/manpages/tcpdump.1.html
