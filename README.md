# project-management-dotnet

## Structure
This solution is divided in five projects, inspired in the Domain Driven Design (DDD) of Premier repository:
* Domain (application layer for services)
* Entities (domain layer only for models classes)
* Repositories (infrastructure layer)
* Tests 
* Web (presentation layer)

## How to run this project?
### Tools you must have installed
* .NET Framework 4.8
* IIS (it's intalled by default in Windows but you need to activate)

### Recommended tools
* Visual Studio Community
  * Optional tools to enable while installing (Visual Studio Installer[PT-BR])
	* Ferramentas de desenvolvimento do .NET Framework 4.8
	* Ferramentas de nuvem para desenvolvimento para a Web
	* Ferramentas de criação de perfil do .NET
	* Ferramentas do Entity Framework 6
	* Modelos de projeto e item do .NET Framework
	* Ferramentas de desenvolvimento do .NET Framework 4.6.2 - 4.7.1
	* Modelos de projetos adicionais (versões anteriores)
	* Ferramentas de desenvolvimento do .NET Framework 4.8.1

# Opening the project in Visual Studio
Open the `.sln` file in this project with Visual Studio.
 
### Running the project
#### Before everything clean the solution:
* Right click at solution and `Clean Solution` 

#### Rebuild the solution:
* Right click at solution and `Rebuild Solution`

#### After this steps make sure that the startup project is `ProjectManagement.Web`:
* Right click at solution and enter in `Properties`
* In `Single startup project` combobox change to `ProjectManagement.Web`

#### You're now all set to execute the `Debugging` function, just hit `Ctrl+F5`
Now you can use the application as a REST API. 

The first request probably will take a long time because the application is trying to create the database in LocalDB and populating with tables.


