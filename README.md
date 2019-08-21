
# Dependency injection

## Cheat sheet

### ASP.NET Core

#### Lifetimes

| Name | Description | Command |
|--|--|--|
| Transient | New instance on every inject | services.AddTransient\<T, U>() |
| Scoped | New instance / scope (in ASP = new instance / request) | services.AddScoped\<T, U>() |
| Singleton | One instance over the whole application (be careful, must be thread safe) | services.AddSingleton\<T, U>()

### Autofac

| Name | Description | Command |
|--|--|--|
| Transient | New instance on every inject | builder.RegisterType\<T>().As\<U>() |
| Scoped | New instance / scope (in ASP = new instance / request) | builder.RegisterType\<T>().As\<U>().InstancePerLifetimeScope() |
| Singleton | One instance over the whole application (be careful, must be thread safe) | builder.RegisterType\<T>().As\<U>().SingleInstance()

