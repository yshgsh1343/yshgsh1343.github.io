// 歌单导出工具的本地 exe 外壳：交互式输入歌单 ID/链接，
// 内部用 curl 取数到临时文件、交给 tools/export-playlist.mjs（--in），导出逻辑不在这里重复。
// 不走 stdin 管道：.NET Framework 关闭子进程 stdin 后 node 收不到 EOF，会挂死。
// ID 只在本进程内存和用完即删的临时文件里过一遍，不进 shell 历史、不进仓库。
// 构建：双击 tools/build-export-shell.cmd（用 Windows 自带 csc，无需安装任何东西）。
// C# 5 语法（系统自带 csc 的上限），不要用字符串插值等新特性。

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

static class ExportPlaylistShell
{
    static int Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("=== 歌单快照导出 ===");
        Console.WriteLine("把网易云歌单导出为 assets/data/music.json，歌单 ID 不会写入任何文件。");
        Console.WriteLine();

        string repoRoot = FindRepoRoot();
        if (repoRoot == null)
        {
            return Fail("没找到仓库根目录（向上找不到 _config.yml）。把 exe 放在仓库的 tools/ 目录下再运行。");
        }

        Console.Write("歌单 ID 或歌单链接: ");
        string input = Console.ReadLine();
        string id = ExtractId(input);
        if (id == null)
        {
            return Fail("没解析出歌单 ID。可以直接粘贴歌单页链接，或只输入 id= 后面的数字。");
        }

        string tempFile = Path.Combine(Path.GetTempPath(), "mp-export-" + Guid.NewGuid().ToString("N") + ".json");
        try
        {
            Console.WriteLine();
            Console.WriteLine("[1/2] curl 拉取歌单……");
            string curlOut;
            string curlError;
            int curlExit = RunCapture(
                "curl",
                "-s --max-time 60 -o \"" + tempFile + "\" \"https://api.injahow.cn/meting/?server=netease&type=playlist&id=" + id + "\"",
                repoRoot, out curlOut, out curlError);
            if (curlExit != 0)
            {
                return Fail("curl 失败（退出码 " + curlExit + "）。检查网络后重试。\n" + curlError);
            }
            string payload = File.Exists(tempFile) ? File.ReadAllText(tempFile, Encoding.UTF8) : null;
            if (payload == null || !payload.TrimStart().StartsWith("["))
            {
                string head = payload == null ? "(空)" : payload.Substring(0, Math.Min(200, payload.Length));
                return Fail("接口没有返回歌曲列表。歌单是不是私密的？接口只读得到公开歌单。\n返回内容开头: " + head);
            }

            Console.WriteLine("[2/2] 交给 export-playlist.mjs 写快照……");
            string nodeOut;
            string nodeError;
            int nodeExit = RunCapture(
                "node",
                "\"" + Path.Combine("tools", "export-playlist.mjs") + "\" " + id + " --in \"" + tempFile + "\"",
                repoRoot, out nodeOut, out nodeError);
            if (!string.IsNullOrWhiteSpace(nodeOut)) Console.WriteLine(nodeOut.Trim());
            if (!string.IsNullOrWhiteSpace(nodeError)) Console.WriteLine(nodeError.Trim());
            if (nodeExit != 0)
            {
                return Fail("导出脚本失败（退出码 " + nodeExit + "）。node 是否在 PATH 里？");
            }
        }
        finally
        {
            try { if (File.Exists(tempFile)) File.Delete(tempFile); } catch { }
        }

        Console.WriteLine();
        Console.WriteLine("完成。检查无误后提交 assets/data/music.json 即可。");
        Pause();
        return 0;
    }

    // 从裸数字或歌单链接（…playlist?id=123456…）里取出 ID
    static string ExtractId(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return null;
        input = input.Trim();
        if (Regex.IsMatch(input, "^\\d+$")) return input;
        Match match = Regex.Match(input, "id=(\\d+)");
        return match.Success ? match.Groups[1].Value : null;
    }

    static string FindRepoRoot()
    {
        // 先从 exe 所在目录向上找，双击运行时 cwd 不可靠；再从 cwd 向上兜底
        string[] starts =
        {
            AppDomain.CurrentDomain.BaseDirectory,
            Directory.GetCurrentDirectory()
        };
        foreach (string start in starts)
        {
            DirectoryInfo dir = new DirectoryInfo(start);
            for (int i = 0; dir != null && i < 6; i++)
            {
                if (File.Exists(Path.Combine(dir.FullName, "_config.yml"))) return dir.FullName;
                dir = dir.Parent;
            }
        }
        return null;
    }

    static int RunCapture(string exe, string args, string workDir,
                          out string stdout, out string stderr)
    {
        stdout = null;
        stderr = null;
        try
        {
            ProcessStartInfo info = new ProcessStartInfo(exe, args)
            {
                UseShellExecute = false,
                WorkingDirectory = workDir,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8,
                CreateNoWindow = false
            };
            using (Process process = Process.Start(info))
            {
                // stderr 异步读，避免两个管道都满时互相等死
                StringBuilder errorBuffer = new StringBuilder();
                process.ErrorDataReceived += delegate(object sender, DataReceivedEventArgs e)
                {
                    if (e.Data != null) errorBuffer.AppendLine(e.Data);
                };
                process.BeginErrorReadLine();
                stdout = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                stderr = errorBuffer.ToString();
                return process.ExitCode;
            }
        }
        catch (Exception ex)
        {
            stderr = exe + " 启动失败: " + ex.Message;
            return -1;
        }
    }

    static int Fail(string message)
    {
        Console.WriteLine();
        Console.WriteLine("出错了: " + message);
        Pause();
        return 1;
    }

    static void Pause()
    {
        if (Console.IsInputRedirected) return;
        Console.WriteLine();
        Console.Write("按任意键退出……");
        Console.ReadKey(true);
    }
}
