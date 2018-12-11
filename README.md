# GoDaddyDotNet 
[![Build Status](https://travis-ci.org/bayological/GoDaddyDotNet.svg?branch=master)](https://travis-ci.org/bayological/GoDaddyDotNet)
[![nuget](https://img.shields.io/nuget/vpre/GoDaddyDotNet.svg)](https://www.nuget.org/packages/GoDaddyDotNet)

.Net Core GoDaddy Api Client Library

## Installation

Install the [GoDaddyDotNet NuGet Package](https://www.nuget.org/packages/GoDaddyDotNet).

### Package Manager Console

```
Install-Package GoDaddyDotNet -Version 1.0.2-alpha
```

### .NET Core CLI

```
dotnet add package GoDaddyDotNet --version 1.0.2-alpha
```
## Configuration
Add a configuration section called 'GoDaddySettings' to your configuration with the following keys:
* ApiUrl
* ApiKey
* ApiSecret

If you're using JSON configuration, your config file should look something like this:
```json
{
   "GoDaddySettings": {
      "ApiUrl": "https://api.godaddy.com/api/v1/",
      "ApiKey": "YOUR API KEY",
      "ApiSecret": "YOUR API SECRET"
   }
}
```

You can find the values for these on the [GoDaddy API documentation site](https://developer.godaddy.com/doc)

## Usage

The library adds the extension method `AddGoDaddyDotNet` to `IServiceCollection`. 
This will add the services required for GoDaddyDotNet

See **Examples** below for usage examples.

## Examples

```csharp
      var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
      var configuration = configBuilder.Build();
      var services = new ServiceCollection();
      services.AddGoDaddyDotNet(configuration);
      
      var sp = services.BuildServiceProvider();
      var client = sp.GetService<IGoDaddyClient>();
      
      var domain = await client.CheckDomainAsync("Google.com").ConfigureAwait(false);
```
 
