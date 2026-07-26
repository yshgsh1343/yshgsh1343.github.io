---
title: 2026.3 GitHub Education 学生认证踩坑记录
description: 真实学生在 GitHub Education 认证里可能遇到的网络、资料和误判问题，以及尽量走官方路径的排查思路。
date: 2026-03-28 18:00:00 +0800
categories: [搞七捻三, 折腾记录]
tags: [GitHub Education, 学生认证]
---

## [前言](https://linux.do/t/topic/1841676#p-15783973-h-1)

由于近两年 github 学生认证逐渐收紧到真学生都过不去认证，且国内直连 GitHub 本就困难，而审核要求关闭 VPN 并共享地理位置。用校园网网页刷不出来 github，用 VPN 则 IP 地址对不上。于是即使是真学生也需要采取特殊手段，下面是个人通过学生认证的截图。
[![2026-03-28-15-54-38-image](https://cdn3.ldstatic.com/optimized/4X/7/0/5/705500f15b457ad9c1a9f7f87125828adb362051_2_690x290.png)](https://cdn3.ldstatic.com/original/4X/7/0/5/705500f15b457ad9c1a9f7f87125828adb362051.png)

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
[![2026-03-28-16-23-51-image](https://cdn3.ldstatic.com/optimized/4X/e/b/6/eb64dbe033a0f237068ca27370017cdb9d0a4112_2_690x355.png)](https://cdn3.ldstatic.com/original/4X/e/b/6/eb64dbe033a0f237068ca27370017cdb9d0a4112.png)

Chorme 浏览器位置

[![2026-03-28-16-39-26-image](https://cdn3.ldstatic.com/optimized/4X/7/0/3/703cd572468287da03752244262f0b36386ba9b4_2_690x358.png)](https://cdn3.ldstatic.com/original/4X/7/0/3/703cd572468287da03752244262f0b36386ba9b4.png)

**Tips**：如果 Chrome 提示 “浏览器由贵单位管理” 导致无法修改，请：

1. `Win+R `输入 `RegEdit` 运行注册表。
2. 删除 `\HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Google\Chrome `整个目录。

**Tips2**：  

如果改 doh 还是用不了检查有无 ech（一般默认开启，开梯子的话浏览器会关闭 ech）检查界面：[Welcome to defo.ie](https://defo.ie/ech-check.php)

#### [2. 修改个人信息 （Profile 易忽略）](https://linux.do/t/topic/1841676#p-15783973-h-2-profile-6)

修改姓名
[![2026-03-28-16-07-14-image](https://cdn3.ldstatic.com/optimized/4X/a/1/f/a1f843fc204a1fb4aedd7a826ad339a576b8dc3e_2_690x361.png)](https://cdn3.ldstatic.com/original/4X/a/1/f/a1f843fc204a1fb4aedd7a826ad339a576b8dc3e.png)

账单信息
[![2026-03-28-16-06-31-image](https://cdn3.ldstatic.com/optimized/4X/7/0/c/70c72f9a1711a9a679b19e74a7e4503b0ee4287e_2_690x419.png)](https://cdn3.ldstatic.com/original/4X/7/0/c/70c72f9a1711a9a679b19e74a7e4503b0ee4287e.png)

#### [3. 绑定 edu.cn 邮箱与开启 2FA](https://linux.do/t/topic/1841676#p-15783973-h-3educn2fa-7)

笔者注册 github 就用的 edu.cn 所以此处不赘述，仅贴链接 [Sign in to GitHub · GitHub](https://github.com/settings/emails)

**2FA 验证**

[![2026-03-28-16-11-09-image](https://cdn3.ldstatic.com/optimized/4X/a/f/6/af690f068056c3c6f8ed3914ecb6b510176b8340_2_690x355.png)](https://cdn3.ldstatic.com/original/4X/a/f/6/af690f068056c3c6f8ed3914ecb6b510176b8340.png)

安卓在软件商城下载 Authenticator 扫码即可，记得保存 recovery code。苹果据说可以直接扫码。

#### [4. 开始申请学生认证](https://linux.do/t/topic/1841676#p-15783973-h-4-8)

[![2026-03-28-16-20-16-image](https://cdn3.ldstatic.com/optimized/4X/7/5/a/75a614de56384f7b3097a5d77b5d6c4cc2a61404_2_405x500.png)](https://cdn3.ldstatic.com/original/4X/7/5/a/75a614de56384f7b3097a5d77b5d6c4cc2a61404.png)

可以看见如果第二步绑定成功这一步可以直接选择 select this school 不需要填写详细信息。

理论上这一步 share location 就可以通过但可以**加一道保险**。

**打开开发者工具**（依旧 Brave 举例子
[![2026-03-28-16-43-35-image](https://cdn3.ldstatic.com/optimized/4X/a/4/d/a4d070899a09295f1b343b70dc337413c7f2dffe_2_494x499.png)](https://cdn3.ldstatic.com/original/4X/a/4/d/a4d070899a09295f1b343b70dc337413c7f2dffe.png)

位置改为其他，经纬度使用 [http://jingweidu.757dy.com](http://jingweidu.757dy.com/) 查询。越精确越好。

Chorme

[![2026-03-28-16-47-34-image](https://cdn3.ldstatic.com/optimized/4X/4/5/9/45922d518a740bcede0e881937473cca8a239c39_2_416x499.png)](https://cdn3.ldstatic.com/original/4X/4/5/9/45922d518a740bcede0e881937473cca8a239c39.png)

#### [5. 按要求上传个人信息](https://linux.do/t/topic/1841676#p-15783973-h-5-9)

[![2026-03-28-16-53-35-image](https://cdn3.ldstatic.com/optimized/4X/a/c/e/ace0581e57899eb749029d7f658348b3e38fda60_2_403x500.png)](https://cdn3.ldstatic.com/original/4X/a/c/e/ace0581e57899eb749029d7f658348b3e38fda60.png)

选择 **8.other**，先用 `win+x` 打开设备管理器禁用笔记本自带摄像头，数据线连接手机与电脑（同一 wifi 也行开热点），两台设备打开 **Irium Webcam** 准备拍屏幕。

- **方法一：记事本大法（疑似已失效）**

[![2026-03-28-16-57-53-image](https://cdn3.ldstatic.com/original/4X/6/b/8/6b83be2da5da97f5bf7ba2b8e0e23a3e2165e161.png)](https://cdn3.ldstatic.com/original/4X/6/b/8/6b83be2da5da97f5bf7ba2b8e0e23a3e2165e161.png)

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

[![2026-03-28-17-03-00-image](https://cdn3.ldstatic.com/optimized/4X/a/8/4/a84f4b1e99d5a740b3d521b95b34a8022929a014_2_396x500.png)](https://cdn3.ldstatic.com/original/4X/a/8/4/a84f4b1e99d5a740b3d521b95b34a8022929a014.png)

手机拍摄电脑屏幕，如果后续跳出第六步为何不在对应位置选择 distance learning 提交。

## [参考](https://linux.do/t/topic/1841676#p-15783973-h-10)

[https://linux.do/t/topic/1413847](https://linux.do/t/topic/1413847)

[github 学生认证常见问题解决方案（已 Approved） - Caicaixiong](https://zhaojianjun2004.github.io/2025/09/16/github_student)

与正文无关的哈气

实际上我认为解决在校生也要跑这么远路认证的方法是：

[![Snipaste_2026-03-28_17-43-21](https://cdn3.ldstatic.com/optimized/4X/2/8/1/281645169f6eab1b8209fbdd2ba2303e2aa61643_2_690x375.jpeg)](https://cdn3.ldstatic.com/original/4X/2/8/1/281645169f6eab1b8209fbdd2ba2303e2aa61643.jpeg)

昨晚找 npy 吐槽学生认证的时候，npy 突然说因为我写话题太少了，我昨天那个帖子会被人当成起号，正好我折腾完了学生认证那就发一个吧（）
