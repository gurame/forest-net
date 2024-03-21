infra-up:
	docker-compose up -d
infra-down:
	docker-compose down

books-db-migration-add:
	dotnet ef migrations add Initial -c BooksDbContext --project EagleBooks.Books/EagleBooks.Books.csproj --startup-project EagleBooks.Web/EagleBooks.Web.csproj -o Data/Migrations
books-db-migration-zero:
	-if [ -d "EagleBooks.Books/Data/Migrations" ]; then rm -r EagleBooks.Books/Data/Migrations; fi
	dotnet ef migrations add Initial -c BooksDbContext --project EagleBooks.Books/EagleBooks.Books.csproj --startup-project EagleBooks.Web/EagleBooks.Web.csproj -o Data/Migrations
books-db-migration-update:
	dotnet ef database update -c BooksDbContext --project EagleBooks.Books/EagleBooks.Books.csproj --startup-project EagleBooks.Web/EagleBooks.Web.csproj

users-db-migration-add:
	dotnet ef migrations add Initial -c UsersDbContext --project EagleBooks.Users/EagleBooks.Users.csproj --startup-project EagleBooks.Web/EagleBooks.Web.csproj -o Infrastructure/Data/Migrations
users-db-migration-zero:
	-if [ -d "EagleBooks.Users/Infrastructure/Data/Migrations" ]; then rm -r EagleBooks.Users/Infrastructure/Data/Migrations; fi
	dotnet ef migrations add Initial -c UsersDbContext --project EagleBooks.Users/EagleBooks.Users.csproj --startup-project EagleBooks.Web/EagleBooks.Web.csproj -o Infrastructure/Data/Migrations
users-db-migration-update:
	dotnet ef database update -c UsersDbContext --project EagleBooks.Users/EagleBooks.Users.csproj --startup-project EagleBooks.Web/EagleBooks.Web.csproj

order-db-migration-add:
	dotnet ef migrations add Initial -c OrderProcessingDbContext --project EagleBooks.OrderProcessing/EagleBooks.OrderProcessing.csproj --startup-project EagleBooks.Web/EagleBooks.Web.csproj -o Infrastructure/Data/Migrations
order-db-migration-zero:
	-if [ -d "EagleBooks.OrderProcessing/Infrastructure/Data/Migrations" ]; then rm -r EagleBooks.OrderProcessing/Infrastructure/Data/Migrations; fi
	dotnet ef migrations add Initial -c OrderProcessingDbContext --project EagleBooks.OrderProcessing/EagleBooks.OrderProcessing.csproj --startup-project EagleBooks.Web/EagleBooks.Web.csproj -o Infrastructure/Data/Migrations
order-db-migration-update:
	dotnet ef database update -c OrderProcessingDbContext --project EagleBooks.OrderProcessing/EagleBooks.OrderProcessing.csproj --startup-project EagleBooks.Web/EagleBooks.Web.csproj