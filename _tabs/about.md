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

<!-- GitHub 贡献热力图：ghchart 直接吐 SVG；加载失败就整块隐藏 -->
<div class="gh-heatmap">
  <img
    src="https://ghchart.rshah.org/2f5d8a/{{ site.github.username }}"
    alt="{{ site.github.username }} 的 GitHub 贡献热力图"
    loading="lazy"
    onerror="this.closest('.gh-heatmap').style.display='none'"
  >
</div>

<!-- 曲库在 assets/data/music.json，换歌单：node tools/export-playlist.mjs <歌单ID> -->
{% include music-player.html %}
