---
title: 笔记
icon: fas fa-pen-nib
order: 1
group: 内容
layout: notes
---

{% assign posts = site.categories["笔记"] %}
{% if posts.size > 0 %}

{% assign groups = posts | group_by: 'note_category' %}

{% for group in groups %}
{% if group.name == '' %}{% continue %}{% endif %}
<h2 id="note-group-{{ group.name | slugify }}" class="note-group">{{ group.name }}</h2>

<ul class="tab-post-list">
{% for post in group.items %}
  <li>
    <span class="date">{{ post.date | date: "%Y-%m-%d" }}</span>
    <a href="{{ post.url | relative_url }}">{{ post.title }}</a>
  </li>
{% endfor %}
</ul>
{% endfor %}

{% assign ungrouped = posts | where_exp: 'item', 'item.note_category == nil' %}
{% if ungrouped.size > 0 %}
<h2 id="note-group-misc" class="note-group">未分类</h2>

<ul class="tab-post-list">
{% for post in ungrouped %}
  <li>
    <span class="date">{{ post.date | date: "%Y-%m-%d" }}</span>
    <a href="{{ post.url | relative_url }}">{{ post.title }}</a>
  </li>
{% endfor %}
</ul>
{% endif %}

{% else %}

这里放课程与读书的笔记，正在整理，敬请期待。

{% endif %}
