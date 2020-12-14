# EasySharp
Library Infrastuctures with Easy-Documentation, Cors, CQRS pattern support, easy swagger config etc..

   [I've written a short Medium post about this repository](https://medium.com)
   
Find the latest at: https://github.com/mkojoa/EasySharp

###### > EasySharp Library repository is work in progress.

## Features
- [x] [EasyDoc](#EasyDoc)
- [X] [InputTrimmer](#InputTrimmer)
- [X] [Cors](#Cors)
- [X] [ApiGenericMsg](#ApiGenericMsg)
- [~~XXS~~](#XXS)
- [~~Pagination~~](#Pagination)
- [~~Payment~~](#Payment)
- [~~Caching~~](#Caching)
- [~~Consul~~](#Consul)
- [~~HelperUntilities~~](#HelperUntilities)
- [~~Logging~~](#Logging)
- [~~CQRS~~](#CQRS)
- [~~EfCore~~](#EfCore)
- [~~HealthCheck~~](#HealthCheck)
      
#### EasyDoc
Easy Doc is used for API documentation.

`.AddDocs(Configuration)` and `.UseDocs(Configuration)` is used to include swagger in the application.
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
 {
     // save to db & return
 }
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
Available CRUD message template,
 
 - OnEntityCreateSuccess
 - OnEntityCreateError
 - OnEntityDeleteSuccess
 - OnEntityDeleteError
 - OnEntityUpdateSuccess
 - OnEntityUpdateError .. etc
 

```
 [HttpPost]
 public ApiGenericResponse<Car> CreateRecord([FromBody] Car dto)
 {
     // save to db & return 
     return ApiGenericMsg.OnEntityCreateSuccess<Car>(dto, Entity);
  }
```
