# 🍕 PizzaApp.API

A clean and modular **.NET Core Web API** for managing pizza orders and users. Built using **N-Tier Architecture**, **Clean Code principles**, and **best practices** like the **Repository Pattern**, **ASP.NET Identity**, and **AutoMapper**. The app is powered by **PostgreSQL** and designed for scalability and maintainability.

---

## 🚀 Overview

**PizzaApp.API** is a backend application that provides RESTful endpoints for user authentication, pizza management, and order handling.  
It follows a clean and layered architecture to ensure separation of concerns, easy testing, and future scalability.

The API supports:
- User registration and login (JWT-based authentication)
- Pizza and order creation, retrieval, and management
- Modular configuration using dependency injection
- Consistent API responses and error handling

---

## ⚙️ Features

- ✅ **Authentication & Authorization** – ASP.NET Core Identity with JWT tokens  
- ✅ **Repository Pattern** – clean data access layer  
- ✅ **AutoMapper** – simple mapping between entities and DTOs  
- ✅ **Custom Exception Handling** – meaningful, centralized error handling  
- ✅ **Base Controller** – unified API response format for all endpoints  
- ✅ **PostgreSQL Integration** – powered by Entity Framework Core (Npgsql)  
- ✅ **CORS Setup** – configured to work with Angular frontend  
- ✅ **Service Collection Extensions** – modular configuration for cleaner startup  

---

## 🧱 Technologies Used

| Category | Technology |
|-----------|-------------|
| **Framework** | ASP.NET Core (.NET 8) |
| **Database** | PostgreSQL |
| **ORM** | Entity Framework Core (Npgsql) |
| **Auth** | ASP.NET Identity + JWT |
| **Mapping** | AutoMapper |
| **Architecture** | N-Tier / Clean Architecture |

---

## 🛠️ Setup Instructions

### 1️⃣ Prerequisites
- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)

### 2️⃣ Clone the Repository
```bash
git clone https://github.com/Darko2504/PizzaApp.API.git
cd PizzaApp.API
