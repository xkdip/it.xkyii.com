---
title: Http - Session篇
layout: post
category: 协议
tag: Http
DestinationFileName: index.html
---

**HTTP**是无状态协议，它本身不能以状态来区分和管理请求和响应。当服务端需要记录用户的状态时，就需要某种机制来记录和识别。

**会话(Session)** 跟踪就是Web程序中常用的技术，用来跟踪用户的整个会话。常用的会话跟踪技术是**Cookie**与**Session**，本篇介绍**Session**。

## Session
**Session**技术是服务端的解决方案。使用一种类似散列表的结构来保存信息；


## Session Id
当程序需要为某个客户端的请求创建一个**Session**的时候，首先检查客户端的请求里是否已包含了**Session**的标识，一般称为**Session Id**，有则按此**Session Id**来检索**Session**信息，否则新建一个。

客户端通常有如下几种方式来记录**Session Id**
1. 借助**Cookie**来记录；
2. 使用**URL重写**；即把**Session Id**直接附加在Url后面，如： *http://your.url?jsessionid=session_id_value*
3. 表单隐藏域；即在页面上添加一个隐藏字段，在表单提交时发送给服务端。

## Session时效
由于使用不同的客户端技术保存**Session Id**，他们的失效时间也不一样，通常在*页面关闭*或*浏览器关闭*，或者*Cookie失效*时，**Session Id**丢失，导致无法检索到旧的**Session**，从而造成对**Session**时效的误解。

而其实，最终**Session**的时效取决于服务端的实现。

## 操作Session
以`Java Servlet`为例：

创建**Session**
```java
  @PostMapping("/sessionInfo")
  public void postSessionInfo(HttpServletRequest request, String userName) {
      HttpSession session = request.getSession();
      // 设置：userName
      session.setAttribute("userName", userName);
      // 设置：过期时间(秒)
      session.setMaxInactiveInterval(30*60);
  }
```

获取**Session**信息
```java
  @GetMapping("/sessionInfo")
  public void getSessionInfo(HttpServletRequest request) {
      HttpSession session = request.getSession();
      // 获取：userName
      String userName = (String) session.getAttribute("userName");
      // 获取：session的创建时间
      long creationTime = session.getCreationTime();
      // 获取：上次与服务器交互时间
      long lastAccessedTime = session.getLastAccessedTime();
      // 获取: sessionId
      String id = session.getId();
      // 获取:session过期时间
      int timeout = session.getMaxInactiveInterval();

      // 销毁session
      session.invalidate();
  }
```

本文完
