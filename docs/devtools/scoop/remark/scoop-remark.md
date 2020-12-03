---
title: Scoop - Windows下的包管理工具
layout: post
category: 开发工具
DestinationFileName: index.html
---

## 安装Scoop
确保已经安装了：
* [PowerShell 5](https://aka.ms/wmf5download)(或更高版本，包括[PowerShell Core](https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell-core-on-windows?view=powershell-6))
* [.Net Framework 4.5](https://www.microsoft.com/net/download)(或更高版本)

Windows10基本上都满足。

以下命令都在**Powershell**中执行！

Scoop默认安装到**C:\Scoop**目录，如果你像我一样需要换一个安装目录，先做一点点额外的工作(注意替换为你安装Scoop的目录)：
```powershell
$env:SCOOP='D:\Scoop'
[environment]::setEnvironmentVariable('SCOOP',$env:SCOOP,'User')
```

然后运行如下内容，进行Scoop的安装
```powershell
Set-ExecutionPolicy RemoteSigned -scope CurrentUser
iwr -useb get.scoop.sh | iex
```

输入`scoop`出现帮助信息即安装成功:
```powershell
Usage: scoop <command> [<args>]

Some useful commands are:

alias       Manage scoop aliases
bucket      Manage Scoop buckets
cache       Show or clear the download cache
checkup     Check for potential problems
cleanup     Cleanup apps by removing old versions
config      Get or set configuration values
create      Create a custom app manifest
depends     List dependencies for an app
export      Exports (an importable) list of installed apps
help        Show help for a command
hold        Hold an app to disable updates
home        Opens the app homepage
info        Display information about an app
install     Install apps
list        List installed apps
prefix      Returns the path to the specified app
reset       Reset an app to resolve conflicts
search      Search available apps
status      Show status and check for new app versions
unhold      Unhold an app to enable updates
uninstall   Uninstall an app
update      Update apps, or Scoop itself
virustotal  Look for app's hash on virustotal.com
which       Locate a shim/executable (similar to 'which' on Linux)


Type 'scoop help <command>' to get help for a specific command.
```

## 查找软件
我们找个[aria2](https://aria2.github.io/)来试试，Scoop甚至默认使用[aria2](https://aria2.github.io/)来进行多连接下载
```powershell
scoop search aria2
```
在**main**仓库中找到：
```powershell
'main' bucket:
    aria2 (1.35.0-1)
```

## 安装软件
找到以后，开始安装:
```powershell
scoop install aria2
```
安装成功：
```powershell
Installing 'aria2' (1.35.0-1) [64bit]
Loading aria2-1.35.0-win-64bit-build1.zip from cache
Checking hash of aria2-1.35.0-win-64bit-build1.zip ... ok.
Extracting aria2-1.35.0-win-64bit-build1.zip ... done.
Linking D:\Scoop\apps\aria2\current => D:\Scoop\apps\aria2\1.35.0-1
Creating shim for 'aria2c'.
'aria2' (1.35.0-1) was installed successfully!
```

## 更新软件
使用**status**来查看软件状态
```powershell
# 查看一个软件的状态
scoop status aria2

# 查看已经安装的全部软件的(更新)状态
scoop status
```
结果：
```powershell
Scoop is up to date.
Updates are available for:
    bandizip: 7.09 -> 7.13
    curl: 7.71.1 -> 7.73.0_5
    everything: 1.4.1.986 -> 1.4.1.1000
    fastcopy: 3.86 -> 3.92
    ffmpeg: 4.2.2 -> 4.3.1-26
    fork: 1.55.5 -> 1.56.1
    git: 2.29.2.windows.1 -> 2.29.2.windows.2
    IntelliJ-IDEA-Ultimate: 2020.2.3-202.7660.26 -> 2020.3-203.5981.155
    microsoftedge: 86.0.622.68 -> 87.0.664.52
    nodejs: 14.2.0 -> 15.3.0
    ojdkbuild8: 1.8.0.252-2.b09 -> 1.8.0.275-1.b01
    postman: 7.21.2 -> 7.36.0
    shadowsocks: 4.1.9.2 -> 4.3.0.0
    tomcat: 9.0.33 -> 9.0.40
    typora: 0.9.89 -> 0.9.96
    youtube-dl: 2020.11.24 -> 2020.12.02
```

结果里显示的是可以进行升级的软件（再也不用烦恼每个软件都来催你更新了）。

可以对指定的软件进行更新：
```powershell
scoop update curl
```

也可以全部更新:
```powershell
scoop update *
```

## 卸载软件
使用**uninstall**来卸载
```powershell
scoop uninstall aria2
```

## Bucket(仓库)
官方的**main**仓库主要包含无界面的软件（键盘党喜笑颜开），好消息是社区维护了一批仓库，你可以这样查看有哪些：
```powershell
scoop bucket known
```
目前有这些
```powershell
main
extras
versions
nightlies
nirsoft
php
nerd-fonts
nonportable
java
games
jetbrains
```

比如，把**extra**装上，毕竟是**known**，所以无需指定**git仓库**
```powershell
scoop bucket add extra
```

如果需要添加第三方的仓库，则需要指定仓库地址了：
```powershell
scoop bucket add <仓库名> <仓库地址>
```

## 处理失败
前面的介绍听起来很不错对吧，实际上由于上网的科学性，加上Scoop里面相当多的App都发布在[github](https://github.com/)上，你可能经常性地遭遇到一个几兆几十兆的软件大半个小时下载不了，还经常下载失败，像这样：
```powershell
Installing 'potplayer' (201021) [64bit]
Starting download with aria2 ...
Download: Download Results:
Download: gid   |stat|avg speed  |path/URI
Download: ======+====+===========+=======================================================
Download: d91ea6|ERR |       0B/s|D:/Scoop/cache/potplayer#201021#https_t1.daumcdn.net_potplayer_PotPlayer_Version_201021_PotPlayerSetup64.exe_dl.7z
Download: Status Legend:
Download: (ERR):error occurred.
Download: aria2 will resume download if the transfer is restarted.
Download: If there are any errors, then see the log file. See '-l' option in help/man page for details.

ERROR Download failed! (Error 2) Timeout
ERROR https://t1.daumcdn.net/potplayer/PotPlayer/Version/201021/PotPlayerSetup64.exe#/dl.7z
    referer=https://t1.daumcdn.net/potplayer/PotPlayer/Version/201021/PotPlayerSetup64.exe#/
    dir=D:\Scoop\cache
    out=potplayer#201021#https_t1.daumcdn.net_potplayer_PotPlayer_Version_201021_PotPlayerSetup64.exe_dl.7z

ERROR & 'D:\Scoop\apps\aria2\current\aria2c.exe' --input-file='D:\Scoop\cache\potplayer.txt' --user-agent='Scoop/1.0 (+http://scoop.sh/) PowerShell/5.1 (Windows NT 10.0; Win64; x64; Desktop)' --allow-overwrite=true --auto-file-renaming=false --retry-wait=2 --split=5 --max-connection-per-server=5 --min-split-size=5M --console-log-level=warn --enable-color=false --no-conf=true --follow-metalink=true --metalink-preferred-protocol=https --min-tls-version=TLSv1.2 --stop-with-process=12148 --continue --summary-interval 0

Please try again or create a new issue by using the following link and paste your console output:
https://github.com/lukesampson/scoop-extras/issues/new?title=potplayer%40201021%3a+download+via+aria2+failed
```

从错误信息里面，我们可以找到其下载地址，即**ERROR**中的**referer**，用你自己的途径（看好你哦）下载过来，然后改名为**out**指定的值，并移至**dir**指定的目录中。

以上面安装**potplayer**失败为例:
* App的下载地址为: `https://t1.daumcdn.net/potplayer/PotPlayer/Version/201021/PotPlayerSetup64.exe`,手动下载后
* 改名为`potplayer#201021#https_t1.daumcdn.net_potplayer_PotPlayer_Version_201021_PotPlayerSetup64.exe_dl.7z`
* 然后移动到目录`D:\Scoop\cache`

这时只是手动做了下载这一步的工作，安装还需要：
```powershell
# 前面安装失败，scoop仍然会认为已经安装，这里卸载一下，scoop会认为已经卸载了
scoop uninstall potplayer
# 再次安装，scoop从cache目录会找到我们下好的app进行安装
scoop install potplayer
```

至此，安装成功

have fun!

## 参考
* [Scoop](https://scoop.sh/)
* [「一行代码」搞定软件安装卸载，用 Scoop 管理你的 Windows 软件](https://sspai.com/post/52496)
* [scoop——强大的Windows命令行包管理工具](https://www.jianshu.com/p/50993df76b1c)
* [给 Scoop 加上这些软件仓库，让它变成强大的 Windows 软件管理器](https://sspai.com/post/52710#!)

本文完
