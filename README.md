🛍️ **E-Commerce Microservices Platform**

A distributed e-commerce backend system built with .NET 8, featuring a microservices architecture, Docker containerization, and modern development practices.

🚀 **Features**

- Microservices Architecture: Clean separation of concerns with API, Domain, and Infrastructure layers

- JWT Authentication: Secure user authentication and authorization

- Entity Framework Core: Database management with MySQL and automatic migrations

- Docker Containerization: Full containerization of API and database services

- Clean Architecture: Professional project structure following industry best practices

- RESTful API: Full CRUD operations with proper HTTP status codes and validation

- Swagger/OpenAPI: Interactive API documentation

🏗️ **Architecture**

    ECommerceMicroservices/
    ├── Catalog.API/          # Web API (Entry Point)
    ├── Catalog.Domain/       # Business Logic & Contracts
    ├── Catalog.Infrastructure/ # Data Access & Implementations
    └── docker-compose.yml    # Multi-container orchestration

🛠️ **Technology Stack**

- .NET 8 - Backend framework

- Entity Framework Core 8 - ORM and data access

- MySQL 8 - Database management

- Docker & Docker Compose - Containerization

- JWT Bearer Authentication - Secure authentication

- AutoMapper - Object-object mapping

- Swashbuckle - API documentation

- BCrypt.Net - Password hashing

**🚀 Getting Started**

**Prerequisites**

- .NET 8 SDK
- Docker Desktop
- Git

**Installation**

1. Clone the repository

```
bash
git clone https://github.com/your-username/ECommerceMicroservices.git
cd ECommerceMicroservices
```

2. Run with Docker Compose

```
bash
docker-compose up --build
```

3. Access the application

- API: http://localhost:5000

- Swagger UI: http://localhost:5000/swagger

- MySQL Database: localhost:3306

**Manual Development Setup**

1. Restore dependencies

```
bash
dotnet restore
```

2. Run database migrations

```
bash
cd src/Services/Catalog/Catalog.API
dotnet ef database update
```

3. Run the application

```
bash
dotnet run
```

📁 **Project Structure**

```
src/
├── Services/
│   └── Catalog/
│       ├── Catalog.API/                 # Web API Project
│       │   ├── Controllers/             # API Endpoints
│       │   ├── Dtos/                    # Data Transfer Objects
│       │   ├── Services/                # Application Services
│       │   └── Program.cs               # Startup Configuration
│       ├── Catalog.Domain/              # Domain Layer
│       │   ├── Entities/                # Business Entities
│       │   ├── Interfaces/              # Contracts & Abstractions
│       │   └── Features/                # Feature Organization
│       └── Catalog.Infrastructure/      # Infrastructure Layer
│           ├── Data/                    # Database Context
│           ├── Repositories/            # Data Access Implementations
│           ├── Services/                # Infrastructure Services
│           └── Migrations/              # Database Migrations
```

🔧 **API Endpoints**
**Authentication**

- `POST /api/auth/register` - User registration

- `POST /api/auth/login` - User login

**Products**

- `GET /api/products` - Get all products

- `GET /api/products/{id}` - Get product by ID

- `POST /api/products` - Create new product

- `PUT /api/products/{id}` - Update product

- `DELETE /api/products/{id}` - Delete product

🐳**Docker Configuration**

The project includes complete Docker support:

- Multi-container setup with API and MySQL database

- Dockerfile for optimized .NET 8 container builds

- docker-compose.yml for service orchestration

- Health checks and proper service dependencies

- Volume persistence for database data

🧪 **Testing**

Test the API using Swagger UI or curl commands:

```
bash
# Register a new user
curl -X POST http://localhost:5000/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{"email":"user@example.com","password":"Password123!"}'

# Login and get JWT token
curl -X POST http://localhost:5000/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"email":"user@example.com","password":"Password123!"}'
```

🚀 **Deployment**

The application is ready for deployment to:

- Docker Swarm

- Kubernetes

- Azure Container Instances

- AWS ECS

- Any Docker-supported platform

📈 **Development Journey**

This project demonstrates the complete development lifecycle:

1. Project Setup - Solution structure and clean architecture

2. Domain Modeling - Entities and business contracts

3. Data Access - Entity Framework Core with MySQL

4. API Development - RESTful endpoints with controllers

5. Authentication - JWT-based security implementation

6. Containerization - Docker setup for development and production

7. Documentation - Professional README and code comments

🤝 **Contributing**

1. Fork the repository

2. Create a feature branch (git checkout -b feature/amazing-feature)

3. Commit your changes (git commit -m 'Add some amazing feature')

4. Push to the branch (git push origin feature/amazing-feature)

5. Open a Pull Request
