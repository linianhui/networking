# netsh interface portproxy

```powershell
# port forward 127.0.0.1:12345 to http://www.nghttp2.org
netsh interface portproxy add v4tov4 listenport=12345 connectaddress=139.162.123.134 connectport=80

# show all
netsh interface portproxy show all

# delete all
netsh interface portproxy reset

# delete one
netsh interface portproxy delete v4tov4 listenport=12345

# help
netsh interface portproxy help
```