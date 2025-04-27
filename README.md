# Library-Management-API

This is a simple ASP.NET Core Web API for managing Authors and Books, built with Entity Framework Core (Code-First). It supports full CRUD operations, validation, and error handling for invalid operations.

🔗 Host & Swagger

Swagger UI: http://localhost:5163/swagger/index.html

📋 Prerequisites

.NET 7.0 SDK

SQL Server LocalDB (installed with Visual Studio) or any SQL Server instance

Optional: Postman or curl for testing

🚀 Setup & Run

Clone the repository

git clone <repository-url>
cd LibraryManagementAPI

Configure Connection String
Edit appsettings.json:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LibraryDB;Trusted_Connection=True;"
  },
  "Logging": { ... }
}

Install EF Global Tool (if not already installed)

dotnet tool install --global dotnet-ef --version 7.0.13

Create & Apply Migrations

dotnet ef migrations add InitialCreate
dotnet ef database update

Build & Run

dotnet build
dotnet run

The API will start listening on http://localhost:5163 (and HTTPS if configured).

📦 Project Structure

LibraryManagementAPI/

├── Controllers/         # API controllers for Authors & Books

├── Data/                # EF Core DbContext & factory

├── Models/              # Entity classes: Author, Book

├── Migrations/          # EF Core code-first migrations

├── appsettings.json     # Configuration & connection strings

├── Program.cs           # Application startup & DI setup

├── README.md            # This documentation

└── LibraryManagementAPI.csproj

📖 API Endpoints

Authors

Method	    Route    	Açıklama

GET,	/api/authors,	Tüm yazarları listeler

GET,	/api/authors/{id},	{id} ile belirtilen yazarı getirir

POST,	/api/authors,	Yeni bir yazar oluşturur

PUT,	/api/authors/{id},	{id}’li yazarı günceller

DELETE,	/api/authors/{id},	{id}’li yazarı siler (kitabı varsa hata döner)


Books

Method    	Route    	Açıklama

GET,	/api/books,	Tüm kitapları listeler

GET,	/api/books/{id},	{id} ile belirtilen kitabı getirir

POST,	/api/books,	Yeni bir kitap oluşturur

PUT,	/api/books/{id},	{id}’li kitabı günceller

DELETE,	/api/books/{id},	{id}’li kitabı siler
