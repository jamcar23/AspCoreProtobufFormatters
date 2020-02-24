# AspCoreProtobufFormatters
Custom ASP.NET Core Formatters to support reading and writing Protocol Buffers from / to a HTTP request / response.

## Installation

*todo publish to nuget*

## Usage
Inside your normal `Startup.cs` file add the following at the top of the file:

`using AspCoreProtobufFormatters.Extensions;`

Then you can call `.AddProtobufFormatters()` on a `MvcOptions`.

Usually it would look something like this:

```
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers(options => 
    {
        options.AddProtobufFormatters()
    });
}
```

Or: 

```
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc(options => 
    {
        options.AddProtobufFormatters()
    });
}
```

For more info on configuring services see [App startup in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup?view=aspnetcore-3.1).

From there you can use protobufs as an argument to your end point methods. Note: by default, the client must set the content type as 'application/x-protobuf' in order for these formatters to be used.

## License

Copyright (c) 2020 James Carroll

The full license is available in the [license](./LICENSE.md) file.