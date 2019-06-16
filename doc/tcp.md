# TCP 建立连接为什么需要三次握手?

答：3次握手是通信双方确认`自身`和`对方`都具备`发送`和`接受`能力的最小交互次数。

<table>
  <thead>
    <tr>
      <th rowspan="2">序号</th>
      <th rowspan="2">方向</th>
      <th colspan="4">Client确认</th>
      <th colspan="4">Server确认</th>
    </tr>
    <tr>
      <td>Client发送</td>
      <td>Client接收</td>
      <td>Server发送</td>
      <td>Server接收</td>
      <td>Server发送</td>
      <td>Server接收</td>
      <td>Client发送</td>
      <td>Client接收</td>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>1</td>
      <td>
        Client
        <span style="display: inline-block;text-align: center">
          syn=1,seq=<span style="color: #F00">j</span>
          <br />
          --------------------------------&gt;
        </span>
        Server
      </td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td>✔</td>
      <td>✔</td>
      <td></td>
    </tr>
    <tr>
      <td>2</td>
      <td>
        Client
        <span style="display: inline-block;text-align: center">
          syn=1,ack=1,ack=<span style="color: #F00">j</span>+1,seq=<span style="color: #00F">k</span>
          <br />
          &lt;--------------------------------
        </span>
        Server
      </td>
      <td>✔</td>
      <td>✔</td>
      <td>✔</td>
      <td>✔</td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
    </tr>
    <tr>
      <td>3</td>
      <td>
        Client
        <span style="display: inline-block;text-align: center">
          ack=1,ack=<span style="color: #00F">k</span>+1
          <br />
          --------------------------------&gt;
        </span>
        Server
      </td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td>✔</td>
      <td>✔</td>
      <td>✔</td>
      <td>✔</td>
    </tr>
  </tbody>
</table>

><span style="color: #F00">j</span>和<span style="color: #00F">k</span>为随机数。

# TCP State Diagram

![TCP State Diagram](img/tcp.state-diagram.svg)
