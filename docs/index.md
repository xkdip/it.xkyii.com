---
title: 告辞
tagline: 不是我我没有别瞎说啊
layout: home
ArchivePageSize: 10
ArchiveSources: "{languages,devtools,softs,protocols}/**/*"
ArchiveOrderKey: create
ArchiveOrderDescending: true
ArchiveTitle: => GetString("Title")
ArchiveDestination: >
  => GetInt("Index") <= 1 ? $"index.html" : $"page/{GetInt("Index")}.html"
---

