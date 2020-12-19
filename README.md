# EasySharp
This library aims to provide an easy way in configuring and developing .netcore web api application.

   [I've written a short Medium post about this repository](https://medium.com)
   
Find the latest at: https://github.com/mkojoa/EasySharp

###### > EasySharp Library repository is work in progress.

## Get Started
`AddEasySharp()` & `UseEasySharp()` must be injected in `ConfigureServices` & `Configure` method in the `Startup` class respectively.
Basic Example

- ConfigureServices

   ```
   public void ConfigureServices(IServiceCollection services)
   {
       services
           .AddEasySharp();
   }
   ```

- Configure

   ```
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
- [~~Logging~~](#Logging)
- [~~EfCore~~](#EfCore)
- [~~Caching~~](#Caching)
- [~~Consul~~](#Consul)
- [~~Pagination~~](#Pagination)
- [~~Payment~~](#Payment)
- [~~HealthCheck~~](#HealthCheck)
      
#### EasyDoc
Easy Doc is used for API documentation.

`.AddDocs()` and `.UseDocs()` is used to include swagger in the application.
 Security option can be enable or disabled by passing `true` or `false` to IncludeSecurity property.
 
 ```
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
 
 ```
 [HttpPost]
 [TrimInput]
 [LowerInput]
 public IActionResult CreateRecord([FromBody] Car model)
 { /* code here */ }
 ```
 
 #### Cors 
 Cross-Origin Resource Sharing  is an HTTP-header based mechanism that allows a server to indicate any other origins (domain, scheme, or port) than its own from which a browser should permit loading of resources.
 
 Appsettings for Cors looks like this
 
 ```
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

```
 [HttpPost("CreateRecord")]
 public ApiGenericResponse<Car> CreateRecord([FromBody] Car dto) 
     => ApiGenericMsg.OnEntityCreateSuccess(dto, EntityName);
```
Response type from ApiGenericMessage becomes

```
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

```
 "AntiXssOptions": {
    "Enabled": true
  }
```

#### CQRS
CQRS stands for “Command Query Responsibility Segregation”. As the acronym suggests, it’s all about splitting the responsibility of commands (saves) and queries (reads) into different models. Visit [https://martinfowler.com/bliki/CQRS.html] [CQRS Info] for more infomation

#### Validation
Validation becomes very helpful when there is a need to create / alter record in the database. Easysharp provides easy way to validate input models by extending fulent validator helper. see below the sample code.

```
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
