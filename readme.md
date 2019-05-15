纯C# FTP服务器
-

添加了一些命令(LIST -l,SIZE,RNFR,RNTO,SYST等),修复了一些BUG

添加了对权限控制的支持

添加了一些基础网络防护(超时未登录自动踢出,假账号密码)

添加了一些彩蛋

确保对Windows资源管理器,Chrome,MT文件管理器(安卓)的支持

中文编码适配(GBK)

支持匿名用户

添加一个TERM命令供拥有完整权限的用户远程停止FTP服务器

FTP-Server written in full C#
-

Add some commands (LIST -l,SIZE,RNFR,RNTO,SYST), bug fixs

Permission management support

Add some basic protect(kick if not logged in after timeout,fake account)

Add some EasterEggs

Perfectly support for Windows FileExplorer,Chrome,Mt FileManager(on Android)

Chinese encodings(GBK)

support for Anonymous user

A 'TERM' command for administrators to stop the server