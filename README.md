🏦 Atlantis Bank

A complete banking system built as a training project to master Layered Architecture and API Security Hardening.

---

📋 Table of Contents

· Overview
· Architecture
· Project Structure
· Features
· Security Layers
· Prerequisites
· Getting Started
· Database Setup
· API Endpoints
· Releases
· Tech Stack
· Documentation
· License

---

🎯 Overview

Atlantis Bank is a full-stack banking system with three clients sharing the same Business Logic Layer (BLL) and Data Access Layer (DAL):

Client Type Description
🖥️ Desktop App WinForms Full-featured desktop application
🌐 REST API ASP.NET Core 8 Production-ready API with 14 security layers
🖥️ Console Client Console Testing tool for the API

---

🏗️ Architecture

```
┌─────────────────────────────────────────────────────┐
│                   Presentation Layer                │
│  ┌──────────────┐  ┌──────────────┐  ┌───────────┐  │
│  │ Desktop App  │  │  REST API    │  │  Console  │  │
│  └──────────────┘  └──────────────┘  └───────────┘  │
└─────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────┐
│              Business Logic Layer (BLL)             │
│              AtlantisBank.BLL (Shared)              │
└─────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────┐
│              Data Access Layer (DAL)                │
│              AtlantisBank.DAL (Shared)              │
└─────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────┐
│                    SQL Server                       │
│                  AtlantisBankDB                     │
└─────────────────────────────────────────────────────┘
```

---

📁 Project Structure

```
Atlantis-Bank/
│
├── 📁 Atlantis Bank API/              ← 🌐 REST API (ASP.NET Core 8)
│   ├── Controllers/
│   ├── Authorization/
│   ├── DTOs/
│   ├── Mappers/
│   └── Program.cs
│
├── 📁 Atlantis Bank - Client Side/    ← 🖥️ Console Client
│   └── Program.cs
│
├── 📁 Atlantis Bank-BLL/              ← 📚 Business Logic Layer (Shared)
├── 📁 Atlantis Bank-DAL/              ← 💾 Data Access Layer (Shared)
│
├── 📁 Database/                       ← 💾 SQL Scripts
│   ├── Tables/
│   ├── StoredProcedures/
│   ├── SeedData/
│   └── Migrations/
│
├── 📁 Accounts/                       ← 🖥️ Desktop Forms
├── 📁 Client/                         ← 🖥️ Desktop Forms
├── 📁 Employee/                       ← 🖥️ Desktop Forms
├── 📁 Main/                           ← 🖥️ Desktop Forms
├── 📁 Transactions/                   ← 🖥️ Desktop Forms
├── 📁 User/                           ← 🖥️ Desktop Forms
├── 📁 Global/                         ← 🖥️ Desktop Utilities
├── 📁 Library/                        ← 🖥️ UI Libraries
├── 📁 Properties/                     ← 🖥️ Desktop Properties
├── 📁 Resources/                      ← 🖥️ Desktop Resources
│
├── 📄 Atlantis Bank.sln               ← Solution File
├── 📄 Atlantis Bank.csproj            ← Desktop Project
├── 📄 AGENTS.md                       ← Project Rules
├── 📄 README.md                       ← This File
└── 📄 .gitignore
```

---

✨ Features

🔐 Authentication & Authorization

· JWT-based authentication with Claims
· Refresh Tokens with Rotation & Revocation
· 21 Permission-based Policies
· Role hierarchy (Super Admin > Manager > Admin)
· Ownership Rules (Self-Edit without role escalation)

💼 Business Modules

· Client Management — CRUD operations
· Employee Management — CRUD + Positions
· User Management — CRUD + Role assignment
· Account Types — Account type configuration
· Accounts — Open, update, close, balance
· Transactions — Deposit, Withdrawal, Transfer, History
· Roles & Permissions — Role-based access control

🛡️ Security Features

· HTTPS / TLS enforcement
· CORS configuration
· Rate Limiting with obfuscation
· Structured Logging (all controllers)
· Secrets Management (Environment Variables)
· Error obfuscation (no information disclosure)

---

🔐 Security Layers

# Layer Description
1 HTTPS / TLS Encrypted communication
2 CORS Cross-origin request control
3 JWT Authentication Stateless token-based auth
4 Swagger Bearer Button Easy API testing
5 Refresh Tokens Rotation + Revocation
6 Logout Token revocation
7 Authorization Policies 21 permission-based policies
8 BLL Authorization AsyncLocal + Middleware
9 Ownership Rules Self-Edit + No Escalation
10 AddUser Restriction Prevent privilege escalation
11 Rate Limiting 5 req/min per IP + obfuscation
12 Structured Logging Full context logging
13 Secrets Management Environment Variables
14 Error Obfuscation No information disclosure

---

📦 Prerequisites

Before running this project, make sure you have:

· ✅ .NET 8 SDK (Download)
· ✅ SQL Server (2019 or later)
· ✅ Visual Studio 2022 (or JetBrains Rider)
· ✅ Git

For API: Environment Variables

The API requires 3 environment variables to be set:

Variable Value Description
Jwt__Key A secret key (32+ chars) JWT signing key
Jwt__Issuer AtlantisBankApi Token issuer
Jwt__Audience AtlantisBankClients Token audience

