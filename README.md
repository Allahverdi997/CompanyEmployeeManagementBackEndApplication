# Department and Employee Back-End Proyekt


## Features

- Department adding operation
- Department update operation
- Department delete operation
- Get Departments 
- Get Department details
- Get Departments with pagination
- Employee adding operation
- Employee update operation
- Employee delete operation
- Get Employees
- Get Employee details
- Get Employee with pagination
- Get Employees with department

About Project

> This project contains department,employee crud operations and department and employee relational operations. Project coded Onion Architecture and contains 5 base layer and one other (for JWT) service layer.

## Note
Some actions require a token (Department add, update, delete and Employee add, update, delete), which you can get with the username-admin password-admin123 profile formed after migration to the getLogin endpoint in the User controller.

## Tech

Uses in project:

- [Entity Framework] - Version: 
- [Ace Editor] - awesome web-based text editor
- [markdown-it] - Markdown parser done right. Fast and easy to extend.
- [Twitter Bootstrap] - great UI boilerplate for modern web apps
- [node.js] - evented I/O for the backend
- [Express] - fast node.js network app framework [@tjholowaychuk]
- [Gulp] - the streaming build system
- [Breakdance](https://breakdance.github.io/breakdance/) - HTML
to Markdown converter
- [jQuery] - duh

And of course Dillinger itself is open source with a [public repository][dill]
 on GitHub.

## Installation

Project:

```sh
dotnet restore
dotnet build
dotnet run
```

Database:

First select the Persistance Layer in Package Manager Console
```sh
initial-migration MiInit
update-database
```

When the database is established, the data will be filled in the Exceptions and Users table.

## Technologies

The following were used in the project

|  |  |
| ------ | ------ |
| Autofac | For Dependency Injection |
| AOP | For Aspects (Aspects Oriented Programming) |
| OOP| Object Oriented Programming |
| DDD | Domain Driven Design |
| DP  | Some Design Patterns |
| FLuent Validation | For Validation |
| AutoMapper | For Mapping Processes |
| Mediatr | MediatR |
| Entity Framework | ORM |
| Castle | For Aspect Oriented Programming |
| Serilog | For Logging |
| Swagger | For API Documentation |
| Json Web Token(JWT) | For Authentication |

**Goog Luck!**

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)

   [dill]: <https://github.com/joemccann/dillinger>
   [git-repo-url]: <https://github.com/joemccann/dillinger.git>
   [john gruber]: <http://daringfireball.net>
   [df1]: <http://daringfireball.net/projects/markdown/>
   [markdown-it]: <https://github.com/markdown-it/markdown-it>
   [Ace Editor]: <http://ace.ajax.org>
   [node.js]: <http://nodejs.org>
   [Twitter Bootstrap]: <http://twitter.github.com/bootstrap/>
   [jQuery]: <http://jquery.com>
   [@tjholowaychuk]: <http://twitter.com/tjholowaychuk>
   [express]: <http://expressjs.com>
   [AngularJS]: <http://angularjs.org>
   [Gulp]: <http://gulpjs.com>

   [PlDb]: <https://github.com/joemccann/dillinger/tree/master/plugins/dropbox/README.md>
   [PlGh]: <https://github.com/joemccann/dillinger/tree/master/plugins/github/README.md>
   [PlGd]: <https://github.com/joemccann/dillinger/tree/master/plugins/googledrive/README.md>
   [PlOd]: <https://github.com/joemccann/dillinger/tree/master/plugins/onedrive/README.md>
   [PlMe]: <https://github.com/joemccann/dillinger/tree/master/plugins/medium/README.md>
   [PlGa]: <https://github.com/RahulHP/dillinger/blob/master/plugins/googleanalytics/README.md>

