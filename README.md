# MVC Master-Details CRUD

A master-details CRUD web application built with **ASP.NET MVC 5**, **Entity Framework 6 (Code First)** and **jQuery Ajax**. It manages library members (master) together with their borrowed items (details), with seamless no-page-reload updates.

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.x-512BD4)
![ASP.NET MVC](https://img.shields.io/badge/ASP.NET%20MVC-5-blue)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-6-green)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927)

---

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Architecture](#architecture)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [What I Learned](#what-i-learned)
- [Roadmap](#roadmap)
- [Author](#author)

---

## Overview

This project demonstrates the **master-details pattern** in ASP.NET MVC 5. A single page lets the user create or edit a master record and its related detail rows together, using jQuery Ajax so the page never fully reloads. Data access is handled by Entity Framework 6 with Code First migrations for schema versioning.

It was built as part of my project-based training in the **IsDB-BISEW IT Scholarship Programme** (Cross-Platform Apps Using ASP.NET, Angular, React & MAUI).

## Features

- Create, read, update and delete (CRUD) master records
- Add, edit and remove related detail rows on the same screen
- Unobtrusive jQuery Ajax for no-reload updates
- Responsive UI built with Bootstrap
- Entity Framework 6 Code First with migrations
- One-to-many relationship between master and detail tables

## Tech Stack

| Layer      | Technology                         |
| ---------- | ---------------------------------- |
| Framework  | ASP.NET MVC 5 (.NET Framework)     |
| Language   | C#                                 |
| ORM        | Entity Framework 6 (Code First)    |
| Database   | MS SQL Server                      |
| Front end  | Razor Views, jQuery / Ajax, Bootstrap |
| IDE        | Visual Studio 2022                 |

## Architecture

```
Browser (Razor View + jQuery Ajax)
        |
   MVC Controller
        |
 Entity Framework 6 (DbContext)
        |
    SQL Server
```

## Getting Started

### Prerequisites

- Visual Studio 2022 (with the **ASP.NET and web development** workload)
- .NET Framework 4.x Developer Pack
- SQL Server or SQL Server LocalDB

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/fahad614377/MVC-Master-details-CRUD.git
   ```
2. **Open the solution**
   Open `MVCAjax.sln` in Visual Studio.
3. **Restore NuGet packages**
   Right-click the solution and choose **Restore NuGet Packages** (or build the solution).
4. **Configure the connection string**
   Update the connection string in `Web.config` to point to your SQL Server instance.
5. **Create the database**
   Open **Package Manager Console** and run:
   ```powershell
   Update-Database
   ```
6. **Run the application**
   Press `F5` or click **Start**.

## Project Structure

```
MVCAjax.sln
└── MVC-master-details/
    ├── Controllers/      # MVC controllers (CRUD actions)
    ├── Models/           # Entity classes and DbContext
    ├── Migrations/       # EF6 Code First migrations
    ├── Views/            # Razor views and partial views
    ├── Scripts/          # jQuery and Ajax scripts
    └── Web.config
```



## What I Learned

- Implementing the master-details pattern with Entity Framework relationships
- Updating the UI with jQuery Ajax without full page reloads
- Managing schema changes with Code First migrations
- Structuring an application with the MVC pattern

## Roadmap

- [ ] Server-side and client-side validation improvements
- [ ] Search, sorting and pagination
- [ ] Authentication and role-based authorization
- [ ] Migration to ASP.NET Core

## Author

**Tawhidur Rahman**
Junior Full-Stack .NET Developer

- GitHub: [@fahad614377](https://github.com/fahad614377)
- Email: tawhidurrahman42@gmail.com
