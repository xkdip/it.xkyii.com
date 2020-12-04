---
title: Http重定向与转发
layout: post
category: 协议
tag: Http
DestinationFileName: index.html
---

## 重定向(Redirect)
[重定向(Redirect)][1]就是通过各种方法将各种网络请求重新定个方向转到其它位置（如：网页重定向、域名的重定向、路由选择的变化也是对数据报文经由路径的一种重定向）。

当浏览器请求一个URL，服务器返回一个重定向指令，告诉浏览器地址变了，请使用新的URL重新发送请求。

总体上，重定向是客户端行为：
```
┌───────┐       GET /url-A    ┌───────────────┐
│Browser│ ──────────────────> │  Web Server   │
│       │ <────────────────── │  /url-A       │
└───────┘       302/301       └───────────────┘
    │
    ▼
┌───────┐       GET /url-B    ┌───────────────┐
│Browser│ ──────────────────> │  Web Server   │
│       │ <────────────────── │  /url-B       │
└───────┘       200           └───────────────┘
```

Java示例：
```java
@RestController
@RequestMapping("/redirect")
public class RedirectController {

    @GetMapping("/url-A")
    public String getUrlA(HttpServletResponse response) throws IOException {
        response.sendRedirect("/redirect/url-B");
        return "Redirect-A";
    }

    @GetMapping("/url-B")
    public String getUrlB() {
        return "Redirect-B";
    }
}
```


## 转发(Forward)
**转发**则是内部控制权的转移，客户端并不知道是如何转移的，是服务端的行为：

```
                          ┌────────────────────────┐
                          │      ┌───────────────┐ │
                          │ ────>│ /url-A        │ │
┌───────┐  GET /url-A     │      └───────────────┘ │
│Browser│ ──────────────> │              │         │
│       │ <────────────── │              ▼         │
└───────┘    200 <html>   │      ┌───────────────┐ │
                          │ <────│ /url-B        │ │
                          │      └───────────────┘ │
                          │       Web Server       │
                          └────────────────────────┘
```

Java示例：
```java

@RestController
@RequestMapping("/forward")
public class ForwardController {

    @GetMapping("/url-A")
    public String getUrlA(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        request.getRequestDispatcher("/forward/url-B").forward(request, response);
        return "Forward-A";
    }

    @GetMapping("/url-B")
    public String getUrlB() {
        return "Forward-B";
    }
}

```

## 区别

| 转发                            | 重定向                                         |
| ------------------------------  | ---------------------------------------------- |
| 服务端执行                      | 客户端执行                                     |
| 请求转移给服务端内部的其他资源  | 请求转移给其他服务器的资源(可以不是同一个服务) |
| 请求与转移的目标资源间共享      | 新建一个请求                                   |
| 一次请求                        | 至少两次请求                                   |
| 浏览器地址不会改变              | 浏览器地址会改变                               |
| 速度通常比重定向快              | 速度通常比转发慢                               |


## 参考
* [重定向][1]
* [重定向与转发](https://www.liaoxuefeng.com/wiki/1252599548343744/1328761739935778)
* [转发与重定向](https://blog.csdn.net/xianyadong/article/details/81230808)

---
本文完

[1]: https://baike.baidu.com/item/%E9%87%8D%E5%AE%9A%E5%90%91
