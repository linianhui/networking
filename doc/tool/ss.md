# 安装

```sh
apt install -y iproute2
```

# 统计
```sh
ss -tan | awk 'NR>1 {++S[$1]} END {for (a in S) print a,S[a]}'
```