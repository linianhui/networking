# TCP 建立连接为什么需要 *`3步`* 握手?

答：TCP是一个全双工协议，通信双方需要确认`自身`和`对方`都具备`发送`和`接收`数据的能力。而 *`3步`* 握手是确认上述能力的最小交互步数。如下图，`A`和`B`是通信双方：

<table>
  <thead>
    <tr>
      <th rowspan="2">序号</th>
      <th rowspan="2">方向</th>
      <th colspan="4">A确认</th>
      <th colspan="4">B确认</th>
    </tr>
    <tr>
      <td>A发送</td>
      <td>A接收</td>
      <td>B发送</td>
      <td>B接收</td>
      <td>B发送</td>
      <td>B接收</td>
      <td>A发送</td>
      <td>A接收</td>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>1</td>
      <td>
        A -&gt; B
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
        A &lt;- B
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
        A -&gt; B
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

# TCP 关闭连接为什么需要 *`4步`* 挥手?

答：TCP是一个全双工协议，通信双方需要进行独立的关闭（半关闭：half-clone）。A方发送`FIN`只是代表A不再发送数据了，但是还可以接收B方发送的数据。当B收到A的`FIN`时：B需要给A发送一个ACK；但是TCP并不知道B方是否也需要关闭，而是要由上层应用来决定；故而不能像建立连接时那样合并ACK和自身的`FIN`。

# TCP State Diagram

![TCP State Diagram](img/tcp.state-diagram.svg)
