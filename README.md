### bsStoreApp Project Layers
    Entities
    Repositories => Entities
    Services     => Entities + Repositories
    Presentation => Services
    WebApi       => Entities + Repositories + Services + Presentation

## Used Packages for Database Context

- Packages can be installed from the "[NuGet Gallery](https://www.nuget.org/packages/Microsoft.AspNet.Identity.Core)" with the help of the `Tools > NuGet Package Manager > Package Manager Console`.

- [Microsoft.EntityFrameworkCore 6.0.23](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)
```
    PM> Install-Package Microsoft.EntityFrameworkCore -Version 6.0.23 -ProjectName WebApi
```
- [Microsoft.EntityFrameworkCore.SqlServer 6.0.23](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer)
```
    PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 6.0.23 -ProjectName WebApi
```
<br/>

- To add a Controller feature to a class -> [Microsoft.AspNetCore.Mvc.Core 2.2.5](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Core)
```
    PM> Install-Package Microsoft.AspNetCore.Mvc.Core -ProjectName Presentation
```
- Service -> Open in Terminal : [NLog.Extensions.Logging 5.3.5](https://www.nuget.org/packages/NLog.Extensions.Logging/5.3.5)
```
    PS C:\ASPNET_Core_WebApi\bsStoreApp\Services> dotnet add package NLog.Extensions.Logging
```

<br/>
- Logs can be accessed from this directory :
```
    C:\ASPNET_Core_WebApi\bsStoreApp\WebApi\bin\Debug\net6.0\logs
```

### Migrations
- [Microsoft.EntityFrameworkCore.Tools 6.0.23](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools)
```
    PM> Install-Package Microsoft.EntityFrameworkCore.Tools -Version 6.0.23 -ProjectName WebApi
```
- [Microsoft.EntityFrameworkCore.Design 6.0.23](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design)
```
    PM> Install-Package Microsoft.EntityFrameworkCore.Design -Version 6.0.23 -ProjectName WebApi
```
<br/>

Use this commands for the `Migration Operations`:
- Create Migration
```
    PM> Add-Migration [MigrationName]
```
- Update Data   (Add Configurations)
```
    PM> Update-Database
```
- Remove Last Migration
```
    PM> Remove-Migration
```
- Drop the Database
```
    PM> Drop-Database
```

## Used Packages for PATCH Operation
- [Microsoft.AspNetCore.Mvc.NewtonsoftJson 6.0.23](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/7.0.12)
```
    PM>  NuGet\Install-Package Microsoft.AspNetCore.Mvc.NewtonsoftJson -Version 6.0.23 -ProjectName WebApi
```
- [Microsoft.AspNetCore.JsonPatch 6.0.23](https://www.nuget.org/packages/Microsoft.AspNetCore.JsonPatch)
```
    PM>  Install-Package Microsoft.AspNetCore.JsonPatch -Version 6.0.23 -ProjectName WebApi
```