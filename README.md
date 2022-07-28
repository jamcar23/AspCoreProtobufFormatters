# AspCoreProtobufFormatters

![](https://github.com/jamcar23/AspCoreProtobufFormatters/workflows/Build/badge.svg)
![](https://github.com/jamcar23/AspCoreProtobufFormatters/workflows/Nuget%20Publish/badge.svg)

Custom ASP.NET Core Formatters to support reading and writing Protocol Buffers from / to a HTTP request / response.

## Installation

`Install-Package AspCoreProtobufFormatters -Version 1.0.0`

## Usage

Inside your normal `Startup.cs` file add the following at the top of the file:

`using AspCoreProtobufFormatters.Extensions;`

Then you can call `.AddProtobufFormatters()` on a `MvcOptions`.

Usually it would look something like this:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers(options => 
    {
        options.AddProtobufFormatters()
    });
}
```

Or:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc(options => 
    {
        options.AddProtobufFormatters()
    });
}
```

For more info on configuring services see [App startup in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup?view=aspnetcore-3.1).

From there you can use protobufs as an argument to your end point methods. Note: by default, the client must set the content type as 'application/x-protobuf', 'application/json' or 'application/x-protobuf-json' in order for these formatters to be used.

## Read more

[Custom formatters in ASP.NET Core Web API](https://docs.microsoft.com/en-us/aspnet/core/web-api/advanced/custom-formatters?view=aspnetcore-6.0)

## License

Copyright (c) 2020 James Carroll

The full license is available in the [license](./LICENSE.md) file.
