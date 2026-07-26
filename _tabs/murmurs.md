---
title: 碎碎念
icon: fas fa-comment-dots
order: 4
group: 内容
---

{% assign posts = site.categories["碎碎念"] %}
{% if posts.size > 0 %}

<div class="murmur-timeline">
{% for post in posts %}
  <article class="murmur-item">
    <time class="murmur-date" datetime="{{ post.date | date_to_xmlschema }}">
      {{ post.date | date: "%Y-%m-%d %H:%M" }}
    </time>
    <div class="murmur-card">
      <h3 class="murmur-title"><a href="{{ post.url | relative_url }}">{{ post.title }}</a></h3>
      <div class="murmur-content">{{ post.content }}</div>
    </div>
  </article>
{% endfor %}
</div>

{% else %}

一些零碎的只言片语，不成文章，但也值得留下。还没有内容，先占个位置。

{% endif %}
