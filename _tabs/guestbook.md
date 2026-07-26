---
title: 友链 & 留言
icon: fas fa-comments
order: 8
group: 站点
comments: true
---

## 友链

{% if site.data.friends and site.data.friends.size > 0 %}

<div class="friends-grid">
{% for friend in site.data.friends %}
  <a class="friend-card" href="{{ friend.url }}" target="_blank" rel="noopener noreferrer">
    <span class="friend-card__avatar">
      {%- if friend.avatar and friend.avatar != '' -%}
        <img src="{{ friend.avatar }}" alt="" loading="lazy" onerror="this.remove()">
      {%- else -%}
        {{ friend.name | slice: 0 }}
      {%- endif -%}
    </span>
    <span class="friend-card__body">
      <span class="friend-card__name">{{ friend.name }}</span>
      {%- if friend.desc -%}
        <span class="friend-card__desc">{{ friend.desc }}</span>
      {%- endif -%}
    </span>
  </a>
{% endfor %}
</div>

{% else %}

还没有友链，虚位以待。

{% endif %}

想交换友链？在下面留言告诉我你的站点，或发邮件到 [{{ site.social.email }}](mailto:{{ site.social.email }})。

## 留言

想对我说些什么？无论是建议、问题，还是随便聊聊，都欢迎。也可以在 [GitHub](https://github.com/{{ site.github.username }}) 上给我提 Issue 或 PR。

{% include cwd-comments.html %}
