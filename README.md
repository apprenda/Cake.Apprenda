# Cake.Apprenda

Cake.Apprenda is a [Cake](http://cakebuild.net) [add-in](http://cakebuild.net/docs/fundamentals/preprocessor-directives) that exposes [Apprenda](http://apprenda.com) tools to your build scripts.

[![Build status](https://ci.appveyor.com/api/projects/status/8jiukjuo45erwkds?svg=true)](https://ci.appveyor.com/project/austinlparker/cake-apprenda)

## Table of Contents

1. [Building](https://github.com/apprenda/cake.apprenda#building)
2. [Pre-Requisites](https://github.com/apprenda/cake.apprenda#pre-requisites)
3. [Example](https://github.com/apprenda/cake.apprenda#example)    
    - [Create a Cake script](https://github.com/apprenda/cake.apprenda#1-create-a-cake-script)
    - [Run it!](https://github.com/apprenda/cake.apprenda#2-run-it)
4. [Contributing](https://github.com/apprenda/cake.apprenda#contributing)
5. [License](https://github.com/apprenda/cake.apprenda#license)

## Building
This package is built using [Cake.Recipe](https://github.com/cake-contrib/Cake.Recipe)
```
> .\build.ps1
```

## Pre-Requisites

Most importantly, it's important to realize that this Cake add-in is intended to be used against an existing Apprenda Cloud and is fairly specialized in that regard.  In this context, "pre-requisite" doesn't mean "go and install Apprenda", but rather target an existing instance in your hosting environment.

 - Apprenda Cloud with appropriate tenant credentials and access.
 - Apprenda SDK installed on your development machine or CI server (required to build sample app)
 - Access to `ACS.exe` and/or `AMM.exe`.
 
 There are several ways you can configure your build environment for the tool executables:
  - Install the Apprenda SDK.  The tool resolver will look in the default installation directory.
  - Add the installation path(s) to your `%PATH%` variable.
  - Create environment variable(s) `%ApprendaACSInstall%` and/or `%ApprendaAMMInstall%` with the correct installation path set.
  - Host a local (to your organization) nuget package with the tool executables and resolve the tool(s) using a `#tool` directive.  i.e., `#tool "nuget:?package=YourPackage"`

  The order of resolution will be (first to last): local tool (`#tool`), `%ApprendaACSInstall%` variable, `%PATH%` variable, and Apprenda SDK installation.  This gives you flexibility in resolving a more specific version in a given build or allowing a system-wide default.

## Example 

A full example [can be found here](https://github.com/apprenda/cake.apprenda/blob/develop/examples/Calculator)

### 1. Create a Cake Script

```
#addin "nuget:?package=Cake.Apprenda"

Task("Create-Application")
    .Description("Creates a new application from the archive, promotes application instance to the 'Sandbox' stage.")
    .Does(() => {
        CloudShell.NewApplication(new NewApplicationSettings("Sample App", "mysample"){
            Stage = ApplicationStage.Sandbox,
            ArchivePath = "./Archive.zip"
        });
    })
    .Finally(() => {
        CloudShell.DisconnectCloud();
    });
```

### 2. Run it!
```
> .\build.ps1 -target Create-Application --CloudAlias="MyCloud" --CloudUrl="http://apps.apprenda.mycloud" --UserName="myuser@company.com" --Password="*****"
```

## Contributing

If you're thinking about contributing to Cake.Apprenda, please make sure you've read the [contribution guidelines](https://github.com/apprenda/cake.apprenda/blob/develop/CONTRIBUTING.md) before creating your first pull request.

* Fork the repository.
* Create a branch to work in.
* Make your feature addition or bug fix.
* Don't forget the unit tests.
* Send a pull request.

## License

Copyright © Apprenda Inc., and contributors.

Cake.Apprenda is provided as-is under the MIT license. For more information see [LICENSE](https://github.com/apprenda/cake.apprenda/blob/develop/LICENSE).

## Code of Conduct

This project has adopted the code of conduct defined by the [Contributor Covenant](http://contributor-covenant.org/) to clarify expected behavior in our community.

