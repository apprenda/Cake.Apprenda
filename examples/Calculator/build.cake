// Build Params
var Target = Argument("Target", "Build");
var Configuration = Argument("Configuration", "Release");

// Apprenda parameters
var ApprendaCloudParams = new ApprendaCloudParameters(Context);

Task("Build")
    .Description("Builds the sample solution")
    .Does(() => {
        MSBuild("./Calculator.sln", new MSBuildSettings {
            Verbosity = Verbosity.Minimal,
            Configuration = Configuration,
            PlatformTarget = PlatformTarget.MSIL
        });
    });

Task("Register-Cloud")
    .Description("Creates a registration for the given Apprenda Cloud Url and Alias")
    .Does(() => {
        CloudShell.RegisterCloud(ApprendaCloudParams.CloudAlias, ApprendaCloudParams.CloudUrl);
    });

Task("Connect-Cloud")
    .Description("Connects to the specified cloud using the given credentials")
    .IsDependentOn("Register-Cloud")
    .Does(() => {
        CloudShell.ConnectCloud(new Cake.Apprenda.ACS.ConnectCloud.ConnectCloudSettings {
            CloudAlias = ApprendaCloudParams.CloudAlias,
            User = ApprendaCloudParams.UserName,
            Password = ApprendaCloudParams.Password
        });
    });

Task("Create-Archive")
    .Description("Creates an Apprenda application archive from the solution")
    .Does(() => {
        // create a new Apprenda application archive
        CloudShell.NewPackage(new NewPackageSettings {
            SolutionPath = "./Calculator.sln",
            ArchiveOutput = "./Archive.zip",
            BuildSettings = new BuildSettings {
                RebuildSolution = true,
                Configuration = Configuration,
                IgnoreFilters = new [] { ".sln", ".cs", ".pdb" },
                UserInterfaceProjects = new [] { "root" },
                WcfProjects = new [] { "CalculatorService" }
            }
        });
    });

Task("Create-Application")
    .Description("Creates a new application from the archive, promotes application instance to the 'Sandbox' stage.")
    .IsDependentOn("Create-Archive")
    .IsDependentOn("Connect-Cloud")
    .Does(() => {
        CloudShell.NewApplication(new NewApplicationSettings("Calculator App", "calcapp"){
            Stage = ApplicationStage.Sandbox,
            ArchivePath = "./Archive.zip"
        });
    })
    .Finally(() => {
        CloudShell.DisconnectCloud();
    });

Task("Remove-Application")
    .Description("Deletes the application")
    .IsDependentOn("Connect-Cloud")
    .Does(() => {
        CloudShell.RemoveApplication("calcapp");
    });

Task("Default")
    .Description("Performs the default task, which is 'Build'")
    .IsDependentOn("Build");

RunTarget(Target);

// Quick wrapper class around Apprenda params to defer the parameter binding until the required parameters are actually needed.
public sealed class ApprendaCloudParameters
{
    private readonly ICakeContext _context;

    public ApprendaCloudParameters(ICakeContext context)
    {
        _context = context;
    }

    public string CloudAlias { get { return _context.Argument<string>("CloudAlias"); } }
    public string CloudUrl { get { return _context.Argument<string>("CloudUrl"); } }

    public string UserName { get { return _context.Argument<string>("UserName"); } }
    public string Password { get { return _context.Argument<string>("Password"); } }
}