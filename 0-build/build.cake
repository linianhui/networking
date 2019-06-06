var target = Argument("target", "default");

var rootPath     = "../";
var srcPath      = rootPath + "1-src/";
var testPath     = rootPath + "2-test/";
var distPath     = rootPath + "3-dist/";

var solution     = rootPath + "networking.sln";
var srcProjects  = GetFiles(srcPath + "**/*.csproj");
var testProjects = GetFiles(testPath + "**/*.csproj");


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
    var testSetting = new DotNetCoreTestSettings {
        ArgumentCustomization = _ => _.Append("--verbosity normal")
                                      .Append("--logger trx")
                                      .Append("--results-directory " + MakeAbsolute(Directory(distPath))),
        NoRestore             = true,
        NoBuild               = true
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
    var GIT_COMMIT_SHA = EnvironmentVariable("GIT_COMMIT_SHA");

    var packSetting = new DotNetCorePackSettings
    {
        Configuration   = "Release",
        OutputDirectory = distPath,
        IncludeSource   = true,
        IncludeSymbols  = true,
        NoBuild         = false,
        VersionSuffix   = GIT_COMMIT_SHA == null ? null : "git-sha-" + GIT_COMMIT_SHA
    };

    foreach(var srcProject in srcProjects)
    {
        DotNetCorePack(srcProject.FullPath, packSetting);
    }
});

Task("default")
    .Description("默认-运行测试(-target test)")
    .IsDependentOn("test");

RunTarget(target);
