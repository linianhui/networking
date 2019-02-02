#reference "NuGet.Packaging"

#load nuget.tool.cake

var target = Argument("target", "default");

var rootPath     = "../";
var srcPath      = rootPath + "1-src/";
var testPath     = rootPath + "2-test/";
var distPath     = rootPath + "3-dist/";

var solution     = rootPath + "networking.sln";
var srcProjects  = GetFiles(srcPath + "**/*.csproj");
var testProjects = GetFiles(testPath + "**/*.csproj");

var nugetTool = NuGetTool.FromCakeContext(Context);

Task("clean")
    .Description("清理项目缓存")
    .Does(() =>
{
    DeleteFiles(distPath + "*.trx");
    DeleteFiles(distPath + "*.nupkg");
    CleanDirectories(srcPath + "**/bin");
    CleanDirectories(srcPath + "**/obj");
    CleanDirectories(testPath + "**/bin");
    CleanDirectories(testPath + "**/obj");
});

Task("restore")
    .Description("还原项目依赖")
    .Does(() =>
{
    DotNetCoreRestore(solution);
});

Task("build")
    .Description("编译项目")
    .IsDependentOn("clean")
    .IsDependentOn("restore")
    .Does(() =>
{
    var buildSetting = new DotNetCoreBuildSettings{
        NoRestore = true
    };
     
    DotNetCoreBuild(solution, buildSetting);
});


Task("test")
    .Description("运行测试")
    .IsDependentOn("build")
    .Does(() =>
{
    var testSetting = new DotNetCoreTestSettings{
        ArgumentCustomization = _ => _.Append("--verbosity normal")
                                      .Append("--logger trx")
                                      .Append("--results-directory " + MakeAbsolute(Directory(distPath))),
        NoRestore = true,
        NoBuild = true
    };

    foreach(var testProject in testProjects)
    {
        DotNetCoreTest(testProject.FullPath, testSetting);
    }
});

Task("pack")
    .Description("nuget打包")
    .IsDependentOn("test")
    .Does(() =>
{
    var projectFilePaths = srcProjects.Select(_=>_.FullPath).ToList();

    nugetTool.Pack(projectFilePaths, distPath);
});

Task("push")
    .Description("nuget发布")
    .IsDependentOn("pack")
    .Does(() =>
{
    var packageFilePaths = GetFiles(distPath + "*.symbols.nupkg").Select(_=>_.FullPath).ToList();

    nugetTool.Push(packageFilePaths);
});

Task("default")
    .Description("默认-运行测试(-target test)")
    .IsDependentOn("test");

RunTarget(target);
