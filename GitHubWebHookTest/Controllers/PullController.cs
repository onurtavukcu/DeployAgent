//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Net.Http;
//using System.Diagnostics;
//using LibGit2Sharp;
//using System.IO;

//namespace GitHubWebHookTest.Controllers
//{
//    [ApiController]
//    [Route("[controller/PullRepo]")]
//    public class PullController : Controller
//    {

//        string fileName = @"C:\Program Files\Git.git-bash.exe";
//        string command = "git pull";
//        string workingDir = @"C:\Codebase\Github\onurtavukcu\DeployAgent";

//        public static void ExecuteGitBashCommand(string fileName, string command, string workingDir)
//        {

//            ProcessStartInfo processStartInfo = new ProcessStartInfo(fileName, "-c \" " + command + " \"")
//            {

//                WorkingDirectory = workingDir,
//                RedirectStandardOutput = true,
//                RedirectStandardError = true,
//                RedirectStandardInput = true,
//                UseShellExecute = false,
//                CreateNoWindow = true,
//                Arguments = command
//            };

//            var process = Process.Start(processStartInfo);
//            process.WaitForExit();
//            StreamWriter wr = process.StandardInput;
//            StreamReader rr = process.StandardOutput;
//            wr.Write(command);

//            Console.WriteLine(rr.ReadToEnd());
//            wr.Flush();

//            string output = process.StandardOutput.ReadToEnd();
//            string error = process.StandardError.ReadToEnd();
//            var exitCode = process.ExitCode;

//            process.Close();

//        }

//        [HttpGet]
//        public IActionResult Get()
//        {
//            ExecuteGitBashCommand(fileName, command, workingDir);
//            return Ok();
//        }
//    }
//}
