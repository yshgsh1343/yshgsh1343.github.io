---
title: 月报
icon: fas fa-calendar-days
order: 1
group: 内容
---

{% assign posts = site.categories["月报"] %}
{% if posts == empty %}

每月一篇，记录这个月的所见、所学与所想。第一篇正在路上。

{% else %}

<ul class="tab-post-list">
{% for post in posts %}
  <li>
    <span class="date">{{ post.date | date: "%Y-%m-%d" }}</span>
    <a href="{{ post.url | relative_url }}">{{ post.title }}</a>
  </li>
{% endfor %}
</ul>

{% endif %}
