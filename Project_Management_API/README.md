# Project Management API

A complete RESTful API for managing users, projects, and tasks with **role-based access**, **JWT authentication**, and **Entity Framework Core** using **SQL Server LocalDB**.

---

## Features

- ✅ ASP.NET Core Web API
- ✅ JWT Authentication with token generation
- ✅ Role-based access (Admin, Project Manager, Developer, Viewer)
- ✅ Entity Framework Core + SQL Server LocalDB
- ✅ Auto database migration & user seeding
- ✅ Swagger for testing API endpoints

---

##  Technologies Used

- ASP.NET Core 6 / 7
- Entity Framework Core
- SQL Server LocalDB
- JWT (System.IdentityModel.Tokens.Jwt)
- BCrypt.Net for password hashing
- Swagger (Swashbuckle)

---

##  Getting Started

###  Prerequisites

- [.NET SDK 6 or 7](https://dotnet.microsoft.com/)
- Visual Studio 2022+ or VS Code
- SQL Server LocalDB (comes with Visual Studio)

###  Clone the Repository
bash
git clone https://github.com/Jayeshyadav10/Project_Management_API.git
- cd project-management-api
- dotnet run

---
###  Authorization (JWT)
- Use /api/auth/login to obtain a JWT token
- Copy the token from the response
- In Swagger, click the Authorize button
Paste your token: Bearer yourtoken
- You can now call secure endpoints.

---
### Enum Values Used
```Stored as integers in the database via EF Core.
public enum UserRole
{
    Admin,
    ProjectManager,
    Developer,
    Viewer
}
public enum ProjectStatus
{
    NotStarted,
    InProgress,
    Completed,
    OnHold
}
public enum TaskStatus
{
    NotStarted,
    InProgress,
    Completed,
    Blocked
}

