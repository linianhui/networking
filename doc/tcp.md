# TCP 建立连接为什么需要 *`3步`* 握手?

答： *`3步`* 握手是通信双方确认`自身`和`对方`都具备`发送`和`接受`能力的最小交互次数。

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
        Client -&gt; Server
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
        Client &lt;- Server
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
        Client -&gt; Server
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


# TCP State Diagram

![TCP State Diagram](img/tcp.state-diagram.svg)
