---
title: 笔记
icon: fas fa-pen-nib
order: 1
group: 内容
---

{% assign posts = site.categories["笔记"] %}
{% if posts.size > 0 %}

<ul class="tab-post-list">
{% for post in posts %}
  <li>
    <span class="date">{{ post.date | date: "%Y-%m-%d" }}</span>
    <a href="{{ post.url | relative_url }}">{{ post.title }}</a>
  </li>
{% endfor %}
</ul>

{% else %}

这里放课程与读书的笔记，正在整理，敬请期待。

{% endif %}
