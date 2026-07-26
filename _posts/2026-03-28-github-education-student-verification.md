---
title: 2026.3 GitHub Education 学生认证踩坑记录
description: 真实学生在 GitHub Education 认证里可能遇到的网络、资料和误判问题，以及尽量走官方路径的排查思路。
date: 2026-03-28 18:00:00 +0800
categories: [搞七捻三, 折腾记录]
tags: [GitHub Education, 学生认证]
---

## [前言](https://linux.do/t/topic/1841676#p-15783973-h-1)

由于近两年 github 学生认证逐渐收紧到真学生都过不去认证，且国内直连 GitHub 本就困难，而审核要求关闭 VPN 并共享地理位置。用校园网网页刷不出来 github，用 VPN 则 IP 地址对不上。于是即使是真学生也需要采取特殊手段，下面是个人通过学生认证的截图。
![2026-03-28-15-54-38-image](/assets/img/posts/github-edu/github-edu-approved.png)

## [准备工作](https://linux.do/t/topic/1841676#p-15783973-h-2)

1. edu 邮箱
2. 可以使用加密 DNS 服务的浏览器，不推荐 Edge ，其实 edge 也行同样改 dns，只是考虑到此浏览器偶尔 bug 会有 ech 没自动打开的情况。
3. 一根数据线与 Irium Webcam，手机需要前往 Play 商店下载。电脑端 [https://iriun.com/](https://iriun.com/)

## [注意事项](https://linux.do/t/topic/1841676#p-15783973-h-3)

1. 全程避免任何 VPN 工具使用，**不要在申请过程中反复开关 VPN**
2. Github 实名较为关键不可省略。痛失网名

## [步骤](https://linux.do/t/topic/1841676#p-15783973-h-4)

#### [1. 修改 DoH](https://linux.do/t/topic/1841676#p-15783973-h-1doh-5)

修改 DoH 使得可以在国内环境免 VPN 工具直连 Github。笔者此处使用为 Brave 浏览器，设置 - 隐私与安全 - 高级，打开使用安全 DNS 把 DNS 提供商改为 Cloudfare（1.1.1.1）。
![2026-03-28-16-23-51-image](/assets/img/posts/github-edu/brave-doh.png)

Chorme 浏览器位置

![2026-03-28-16-39-26-image](/assets/img/posts/github-edu/chrome-doh.png)

**Tips**：如果 Chrome 提示 “浏览器由贵单位管理” 导致无法修改，请：

1. `Win+R `输入 `RegEdit` 运行注册表。
2. 删除 `\HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Google\Chrome `整个目录。

**Tips2**：  

如果改 doh 还是用不了检查有无 ech（一般默认开启，开梯子的话浏览器会关闭 ech）检查界面：[Welcome to defo.ie](https://defo.ie/ech-check.php)

#### [2. 修改个人信息 （Profile 易忽略）](https://linux.do/t/topic/1841676#p-15783973-h-2-profile-6)

修改姓名
![2026-03-28-16-07-14-image](/assets/img/posts/github-edu/profile-name.png)

账单信息
![2026-03-28-16-06-31-image](/assets/img/posts/github-edu/billing-info.png)

#### [3. 绑定 edu.cn 邮箱与开启 2FA](https://linux.do/t/topic/1841676#p-15783973-h-3educn2fa-7)

笔者注册 github 就用的 edu.cn 所以此处不赘述，仅贴链接 [Sign in to GitHub · GitHub](https://github.com/settings/emails)

**2FA 验证**

![2026-03-28-16-11-09-image](/assets/img/posts/github-edu/two-fa.png)

安卓在软件商城下载 Authenticator 扫码即可，记得保存 recovery code。苹果据说可以直接扫码。

#### [4. 开始申请学生认证](https://linux.do/t/topic/1841676#p-15783973-h-4-8)

![2026-03-28-16-20-16-image](/assets/img/posts/github-edu/apply-select-school.png)

可以看见如果第二步绑定成功这一步可以直接选择 select this school 不需要填写详细信息。

理论上这一步 share location 就可以通过但可以**加一道保险**。

**打开开发者工具**（依旧 Brave 举例子
![2026-03-28-16-43-35-image](/assets/img/posts/github-edu/devtools-location.png)

位置改为其他，经纬度使用 [http://jingweidu.757dy.com](http://jingweidu.757dy.com/) 查询。越精确越好。

Chorme

![2026-03-28-16-47-34-image](/assets/img/posts/github-edu/chrome-sensors.png)

#### [5. 按要求上传个人信息](https://linux.do/t/topic/1841676#p-15783973-h-5-9)

![2026-03-28-16-53-35-image](/assets/img/posts/github-edu/upload-other.png)

选择 **8.other**，先用 `win+x` 打开设备管理器禁用笔记本自带摄像头，数据线连接手机与电脑（同一 wifi 也行开热点），两台设备打开 **Irium Webcam** 准备拍屏幕。

- **方法一：记事本大法（疑似已失效）**

![2026-03-28-16-57-53-image](/assets/img/posts/github-edu/notepad-method.png)

```
Student Verification Report
Name:                   
School:                 
Student ID:                
Study Form: Distance learning
Validate Until:
Student xxx,is allowed to study via distance learning in xxx
```

注意 `Study Form` 一栏填写 `Distance learning` ，下边那句 `Student xxx,is allowed to study via distance learning` 别省略。这样如果后续爆出询问为何不在当前地址就可以选择 distance learning。

- 方法二：学信网申请学籍报告下载，丢到 google 翻译成英文。再采用任意 pdf 修改器修改字体大小（学信网那个报告字太小了 github 识别容易失误）+ 就读方式改为 Distance learning  

![2026-03-28-17-03-00-image](/assets/img/posts/github-edu/chsi-report.png)

手机拍摄电脑屏幕，如果后续跳出第六步为何不在对应位置选择 distance learning 提交。

## [参考](https://linux.do/t/topic/1841676#p-15783973-h-10)

[https://linux.do/t/topic/1413847](https://linux.do/t/topic/1413847)

[github 学生认证常见问题解决方案（已 Approved） - Caicaixiong](https://zhaojianjun2004.github.io/2025/09/16/github_student)
