---
title: Markdown 注释
layout: post
catagory: 开发语言
tag: Markdown
created: 2020.12.02 16:35:11
updated: 2020.12.02 16:35:11
DestinationFileName: index.html
---

写~~代码~~(Bug)时，注释是很重要的，可以快乐地吐槽而不暴露，可以在代码之外给你的接任者更进一步的误导；

那么写**Markdown**怎么能少了这么重要的部分呢？

总结了几个方法，埋点操作起来。

## 方式一：Html隐藏
Markdown文档最终是渲染为html来展示的，所以可以以如下形式不可见：
```html
<div style="display:none">这是一段注释</div>
```

<div style="display:none">如果看到我，说明隐藏失败</div>

## 方式二：Xml注释
```xml
<!--
整段整段的不可见内容
-->
```
<!--
如果看到我，说明隐藏失败
-->

## 方式三：Markdown reference Links
Markdown的链接(link)基本形式有两种:

其一为**inline**：
```markdown
[Inline style](http://example.com/ "标题")
```
其二为**reference**：
```markdown
[Reference style][id1]

[id1]: http://example.com/ (标题)
[id2]: http://example.com/ "标题"
```

在**reference**形式中，链接(link)分成了展示部分和引用部分，其中引用(reference)部分是不直接显示出来的。

如果你经常使用**Typora**进行**Markdown**文档的写作的话，应该会发现**Typora**通常都是这样处理链接(link)的，引用(reference)的部分链接都放在文档的最后，可以一定程度上保持主体文档的简洁。

到此，注释的形式就很多了：
```markdown
[comment]: <> (一段注释)
[comment]: # (一段注释)
[//]: // (一段注释)
[//]: 一段注释

[^_^]: 开心注释

[>_<]:
  抓狂注释

[>_>]: #
  (
    斜眼分段注释
    斜眼分段注释
    被视为Title，所以要用括号或引号框起来
  )
```

[comment]: # (一段注释,如果看到我,说明隐藏失败)
[//]: // (一段注释,如果看到我,说明隐藏失败)
[//]: 一段注释,如果看到我,说明隐藏失败

[^_^]: 开心注释,如果看到我,说明隐藏失败

[>_<]:
  抓狂注释,如果看到我,说明隐藏失败

[>_>]: #
  (
    斜眼分段注释
    斜眼分段注释
    如果看到我，说明隐藏失败
  )

## 参考
* [如何在 Markdown 注释一段文字](https://www.jianshu.com/p/9be87e7e15bf)
* [Comments in Markdown](https://daringfireball.net/projects/markdown/syntax#link)
* [Markdown: Syntax#links](https://stackoverflow.com/questions/4823468/comments-in-markdown)

本文完