⚠️ Note: Use __ (double underscore) instead of : in environment variables.

---

🚀 Getting Started

1. Clone the Repository

```bash
git clone https://github.com/Abdallah-Hameed/Atlantis-Bank.git
cd Atlantis-Bank
```

2. Setup Database

See Database Setup below.

3. Set Environment Variables (API only)

Windows (PowerShell — Run as Admin):

```powershell
[System.Environment]::SetEnvironmentVariable('Jwt__Key', 'YOUR_SECRET_KEY_HERE', 'User')
[System.Environment]::SetEnvironmentVariable('Jwt__Issuer', 'AtlantisBankApi', 'User')
[System.Environment]::SetEnvironmentVariable('Jwt__Audience', 'AtlantisBankClients', 'User')
```

Then close and reopen Visual Studio.

4. Run the Project

Open Atlantis Bank.sln in Visual Studio:

Client Startup Project Action
🖥️ Desktop Atlantis Bank F5
🌐 API Atlantis Bank API F5 → Swagger opens
🖥️ Console Atlantis Bank - Client Side F5

---

🗄️ Database Setup

Option 1: Run Full Script (Recommended)

Execute Database/AtlantisBankDB.sql in SQL Server Management Studio (SSMS).

Option 2: Run Scripts Manually (in order)

```
1. Database/Tables/          ← Create tables
2. Database/StoredProcedures/ ← Create stored procedures
3. Database/SeedData/         ← Insert initial data (Roles, Permissions)
```

Connection String

Update the connection string in App.config (Desktop) or appsettings.json (API):

```xml
<connectionStrings>
  <add name="DefaultConnection" 
       connectionString="Server=.;Database=AtlantisBankDB;Integrated Security=true;TrustServerCertificate=true" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

---

🌐 API Endpoints

🔐 Authentication

Method Endpoint Policy Description
POST /api/Auth/login Anonymous Login
POST /api/Auth/refresh Anonymous Refresh token
POST /api/Auth/logout Anonymous Logout

👤 Users

Method Endpoint Policy Description
GET /api/User/All User_View List all users
GET /api/User/{id} User_View Get user by ID
POST /api/User/Add User_AddPolicy Add user
PUT /api/User/{id} User_EditOrSelf Update user
DELETE /api/User/{id} User_Delete Delete user
PUT /api/User/{id}/ChangePassword User_ChangePassword Change password

💼 Clients, Employees, Accounts, Transactions

Similar CRUD endpoints with permission-based policies.

📌 Full API documentation is available via Swagger at https://localhost:{PORT}/swagger

---

📦 Releases

Version Status Description
V2.0.0 ✅ Latest Full API + Desktop + Console
V1.0.0 📜 Legacy Desktop only

🎯 Which Version Should I Use?

Goal Download
🌐 Use the API V2.0.0
🖥️ Use the Desktop App V2.0.0
🔧 Develop Clone main branch

---

🛠️ Tech Stack

Backend

· ASP.NET Core 8 — REST API
· C# 12 — Language
· BCrypt.Net-Next — Password hashing
· JWT Bearer — Authentication

Database

· SQL Server — Database
· Stored Procedures — Data access
· Ado.Net (SqlDataReader) — No ORM

Desktop

· WinForms — UI Framework
· .NET Framework 4.7.2+

Tools

· Swagger / OpenAPI — API documentation
· Serilog (planned) — Structured logging

---

📚 Documentation

Document Description
AGENTS.md Project rules, conventions, and architecture
Database/README.md Database setup guide
Swagger UI Interactive API documentation

---

🧪 Testing

Manual Testing

1. Swagger UI — Test API endpoints interactively
2. Console Client — Run automated scenarios
3. Postman — Advanced API testing

Test Credentials

Username Role Notes
admin1 Admin (1) Basic admin
manager1 Manager (2) Mid-level
superadmin Super Admin (3) Full access

⚠️ Change passwords after first login!

---

🎓 Learning Outcomes

This project was built to master:

· ✅ 3-Tier Architecture (Presentation, BLL, DAL)
· ✅ JWT Authentication (Access + Refresh Tokens)
· ✅ Authorization (Policies, Ownership, Roles)
· ✅ API Security Hardening (14 layers)
· ✅ Structured Logging (ILogger with parameters)
· ✅ Secrets Management (Environment Variables)
· ✅ Git Workflow (Branching, Merging, Tags, Releases)

---

🤝 Contributing

This is a training project, so contributions are limited. However:

1. Fork the repository
2. Create a feature branch (git checkout -b feature/AmazingFeature)
3. Commit your changes (git commit -m 'Add some AmazingFeature')
4. Push to the branch (git push origin feature/AmazingFeature)
5. Open a Pull Request

---

📄 License

This project is for educational purposes only. Not intended for production use.

---

👤 Author

Abdallah Hameed

· GitHub: @Abdallah-Hameed
· Course: Programming Advices — Abu Hadhood

---

🙏 Acknowledgments

· Abu Hadhood — For the excellent course and guidance
· Programming Advices — For the structured learning path

---

<div align="center">

⭐ If you found this project helpful, please give it a star! ⭐

Built with ❤️ as a training project to master layered architecture + API security.

</div>

---
