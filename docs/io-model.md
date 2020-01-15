- [0 IO 模型](#0-io-模型)
- [1 Blocking I/O](#1-blocking-io)
- [2 Non-Blocking I/O](#2-non-blocking-io)
- [3 I/O Multiplexing (select, poll, epoll)](#3-io-multiplexing-select-poll-epoll)
- [4 Signal Driven I/O (SIGIO)](#4-signal-driven-io-sigio)
- [5 Asynchronous I/O (POSIX aio, Windows iocp)](#5-asynchronous-io-posix-aio-windows-iocp)
- [Reference](#reference)

# 0 IO 模型

在I/O模型中，设想如此场景 : **`application`通过`kernel`的`read`函数读取数据，但是`kernel`还未准备好数据**。那么此时`read`函数有两种处理方式（大致的流程）：

<table>
  <tr>
    <td>1</td>
    <td colspan="3">
      等待数据准备好后再返回。此时：
      <br />
      对于<code>application</code>是<code>Blocking</code>的。
      <br />
      对于<code>kernel</code>的<code>read</code>函数是<code>Synchronous</code>的。
    </td>
  </tr>
  <tr>
    <td rowspan="5">2</td>
    <td colspan="3">
      立即返回，告知<code>application</code>数据还未准备好。此时：
      <br />
      对于<code>application</code>是<code>Non-Blocking</code>的；
      <br />
      对于<code>kernel</code>的<code>read</code>函数是<code>Asynchronous</code>的。
      <br />
      <br />
      由于<code>read</code>函数没有返回<code>application</code>期望读到的数据，那么就必须通过另外的方式把数据给到<code>application</code>。那么此时，也有2种处理方式：
    </td>
  </tr>
  <td>2.1</td>
  <td colspan="2">
    <code>application</code>一直不停的调用<code>read</code>函数，直到返回了期望读到的数据。此时<code>read</code>函数虽然没有<code>Blocking</code>到<code>application</code>，但是<code>application</code>也无法处理其他事情，只能不停的调用<code>read</code>。
  </td>
  </tr>
  </tr>
  <td rowspan="3">2.2</td>
  <td colspan="2">
    <code>read</code>函数要求<code>application</code>调用时提供一个<code>callback_function</code>，在数据准备好时通过<code>callback_function</code>告知<code>application</code>。此时<code>application</code>就可以继续做其他事情，直到<code>callback_function</code>被调用。
    <br />
    <br />
    在处理<code>callback_function</code>时，也还有2种处理方式。
  </td>
  </tr>
  </tr>
  <td>2.2.1</td>
  <td>
    数据准备好时调用<code>callback_function</code>，交由<code>application</code>去读取。
  </td>
  </tr>
  </tr>
  <td>2.2.2</td>
  <td>
    数据准备好并且写入到<code>application</code>提供的缓冲区，调用<code>callback_function</code>。
  </td>
  </tr>
</table>

![I/O Model](img/io-model.gif)

# 1 Blocking I/O

![Blocking I/O](img/io-model.blocking.gif)

对应上述表格中的1。这种方式模型简单，`Blocking`时`application`的进程/线程被挂起，基本不会占用`CPU`资源。但是当并发大时就需要创建N个进程/线程，造成内存、线程切换开销增大。

# 2 Non-Blocking I/O

![Non-Blocking I/O](img/io-model.non-blocking.gif)

对应上述表格中的2.1。这种方式明显看起来和`Blocking`没什么区别，不停的调用会造成CPU负担过重。

# 3 I/O Multiplexing (select, poll, epoll)

![I/O Multiplexing (select)](img/io-model.io-multiplexing-select.gif)

对应上述表格中的2.1。但是会同时通过(select, poll, epoll)在一个进程/线程中`Blocking`多个连接（故而称为`I/O多路复用`），当其中有一个连接的有数据可读时就返回。但是实质上还是`Blocking`的，只是不会`Blocking`到`read`环节，而是(select, poll, epoll)环节。因为不会为每个连接创建对应的进程/线程，故而性能较好。

# 4 Signal Driven I/O (SIGIO)
对应上述表格中的2.2.1。

# 5 Asynchronous I/O (POSIX aio, Windows iocp)

![Asynchronous Non-Blocking I/O (aio)](img/io-model.asynchronous-non-blocking-aio.gif)

对应上述表格中的2.2.2。当`application`接收到回调通知时，数据已经复制给`application`，故而性能最佳。

# Reference

The C10K Problem
> http://www.kegel.com/c10k.html  
> http://www.52im.net/thread-566-1-1.html

Select
> https://en.wikipedia.org/wiki/Select_(Unix)

Epoll
> https://en.wikipedia.org/wiki/Epoll

AIO(Asynchronous Input/Output)
> https://en.wikipedia.org/wiki/Asynchronous_I/O

IOCP(Input/Output Completion Port)
> https://en.wikipedia.org/wiki/Windows_NT_3.5  
> https://en.wikipedia.org/wiki/Input/output_completion_port  
> https://docs.microsoft.com/zh-cn/windows/win32/fileio/i-o-completion-ports

I/O Model Article
> http://www.52im.net/thread-1935-1-1.html  
> https://developer.ibm.com/articles/l-async/
