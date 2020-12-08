---
title: 鱼猫小栈
tagline: 躺着写Bug
layout: home
ArchivePageSize: 10
ArchiveSources: "{languages,devtools,softs,protocols}/**/*"
ArchiveOrderKey: create
ArchiveOrderDescending: true
ArchiveTitle: => GetString("Title")
ArchiveDestination: >
  => GetInt("Index") <= 1 ? $"index.html" : $"page/{GetInt("Index")}.html"
---

