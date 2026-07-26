---
title: 月报
icon: fas fa-calendar-days
order: 2
group: 内容
layout: monthly
---

{% assign posts = site.categories["月报"] %}
{% if posts.size > 0 %}

{% assign years = posts | group_by_exp: 'post', 'post.date | date: "%Y"' %}

{% for year in years %}
<h2 id="year-{{ year.name }}" class="monthly-year">{{ year.name }} 年</h2>

{% assign yearly = year.items | where_exp: 'item', 'item.yearly == true' %}
{% assign regular = year.items | where_exp: 'item', 'item.yearly != true' %}
{% assign ordered = yearly | concat: regular %}

<ul class="tab-post-list">
{% for post in ordered %}
  <li>
    <span class="date">{{ post.date | date: "%Y-%m-%d" }}</span>
    <a href="{{ post.url | relative_url }}">{{ post.title }}</a>
    {% if post.yearly %}<span class="yearly-badge">年终总结</span>{% endif %}
  </li>
{% endfor %}
</ul>
{% endfor %}

{% else %}

每月一篇，记录这个月的所见、所学与所想。第一篇正在路上。

{% endif %}
