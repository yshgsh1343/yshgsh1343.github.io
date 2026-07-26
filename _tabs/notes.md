---
title: 笔记
icon: fas fa-pen-nib
order: 1
group: 内容
layout: notes
---

{% assign posts = site.categories["笔记"] %}
{% if posts.size > 0 %}

<!-- 中间栏是纯时间流（日期左、标题右），学科归属只在右栏的知识分类里体现。 -->
<ul class="tab-post-list" id="notes-list">
{% for post in posts %}
  <li data-note-category="{{ post.note_category | default: '未分类' }}">
    <span class="date">{{ post.date | date: "%Y-%m-%d" }}</span>
    <a href="{{ post.url | relative_url }}">{{ post.title }}</a>
  </li>
{% endfor %}
</ul>

{% else %}

这里放课程与读书的笔记，正在整理，敬请期待。

{% endif %}
