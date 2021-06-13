var target       = Argument("target", "default");

var rootPath     = "../";
var srcPath      = rootPath + "src/";
var testPath     = rootPath + "test/";
var distPath     = rootPath + "dist/";
var distTestPath = distPath + "test/";
var distPackPath = distPath + "pack/";

var solution     = rootPath + "networking.sln";
var srcProjects  = GetFiles(srcPath + "**/*.csproj");
var testProjects = GetFiles(testPath + "**/*.csproj");

Task("clean")
    .Description("清理项目缓存")
    .Does(() =>
{
    DeleteFiles(distTestPath + "*.trx");
    DeleteFiles(distPackPath + "*.nupkg");
    DeleteFiles(distPackPath + "*.snupkg");
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
    var buildSetting = new DotNetCoreBuildSettings {
        NoRestore             = true
    };

    DotNetCoreBuild(solution, buildSetting);
});

Task("test")
    .Description("运行测试")
    .IsDependentOn("build")
    .Does(() =>
{
    var testSetting = new DotNetCoreTestSettings {
        NoRestore        = true,
        NoBuild          = true,
        Loggers          = new String[]{"trx"},
        Verbosity        = DotNetCoreVerbosity.Normal,
        ResultsDirectory = distTestPath
    };

    foreach(var testProject in testProjects)
    {
        DotNetCoreTest(testProject.FullPath, testSetting);
    }
});

Task("pack-snupkg")
    .Description("nuget打包")
    .Does(() =>
{
    var packSetting = new DotNetCorePackSettings {
        Configuration         = "Release",
        OutputDirectory       = distPackPath,
        NoBuild               = false,
        ArgumentCustomization = args => args.Append("-p:PackageReadmeFile=")
    };

    foreach(var srcProject in srcProjects)
    {
        DotNetCorePack(srcProject.FullPath, packSetting);
    }

    DeleteFiles(distPackPath + "*.nupkg");
});

Task("pack-nupkg")
    .Description("nuget打包")
    .Does(() =>
{
    var packSetting = new DotNetCorePackSettings {
        Configuration         = "Release",
        OutputDirectory       = distPackPath,
        NoBuild               = false,
        ArgumentCustomization = args => args.Append("-p:SymbolPackageFormat=symbols.nupkg")
    };

    foreach(var srcProject in srcProjects)
    {
        DotNetCorePack(srcProject.FullPath, packSetting);
    }

    DeleteFiles(distPackPath + "*.symbols.nupkg");
});

Task("pack")
    .Description("nuget打包")
    .IsDependentOn("test")
    .IsDependentOn("pack-snupkg")
    .IsDependentOn("pack-nupkg");

Task("default")
    .Description("默认-运行测试(-target test)")
    .IsDependentOn("test");

RunTarget(target);
