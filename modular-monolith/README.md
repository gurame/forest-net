# Microservices challenges
- Network latency
- Message serialization
- Inter-service communication
- Data consistency

### Incremental design approach
Monolith is gradually broken into microservices. <br/>
A common pitfall is ending up what is often termed as a distributed monolith.
This happens when services are so tightly coupled in terms of functionality and
communication that they lose the benefits of being independent

### Comparison
| Trade-offs  | Layered | Microservices | Modular Monolith |
|:------------|:-------:|:-------------:|:----------------:|
| Modularity  |    ❌    |      ✔️️      |       ✔️️        |
| Cost        |    $    |      $$$      |        $         |
| Scalability |    ❌    |      ✔️️      |        ❌         |
| Simplicity  |   ✔️    |       ❌       |       ✔️️        |

### Install global tools
```zsh
dotnet tool install -g dotnet-ef
dotnet tool install -g dotnet-format
```
### include dotnet global tools path in PATH
```zsh
echo -n 'export PATH=$PATH:$HOME/.dotnet/tools' >> ~/.zshrc
```
## Create project
create the solution
```zsh
dotnet new sln -n EagleBooks
```
create src directory
```zsh
mkdir src
``` 
create web api project
```zsh
dotnet new webapi -n API -o src
```
add web api project to solution
```zsh
dotnet sln RiverBooks.sln add ./src/API/API.csproj
```
create library project
```zsh
dotnet new classlib -n Books -o src/Books
```
add library project to solution
```zsh
dotnet sln RiverBooks.sln add ./src/Books/Books.csproj
```
add library project as reference to web api project
```zsh
dotnet add src/API/API.csproj reference src/Books/Books.csproj
```
add framework reference to library project
```
<ItemGroup>
<FrameworkReference Include="Microsoft.AspNetCore.App" />
</ItemGroup>
```
add FastEndpoints to projects
```zsh
dotnet add src/API/API.csproj package FastEndpoints
dotnet add src/Books/Books.csproj package FastEndpoints
```
add Ardalis.GuardClauses to project Books
```zsh
dotnet add src/Books/Books.csproj package Ardalis.GuardClauses
```
add Microsoft.EntityFrameworkCore to project Books
```zsh
dotnet add src/Books/Books.csproj package Microsoft.EntityFrameworkCore
```
add Microsoft.EntityFrameworkCore.SqlServer to project Books
```zsh
dotnet add src/Books/Books.csproj package Microsoft.EntityFrameworkCore.SqlServer
```
add Microsoft.EntityFrameworkCore.Design to project API
```zsh
dotnet add src/API/API.csproj package Microsoft.EntityFrameworkCore.Design
```
add migration
```zsh
dotnet ef migrations add Initial -c BooksDbContext --project src/Books/Books.csproj --startup-project src/API/API.csproj -o Data/Migrations
```
apply migration
```zsh
dotnet ef database update -c BooksDbContext --project src/Books/Books.csproj --startup-project src/API/API.csproj
```
add packages for testing
```bash
dotnet add tests/Books.Tests/Books.Tests.csproj package FluentAssertions
dotnet add tests/Books.Tests/Books.Tests.csproj package FastEndpoints.Testing
```
add API project as reference to test project
```zsh
dotnet add tests/Books.Tests/Books.Tests.csproj reference src/API/API.csproj
```
apply migration for testing
```zsh
dotnet ef database update -c BooksDbContext --project src/Books/Books.csproj --startup-project src/API/API.csproj -- --environment Testing
```
add migration for User Module
```zsh
dotnet ef migrations add Initial -c UsersDbContext --project src/Users/Users.csproj --startup-project src/API/API.csproj -o Data/Migrations
```
##
apply migration for User Module
```zsh
dotnet ef database update -c UsersDbContext --project src/Users/Users.csproj --startup-project src/API/API.csproj
```
##
add migration for CarItem in User Module
```zsh
dotnet ef migrations add CartItem -c UsersDbContext --project src/Users/Users.csproj --startup-project src/API/API.csproj -o Data/Migrations
```
##
apply migration for User Module
```zsh
dotnet ef database update -c UsersDbContext --project src/Users/Users.csproj --startup-project src/API/API.csproj
```
## 