---
title: 碎碎念
icon: fas fa-comment-dots
order: 4
group: 内容
layout: memos
---

{% assign posts = site.categories["碎碎念"] %}
{% if posts.size > 0 %}

<div class="murmur-timeline">
{% for post in posts %}
  {% assign memo_category = post.memo_category | default: post.murmur_category | default: '未分类' %}
  {% if memo_category == '' %}{% assign memo_category = '未分类' %}{% endif %}
  {% capture memo_tags %}|{% for tag in post.tags %}{{ tag }}|{% endfor %}{% endcapture %}
  <article class="murmur-item" data-memo-category="{{ memo_category | escape }}" data-memo-tags="{{ memo_tags | escape }}">
    <time class="murmur-date" datetime="{{ post.date | date_to_xmlschema }}">
      {{ post.date | date: "%Y-%m-%d %H:%M" }}
    </time>
    <div class="murmur-card">
      <div class="murmur-content" data-collapsible>{{ post.content }}</div>
      <button type="button" class="murmur-expand" hidden>展开全文</button>
    </div>
  </article>
{% endfor %}
</div>

<script>
  /* 超过 5 行的内容折叠，点"展开全文"放开。inline script 会被
     compress_html 压成一行，只能用块注释。 */
  (function () {
    var LINES = 5;
    document.querySelectorAll('.murmur-content[data-collapsible]').forEach(function (box) {
      var lineHeight = parseFloat(getComputedStyle(box).lineHeight) || 24;
      var maxHeight = lineHeight * LINES;
      if (box.scrollHeight > maxHeight + lineHeight * 0.5) {
        box.classList.add('is-clamped');
        box.style.maxHeight = maxHeight + 'px';
        var btn = box.parentElement.querySelector('.murmur-expand');
        if (!btn) return;
        btn.hidden = false;
        btn.addEventListener('click', function () {
          var clamped = box.classList.toggle('is-clamped');
          box.style.maxHeight = clamped ? maxHeight + 'px' : 'none';
          btn.textContent = clamped ? '展开全文' : '收起';
        });
      }
    });
  })();
</script>

{% else %}

一些零碎的只言片语，不成文章，但也值得留下。还没有内容，先占个位置。

{% endif %}
