# ASP.NET Core Web API - Quick Start Guide

This guide provides a quick overview of setting up a basic ASP.NET Core Web API project.

## Table of Contents

* [📌 Visual Studio 2022 Settings](#-visual-studio-2022-settings)
* [🗄️ SQL Server Object Explorer](#️-sql-server-object-explorer)
* [📦 Installing Packages (Package Manager Console)](#-installing-packages-package-manager-console)
* [⚙️ appsettings.json Configuration](#️-appsettingsjson-configuration)
* [📝 Program.cs Settings](#-programcs-settings)
* [🎛️ Creating a Controller](#️-creating-a-controller)
* [🔓 Enabling CORS (Program.cs)](#-enabling-cors-programcs)

## 📌 Visual Studio 2022 Settings

When creating a new project in Visual Studio 2022, ensure the following settings are configured:

* **Project Template:** ASP.NET Core Web API
* **Place solution and project in the same directory:** Check this option.
* **Framework:** .NET 8.0
* **Configure for HTTPS:** Check this option.
* **Enable OpenAPI support (Swagger):** Check this option.
* **Use controllers (MVC):** Ensure this is the selected option.

## 🗄️ SQL Server Object Explorer

To create the database, you can use the SQL Server Object Explorer.

* **Add New Query:** Open a new query window connected to your SQL Server instance.
* **Execute the following SQL command to create your database:**

    ```sql
    CREATE DATABASE YourDatabaseName;
    ```
* You can convert sql codes to different languages <a href='https://www.sqlines.com/mysql-to-sql-server' target='_blank'>here</a>

## 📦 Installing Packages (Package Manager Console)

Open the Package Manager Console in Visual Studio and run the following commands to install the necessary Entity Framework Core packages:

```powershell
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.Tools
```

To generate the database context and model classes from your existing database, use the following command. Remember to replace the placeholders with your actual connection string, context name, and model output directory.

```powershell
Scaffold-DbContext "_YourConnectionString_" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context _YourDbContext_ -DataAnnotations
```

## ⚙️ appsettings.json Configuration

Configure your database connection string in the ``appsettings.json`` file:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "_YourConnectionString_"
  }
}
```

Replace ``_YourConnectionString_`` with your actual SQL Server connection string.

## 📝 Program.cs Settings

Add the database connection to your application's services in the ``Program.cs`` file:

```c#
var builder = WebApplication.CreateBuilder(args);

// ... other service configurations ...

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");
builder.Services
    .AddDbContext<_YourDbContext_>
    (opt => opt.UseSqlServer(connectionString));

// ... rest of the Program.cs ...
```

## 🎛️ Creating a Controller

When creating a new controller:

* Model Class: _YourModel_ (Replace with the name of your model class)
* DbContext Class: _YourDbContext_ (Replace with the name of your DbContext class)
* Controller Name: _YourModel_sController (By default, it's the pluralized form of your model name)

## 🔓 Enabling CORS (Program.cs)

To enable Cross-Origin Resource Sharing (CORS) for development purposes, add the following code to your Program.cs file:
```C#
var builder = WebApplication.CreateBuilder(args);

// ... other service configurations ...

builder.Services.AddCors(
    options => options.AddDefaultPolicy(
        builder => builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()));

var app = builder.Build();

// This must be added before app.UseHttpsRedirection();
app.UseCors();

app.UseHttpsRedirection();

// ... rest of the app pipeline ...
app.Run();
```

> [!NOTE] 
> Allowing AnyOrigin, AnyHeader, and AnyMethod is generally not recommended for production environments due to security implications. You should configure CORS with specific origins, headers, and methods as needed for your application.
