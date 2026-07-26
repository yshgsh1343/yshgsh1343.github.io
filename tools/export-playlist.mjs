#!/usr/bin/env node
// 把网易云歌单导出成本地快照，播放器读快照，歌单 ID 不进仓库。
//
// 用法: node tools/export-playlist.mjs <歌单ID> [输出路径]
// 例如: node tools/export-playlist.mjs 123456789
// 输出默认为 assets/data/music.json，换歌单后重跑一次再提交即可。
//
// 若本机 Node 连不上接口，可用 curl 取数后喂给脚本：
//   curl "https://api.injahow.cn/meting/?server=netease&type=playlist&id=<歌单ID>" | node tools/export-playlist.mjs <歌单ID> --stdin
// 或先存成文件再读（exe 外壳走的就是这条路）：
//   node tools/export-playlist.mjs <歌单ID> --in <接口返回的json文件>

import { mkdir, readFile, writeFile } from 'node:fs/promises';
import { dirname } from 'node:path';

const argv = process.argv.slice(2);
const useStdin = argv.includes('--stdin');
const inIndex = argv.indexOf('--in');
const inFile = inIndex >= 0 ? argv[inIndex + 1] : null;
const positional = argv.filter((a, i) => a !== '--stdin' && a !== '--in' && (inIndex < 0 || i !== inIndex + 1));
const [playlistId, output = 'assets/data/music.json'] = positional;

if (!playlistId || !/^\d+$/.test(playlistId) || (inIndex >= 0 && !inFile)) {
  console.error('用法: node tools/export-playlist.mjs <歌单ID> [输出路径] [--stdin | --in <文件>]');
  process.exit(1);
}

let data;
if (inFile) {
  data = JSON.parse(await readFile(inFile, 'utf8'));
} else if (useStdin) {
  let raw = '';
  for await (const chunk of process.stdin) raw += chunk;
  data = JSON.parse(raw);
} else {
  const endpoint = `https://api.injahow.cn/meting/?server=netease&type=playlist&id=${playlistId}`;
  const response = await fetch(endpoint);
  if (!response.ok) {
    console.error(`接口返回 HTTP ${response.status}，稍后再试。`);
    process.exit(1);
  }
  data = await response.json();
}
if (!Array.isArray(data) || data.length === 0) {
  console.error('没拿到歌曲。歌单是不是私密的？接口只读得到公开歌单。');
  process.exit(1);
}

// 只保留播放需要的字段；url/pic 里只含歌曲级 ID
const tracks = data
  .filter((item) => item && item.url)
  .map(({ name, artist, url, pic }) => ({ name, artist, url, pic }));

// 一首一行，方便看 diff
const json = `[\n${tracks.map((track) => JSON.stringify(track)).join(',\n')}\n]\n`;

// 兜底自查：确认快照里没混入歌单 ID
if (new RegExp(`id=${playlistId}(\\D|$)`).test(json) || json.includes('type=playlist')) {
  console.error('自查失败：输出里出现了歌单 ID，已中止写入。');
  process.exit(1);
}

await mkdir(dirname(output), { recursive: true });
await writeFile(output, json);
console.log(`已写入 ${output}：${tracks.length} 首。`);
