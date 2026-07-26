---
# the default layout is 'page'
title: 关于
icon: fas fa-info-circle
order: 7
group: 站点
---

云水归山。BME大四本→？
一种技术笔记本/日记本性质的东西。
contact： [GitHub](https://github.com/yshgsh1343) or yshgsh1343@linux.do。
CC BY-NC-SA 4.0。

<!-- 本站更新热力图：数据来自 site.posts，构建时生成 -->
{% include site-heatmap.html %}

## 致谢

这个站点能跑起来，离不开这些项目和服务，排名不分先后：

- [Jekyll](https://jekyllrb.com/) 与 [Chirpy](https://github.com/cotes2020/jekyll-theme-chirpy) —— 站点的骨架与本站魔改的主题。
- [Font Awesome](https://fontawesome.com/) 与 [思源宋体](https://fonts.google.com/noto/specimen/Noto+Serif+SC) —— 图标与标题字体。
- [GitHub Pages](https://pages.github.com/) —— 托管与自动构建。
- [Cloudflare Workers](https://workers.cloudflare.com/) —— 评论后端跑在上面。
- [fonts.loli.net](https://fonts.loli.net/) —— Google Fonts 国内镜像。
- [ghchart](https://ghchart.rshah.org/) —— 上面那张贡献热力图。

<!-- 播放器是全站常驻的（default 布局引入），这里只是个停靠位：
     在关于页它嵌进正文，其他页面悬浮在右下角。
     曲库在 assets/data/music.json，换歌单：node tools/export-playlist.mjs <歌单ID> -->
<div id="music-player-dock"></div>
