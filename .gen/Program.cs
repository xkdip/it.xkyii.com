using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Statiq.App;
using Statiq.Common;
using Statiq.Web;

namespace WebGenerator
{
    public class Program
    {
        private static readonly NormalizedPath ArtifactsFolder = "artifacts";

        public static async Task<int> Main(string[] args) =>
            await Bootstrapper
                .Factory
                .CreateWeb(args)
                .ConfigureEngine(x =>
                {
                    Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
                    x.FileSystem.RootPath = new NormalizedPath(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent;
                    x.FileSystem.OutputPath = x.FileSystem.RootPath / ArtifactsFolder;
                    x.FileSystem.InputPaths.Clear();
                    x.FileSystem.InputPaths.Add(x.FileSystem.RootPath);
                })
                .AddSetting(WebKeys.ExcludedPaths, new List<NormalizedPath>
                {
                    new NormalizedPath(".gen"),
                    new NormalizedPath(".github"),
                    new NormalizedPath(".git"),
                })
                .RunAsync();
    }
}
