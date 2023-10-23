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


### Migrations
- [Microsoft.EntityFrameworkCore.Tools 6.0.23](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools)
```
    PM> Install-Package Microsoft.EntityFrameworkCore.Tools -Version 6.0.23 -ProjectName WebApi
```
- [Microsoft.EntityFrameworkCore.Design 6.0.23](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design)
```
    PM> Install-Package Microsoft.EntityFrameworkCore.Design -Version 6.0.23 -ProjectName WebApi
```
- To add a Controller feature to a class -> [Microsoft.AspNetCore.Mvc.Core 2.2.5](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Core)
```
    PM> Install-Package Microsoft.AspNetCore.Mvc.Core -ProjectName Presentation
```

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
- Drop the database:
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