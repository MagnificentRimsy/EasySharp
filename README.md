# EasySharp
This library aims to provide an easy way in configuring and developing .netcore web api application.


   
Find the latest at: https://github.com/mkojoa/EasySharp

###### > EasySharp Library repository is work in progress.

## Get Started
`AddEasySharp()` & `UseEasySharp()` must be injected in `ConfigureServices` & `Configure` method in the `Startup` class respectively.
Basic Example

- ConfigureServices

   ```c#
   public void ConfigureServices(IServiceCollection services)
   {
       services
           .AddEasySharp();
   }
   ```

- Configure

   ```c#
   public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
   {
       if (env.IsDevelopment())
           app.UseDeveloperExceptionPage();
       app
           .UseEasySharp();
   }
   ```

## Features
- [x] [EasyDoc](#EasyDoc)
- [X] [InputTrimmer](#InputTrimmer)
- [X] [Cors](#Cors)
- [X] [ApiGenericMsg](#ApiGenericMsg)
- [X] [XXS](#XXS)
- [X] [CQRS](#CQRS)
- [X] [Validation](#Validation)
- [X] [EasyLog](#EasyLog)
- [X] [EfCore](#EfCore)
- [X] [Caching](#Caching)
- [~~Pagination~~](#Pagination)
- [~~Payment~~](#Payment)
- [~~HealthCheck~~](#HealthCheck)
      
#### EasyDoc
Easy Doc is used for API documentation.

`.AddDocs()` and `.UseDocs()` is used to include swagger in the application.
 Security option can be enable or disabled by passing `true` or `false` to IncludeSecurity property.
 
 ```yaml
"SwaggerOptions": {
    "enabled": true,
    "reDocEnabled": false,
    "name": "v1",
    "title": "Example Application",
    "version": ".Net Core 5.0 v1",
    "routePrefix": "docs",
    "Description": "Description here",
    "TermsOfService": "https://example.com/terms",
    "IncludeSecurity": true,
    "SecurityOptions": {
      "xmlDoc": true,
      "apiName": "exampleapi",
      "apiId": "examplecode",
      "tokenUrl": "http://example/AuthServer/connect/token",
      "authorityURL": "http://example/AuthServer/connect/authorize",
      "authority": "http://example/AuthServer",
      "clientSecret": "PeRstRe*$^",
      "issuerUri": "http://example/AuthServer",
      "requireHttpsMetadata": false,
      "Folder": "",
      "filterClassName": "AuthorizeCheckOperationFilter",
      "Contact": {
        "Name": "Michael Ameyaw",
        "Email": "example@gmail.com",
        "Url": "https://www.example.com"
      },
      "License": {
        "Name": "Example Systems Ltd",
        "Url": "http://www.example.com/"
      },
      "Scope": {
        "Name": "scopeapi",
        "Description": "The Scope needed to Access Example Api"
      }
    }
  },
```

#### InputTrimmer
Input Trimmer helps trim model object before saving to db. Available trimers supported :
 
 - InputTrim : Trim all leading and trailing spaces of a `string`
 - LowerTrim : Convert `strings` to lowercase using the casing rules.
 
 ```c#
 [HttpPost]
 [TrimInput]
 [LowerInput]
 public IActionResult CreateRecord([FromBody] Car model)
 { /* code here */ }
 ```
 
 #### Cors 
 Cross-Origin Resource Sharing  is an HTTP-header based mechanism that allows a server to indicate any other origins (domain, scheme, or port) than its own from which a browser should permit loading of resources.
 
 Appsettings for Cors looks like this
 
 ```yaml
 "CorsOptions": {
    "Enabled": true,
    "Name": "CorsPolicy",
    "Links": [
      "http://localhost:5000"
    ]
  }
 ```
- **Enabled** is optional and by default is false.
- **Name** is optional and by default the name is `EasySharp`.
- **Links** is only required if `Enabled` is true and must include uri schema, host and port of the resource server (eg. http://localhost:5000).

`AddCorsOption` is used in order to include it in your application.


#### ApiGenericMsg 
ApiGenericMsg present you with a default message template and better resopnse type.
And can easly be used in controllers by calling `ApiGenericMsg.OnEntityCreateSuccess<T>(dto, EntityName)`.

Available CRUD message template are  **OnEntityCreateSuccess** , **OnEntityCreateError**, **OnEntityDeleteSuccess**, **OnEntityDeleteError**, 
**OnEntityUpdateSuccess**, **OnEntityUpdateError** .. etc

```c#
 [HttpPost("CreateRecord")]
 public ApiGenericResponse<Car> CreateRecord([FromBody] Car dto) 
     => ApiGenericMsg.OnEntityCreateSuccess(dto, EntityName);
```
Response type from ApiGenericMessage becomes

```yaml
{
  "status": 0,
  "data": {
    "brand": "string",
    "model": "string",
    "year": 0
  },
  "message": "string"
}
```

#### XXS
By default XXS protection is set to `false`. You can enable it by adding the option below in your `app.settings.json` file.

```yaml
 "AntiXssOptions": {
    "Enabled": true
  }
```

#### CQRS
CQRS stands for “Command Query Responsibility Segregation”. As the acronym suggests, it’s all about splitting the responsibility of commands (saves) and queries (reads) into different models. Visit [https://martinfowler.com/bliki/CQRS.html] [CQRS Info] for more infomation

#### Validation
Validation becomes very helpful when there is a need to create/alter records in the database. Easysharp provides fluent validation wrapper & error handling that makes it easy to validate input models. Visit [https://docs.fluentvalidation.net/en/latest/start.html] for more validation rules

```c#
   public class CreateCar : AbstractValidator<CreateCarCommand>
    {
        public CreateCar()
        {
            RuleFor(cmd => cmd.Brand).NotEmpty().WithMessage("Please specify Brand");
            RuleFor(cmd => cmd.Model).NotEmpty().WithMessage("Please specify Model");
            RuleFor(cmd => cmd.Year).NotEmpty().WithMessage("Please specify Year");
        }
    }
```
You can refer to the `demo controller` for more details.

#### EasyLog
Easy Log is a logging provider with File Log and Seq Log options. See logging configuration below. `UseEasyLog()` must be used in Program.cs

By default File logging is set to `true`. 

```yaml
   "LoggerOptions": {
    "applicationName": "demo-service",
    "excludePaths": [ "/ping", "/metrics" ],
    "level": "information",
    "file": {
      "enabled": true,
      "path": "Logs/logs.txt",
      "interval": "day"
    },
    "seq": {
      "enabled": true,
      "url": "http://localhost:5341",
      "token": "secret"
    }
  }
```

#### EfCore
The only supported Database Driver is Efcore. To enable the driver add AddEfCore<YourOwnContext>() in the startup.cs class, and options below to your ap.settings.json.

```yaml
"EfCoreOptions": {
    "ConnectionString": "Server=DESKTOP-6BR1LOC;Initial Catalog=Db;user id=sa;password=Password"
},
```

#### Caching
Choice of caching is set when using AddCacheable() on the IServiceCollection. Supported caching drivers are
**Redis Caching**, **In-Memory Caching** and **File Storage Caching**.

Find the app.settings.json configurations below.

```yaml
"Cacheable": {
    "Redis": {
      "Enable": true,
      "Connection": "localhost:6379",
      "InstanceName": "RedisCacheTestDB"
    },
    "LocalStorage": {
      "Enable": true,
      "AutoLoad": true,
      "AutoSave": true,
      "EnableEncryption": true,
      "EncryptionSalt": "1e69e0a615e8cb813812ca797d75d4f08bdc2f56",
      "EncryptionKey": "password",
      "Folder": "wwwroot\\storage\\disk\\",
      "Filename": ".localstorage"
    }
  }
```

*  **Enable** Indicates which driver to use.
*  **AutoLoad** Load previously persisted state from disk when set to `true`
*  **AutoSave** Persist the latest state to disk when set to `true`
*  **EnableEncryption** Encrypt contents when persisting to disk.
*  **EncryptionSalt**
*  **EncryptionKey**
*  **Folder** Path to where the file should be stored and by default has, `wwwroot\\storage\\disk\\`
*  **Filename** The name of the file and by default, `.localstorage`.

 >Same Implenetation
 
```c#
    
    // Data from Database.
    var collection = EmployeeFactory.Create();

    var key = "storageKey";

    // Save to Memory only.
   _storage.StoreAsync(key, collection);

    // & Save to file.
   _storage.PersistAsync();
``` 
See DemoController for more examples.



