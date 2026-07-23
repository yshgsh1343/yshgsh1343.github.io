---
title: 碎碎念
icon: fas fa-comment-dots
order: 5
group: 内容
---

{% assign posts = site.categories["碎碎念"] %}
{% if posts == empty %}

一些零碎的只言片语，不成文章，但也值得留下。还没有内容，先占个位置。

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
