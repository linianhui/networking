# 安装

```sh
apt install -y iproute2
```

# Options

| short option | full option |
| ------------ | ----------- |
| -h           | --help      |
| -V           | --version   |
| -a           | --all       |
| -n           | --numeric   |
| -t           | --tcp       |
| -u           | --udp       |
| -x           | --unix      |
| -4           | --ipv4      |
| -6           | --ipv6      |
| -H           | --no-header |

# 统计
```sh
ss -tan | awk 'NR>1 {++S[$1]} END {for (a in S) print a,S[a]}'
```
