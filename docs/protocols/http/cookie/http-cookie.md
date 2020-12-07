---
title: Http - Cookie篇
layout: post
category: 协议
tag: Http
DestinationFileName: index.html
---

**HTTP**是无状态协议，它本身不能以状态来区分和管理请求和响应。当服务端需要记录用户的状态时，就需要某种机制来记录和识别。

**会话(Session)** 跟踪就是Web程序中常用的技术，用来跟踪用户的整个会话。常用的会话跟踪技术是**Cookie**与**Session**，本篇介绍**Cookie**。

## Cookie
**Cookie**技术是客户端的解决方案。

**Cookie**通常以文本的方式记录服务端发来的特殊信息，并在之后的请求中带上Cookie以便让服务端确认，大致流程如下：

```
┌─────────────┐  1. Request              ┌───────────────┐
│             │ ───────────────────────> │               │
│             │  2. Response Set-Cookie  │               │
│             │ <─────────────────────── │               │
│  Web Client │                          │  Web Server   │
│             │  3. Request + Cookie     │               │
│             │ ───────────────────────> │               │
│             │  4. Response             │               │
│             │ <─────────────────────── │               │
└─────────────┘                          └───────────────┘
```

### Set-Cookie
当服务端准备开始管理客户端状态时，会通过**Set-Cookie**来通知客户端建立**Cookie**，并要求在后续的请求中将此**Cookie**发送回服务端，直到**Cookie**过期。

Set-Cookie有几个主要的属性：

| 属性                            | 说明                                                |
| ------------------------------  | ----------------------------------------------      |
| Name=Value                      | Cookie信息键值对 - 必需项                           |
| Expires=\<date>                 | Cookie过期时间戳                                    |
| Max-Age=\<number>               | Cookie有效时间(秒)                                  |
| Domain=\<domain-value>          | Cookie限制发送范围的文件目录                        |
| Path=\<path-value>              | Cookie适用对象的域名                                |
| Secure                          | Cookie是否只适用与Https                             |
| HttpOnly                        | Cookie无法使用JavaScript获得，防止跨站脚本攻击(XSS) |


### 服务端操作Cookie(Java)

添加Cookie
```java
Cookie cookie = new Cookie("username","lili");  // 新建Cookie
cookie.setDomain(".example.com");               // 设置域名
cookie.setPath("/");                            // 设置路径
cookie.setMaxAge(Integer.MAX_VALUE);            // 设置有效期
response.addCookie(cookie);                     // 输出到客户端
```

获取Cookie
```java
Cookie[] cookies = request.getCookies();
for(Cookie cookie : cookies){
    // cookie.getName();
    // cookie.getValue();
}
```

### 客户端操作Cookie(JavaScript)

获得Cookie的值
```javascript
function getCookie(cname) {
  var name = cname + "=";
  var decodedCookie = decodeURIComponent(document.cookie);
  var ca = decodedCookie.split(';');
  for(var i = 0; i <ca.length; i++) {
      var c = ca[i];
      while (c.charAt(0) == ' ') {
          c = c.substring(1);
      }
      if (c.indexOf(name) == 0) {
          return c.substring(name.length, c.length);
      }
  }
  return "";
}
```

设置Cookie值
```javascript
function setCookie(cname, cvalue, exdays) {
  var d = new Date();
  d.setTime(d.getTime() + (exdays*24*60*60*1000));
  var expires = "expires="+ d.toUTCString();
  document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}
```

删除Cookie
```javascript
function delCookie(name) {
  var cval=getCookie(name);
  if(cval!=null) {
    setCookie(name, cval, -1);
  }
}
```

## 参考
* [Using HTTP cookies](https://developer.mozilla.org/en-US/docs/Web/HTTP/Cookies)
* [Set-Cookie](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Set-Cookie)
* [认识HTTP----Cookie和Session篇](https://zhuanlan.zhihu.com/p/27669892)

本文完
