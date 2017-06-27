// Build Params
var Target = Argument("Target", "Default");

// Apprenda parameters
var ApprendaCloudParams = new ApprendaCloudParameters(Context);

Task("Register-Cloud")
    .Description("Creates a registration for the given Apprenda Cloud Url and Alias")
    .Does(() => {
        Apprenda.MaintenanceMode.RegisterCloud(ApprendaCloudParams.CloudAlias, ApprendaCloudParams.CloudUrl);
    });

Task("Connect-Cloud")
    .Description("Connects to the specified cloud using the given credentials")
    .IsDependentOn("Register-Cloud")
    .Does(() => {
        Apprenda.MaintenanceMode.ConnectCloud(new Cake.Apprenda.AMM.ConnectCloud.ConnectCloudSettings {
            CloudAlias = ApprendaCloudParams.CloudAlias,
            User = ApprendaCloudParams.UserName,
            Password = ApprendaCloudParams.Password
        });
    });

Task("Get-Node-State")
    .Description("Gets the current state of the specified node")
    .IsDependentOn("Connect-Cloud")
    .Does(() => {
        var state = Apprenda.MaintenanceMode.GetNodeState(ApprendaCloudParams.HostName);
        Information("Node {0} is in state {1}", ApprendaCloudParams.HostName, state);
    });

Task("Default")
    .Description("Performs no operation")
    .Does(()=>{
        throw new CakeException("No operation is specified");
    });

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

    public string HostName { get{ return _context.Argument<string>("HostName"); } }
    public string NodeState { get{ return _context.Argument<string>("NodeState"); } }
}