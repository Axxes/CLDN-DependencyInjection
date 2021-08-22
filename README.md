

# Dependency injection: Cheat Sheet

## .NET APP Model

| Name | Description |
|--|--|
| .NET Full Framework | Replaced by .NET 5/6. Windows only. Supports WCF & WPF fully. |
| .NET Core | Replaced by .NET 5/6. Cross platform. No support for WCF (server). WPF supported as of 3.0 (Windows only). |
| .NET Standard | Shared feature set of .NET FF and .NET Core. Libraries written in .NET Standard can be used in both frameworks. Will be replaced by .NET 5/6. |

## DI Libraries

### ASP.NET Core Dependency Injection

Used by default for ASP.NET Core.

| Name | Description | Command |
|--|--|--|
| Transient | New instance on every inject | services.AddTransient\<T, U>() |
| Scoped | New instance / scope (in ASP = new instance / request) | services.AddScoped\<T, U>() |
| Singleton | One instance over the whole application (be careful, must be thread safe) | services.AddSingleton\<T, U>()

### Autofac
More features but a bit slower. Very commonly used as well.

| Name | Description | Command |
|--|--|--|
| Transient | New instance on every inject | builder.RegisterType\<T>().As\<U>() |
| Scoped | New instance / scope (in ASP = new instance / request) | builder.RegisterType\<T>().As\<U>().InstancePerLifetimeScope() |
| Singleton | One instance over the whole application (be careful, must be thread safe) | builder.RegisterType\<T>().As\<U>().SingleInstance()

