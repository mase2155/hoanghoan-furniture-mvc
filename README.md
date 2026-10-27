# 🪑 Hoang Hoan Furniture Web Application

> "Harmonizing customer ideas and wishes to bring wonderful relaxing moments with family."

---

## 1.Overview
**Hoang Hoan Furniture** is an e-commerce and store management web application built for a furniture workshop. 
The project helps customers search for products, view details, and send consultation requests. It also helps administrators manage product catalogs, blog posts, and contact requests efficiently.

---

## 2.Tech Stack
* **Backend:** ASP.NET Core 8 MVC, Entity Framework Core 8, ASP.NET Core Identity.
* **Frontend:** HTML5, CSS3, Bootstrap 5, JavaScript (ES6+), jQuery.
* **Database:** Microsoft SQL Server.

---

## 3. System Architecture
The project follows the **MVC (Model-View-Controller)** pattern with a clean structure:

* `Models/`: Defines Database Entities and ViewModels for passing data to Views.
* `Views/`: Razor pages (`.cshtml`) for rendering user and admin interfaces.
* `Controllers/`: Receives client requests, calls Services, and returns Views.
* `Services/`: Contains business logic (WebP image handling, email sending, caching).
* `Data/`: Manages database connections (`DbContext`), Migrations, and Seed Data.
* `Areas/Admin/`: Isolated workspace and features reserved for system administrators.

---

## 4. User Roles & Features

### 👤 Customer Role
* **Home Page:** View banners, featured categories, and latest news.
* **Browse Products:** View product list, filter by price/category, and view variant details (material, size).
* **Send Requests:** Fill out contact/quote request forms directly sent to the workshop.

### 🛠️ Admin Role
* **Product Management:** Add, edit, hide/delete categories, products, variants, and upload multiple images.
* **Content Management:** Create blog posts, edit home page banners, and update static content blocks.
* **Inquiry Management:** View and update status for customer consultation requests (`New` -> `InProgress` -> `Done`).

---

## 5. Setup & Run Instructions

### Prerequisites
* .NET 8 SDK
* SQL Server / SSMS
* Visual Studio 2022

### Step-by-Step Guide
1. **Clone the repository:**
   ```bash
   git clone [https://github.com/hungld/hoanghoan-furniture-aspnet.git](https://github.com/hungld/hoanghoan-furniture-aspnet.git)
   cd hoanghoan-furniture-aspnet
   ``` 
2. Configure Database

In `appsettings.json` file:

Update your SQL Server connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=HoangHoanDb;Trusted_Connection=True;TrustServerCertificate=True" }
  ```

3. Apply Migrations & Seed Data

In Visual Studio Package Manager Console:

```
    update-database
```

Or using .NET CLI:

```
    dotnet ef database update
```

In root folder: 

```
    dotnet run
``` 

``` 
        [INFO] Starting ASP.NET Core web server...
    [SUCCESS] Application is running at: https://localhost:7001

    You can check out the website at https://localhost:7001 in your browser now.

    Build for deployment

```

In root folder:

```
    dotnet publish -c Release -o ./publish
```