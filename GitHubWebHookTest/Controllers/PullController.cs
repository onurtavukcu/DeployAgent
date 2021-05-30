using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using LibGit2Sharp;

namespace GitHubWebHookTest.Controllers
{
    [ApiController]
    [Route("[controller/PullRepo]")]
    public class PullController : Controller
    {

        string fileName = @"C:\Program Files\Git.git-bash.exe";
        string command = "pull";
        string workingDir = @"C:\Codebase\Github\onurtavukcu\DeployAgent";

        public static void ExecuteGitBashCommand(string fileName, string command, string workingDir)
        {

            ProcessStartInfo processStartInfo = new ProcessStartInfo(fileName, "-c \" " + command + " \"")
            {
                WorkingDirectory = workingDir,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = Process.Start(processStartInfo);
            process.WaitForExit();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            var exitCode = process.ExitCode;

            process.Close();

        }

        [HttpGet]
        public IActionResult Get()
        {
            ExecuteGitBashCommand(fileName, command, workingDir);
            return Ok();
        }
    }
}
