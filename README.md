# EasyCloud
Library Infrastuctures with Easy-Documentation, Cors, CQRS pattern support, easy swagger config etc..

   [I've written a short Medium post about this repository](https://medium.com)
   
Find the latest at: https://github.com/mkojoa/EasyCloud

###### > EasyCloud Library repository is work in progress.

## Features
- [x] [EasyDoc](#EasyDoc)
- [~~InputTrimer~~](#InputTrimer)
- [~~Cors~~](#Cors)
- [~~ApiGenericMsg~~](#ApiGenericMsg)
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
      "Folder": "", //"",
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
