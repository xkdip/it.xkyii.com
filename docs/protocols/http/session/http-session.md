---
title: Http - Session篇
layout: post
category: 协议
tag: [Http, 未完成]
DestinationFileName: index.html
Excluded: true
---

**HTTP**是无状态协议，它本身不能以状态来区分和管理请求和响应。当服务端需要记录用户的状态时，就需要某种机制来记录和识别。

**会话(Session)** 跟踪就是Web程序中常用的技术，用来跟踪用户的整个会话。常用的会话跟踪技术是**Cookie**与**Session**，本篇介绍**Session**。

## Session
**Session**技术是服务端的解决方案。
