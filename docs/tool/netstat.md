# 安装

```sh
apt install -y net-tools
```
# Options

| short option | full option                                                                 |
| ------------ | --------------------------------------------------------------------------- |
| -h           | --help                                                                      |
| -V           | --version                                                                   |
| -n           | --numeric <br/> --numeric-hosts <br/> --numeric-ports <br/> --numeric-users |
| -t           | --tcp                                                                       |
| -u           | --udp                                                                       |
| -x           | --unix                                                                      |

# TCP

状态统计
```sh
netstat -n | awk '/^tcp/ {++S[$NF]} END {for(a in S) print a, S[a]}'
```

TIME_WAIT状态统计
```sh
netstat -n | awk '/TIME_WAIT/ {++S[$4]} END {for(a in S) print a, S[a]}' | sort -r -n -k2 -t' '
```
