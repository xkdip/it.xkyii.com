---
title: Github 访问私有链接
layout: post
category: 开发工具
notebook: 开发工具
tag: 未完成
DestinationFileName: index.html
Excluded: true
---


<div style="display:none">
    var url = `https://raw.githubusercontent.com/xkdip/vkyii.github.io/master/CNAME`;

    // var xhr =new XMLHttpRequest();
    // xhr.open("Get", url, true);
    // xhr.setRequestHeader('Authorization', 'token 02e44bd17da15685788a82dd6787fe2c2fd497ef');
    // xhr.send();

    fetch('https://api.github.com/repos/xkdip/vkyii.github.io/contents/CNAME', {
      headers: {
        'Authorization': 'token 02e44bd17da15685788a82dd6787fe2c2fd497ef',
        'Accept': 'application/vnd.github.v3.raw',
      },
    })
      //.then(response => response.buffer())
      .then(response => {
        console.log(response.body.text());
      })
      .catch(() => {
        throw new Error('File unreachable');
      });

</div>

[1](https://docs.github.com/en/free-pro-team@latest/github/authenticating-to-github/creating-a-personal-access-token)

