using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
class Build : NukeBuild
{public static int Main () => Execute<Build>(x => x.Publish);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution] readonly Solution Solution;

    AbsolutePath PublishOutput => RootDirectory / "publish";
    string OutputArchiveName => "clipboard-service.zip";
    string ProjectName => "Mesi.Io.Clipboard.Web";

    Target Clean => _ => _
        .Executes(() =>
        {
            DotNetClean();
            DeleteFile(RootDirectory / OutputArchiveName);
            CleanPublishOutput();
        });

    Target Publish => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetPublish(settings => settings
                .SetProject(RootDirectory / $"src/{ProjectName}")
                .SetConfiguration("Release")
                .SetOutput(PublishOutput / "clipboard-service"));
            
            CopyFile("docker/Dockerfile", $"{PublishOutput}/Dockerfile");
            CopyFile("docker/docker-compose.yml", $"{PublishOutput}/docker-compose.yml");

            CompressionTasks.Compress(PublishOutput, RootDirectory / OutputArchiveName);
            
            CleanPublishOutput();
        });

    void CleanPublishOutput()
    {
        EnsureCleanDirectory(PublishOutput);
        DeleteDirectory(PublishOutput);
    }
}