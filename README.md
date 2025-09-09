🛍️ E-Commerce Microservices Platform
A distributed e-commerce backend system built with .NET 8, featuring a microservices architecture, Docker containerization, and modern development practices.

✨ Features
*🔧 Microservices Architecture - Clean separation with API, Domain, and Infrastructure layers

*🔐 JWT Authentication - Secure user authentication and authorization system

🗄️ Entity Framework Core - Database management with MySQL and automatic migrations

🐳 Docker Containerization - Full containerization of API and database services

🏗️ Clean Architecture - Professional project structure following industry best practices

🌐 RESTful API - Full CRUD operations with proper HTTP status codes and validation

📖 Swagger/OpenAPI - Interactive API documentation

🏗️ Architecture
text
ECommerceMicroservices/
├── Catalog.API/ # Web API (Entry Point)
├── Catalog.Domain/ # Business Logic & Contracts
├── Catalog.Infrastructure/ # Data Access & Implementations
└── docker-compose.yml # Multi-container orchestration
🛠️ Tech Stack
Technology Purpose
.NET 8 Backend framework
Entity Framework Core 8 ORM and data access
MySQL 8 Relational database
Docker & Docker Compose Containerization
JWT Bearer Authentication Secure authentication
AutoMapper Object-object mapping
Swashbuckle API documentation
BCrypt.Net Password hashing
🚀 Quick Start
Prerequisites
.NET 8 SDK

Docker Desktop

Git

Running with Docker
bash

# Clone and run

git clone https://github.com/your-username/ECommerceMicroservices.git
cd ECommerceMicroservices
docker-compose up --build
Access Points
API: http://localhost:5000

📖 Swagger UI: http://localhost:5000/swagger

🗄️ MySQL Database: localhost:3306

📁 Project Structure
text
src/
└── Services/
└── Catalog/
├── Catalog.API/ # Web API Layer
│ ├── Controllers/ # API Endpoints
│ ├── Dtos/ # Data Transfer Objects
│ ├── Services/ # Application Services
│ └── Program.cs # Startup Configuration
├── Catalog.Domain/ # Domain Layer
│ ├── Entities/ # Business Entities
│ ├── Interfaces/ # Contracts & Abstractions
│ └── Features/ # Feature Organization
└── Catalog.Infrastructure/ # Infrastructure Layer
├── Data/ # Database Context
├── Repositories/ # Data Access Implementations
├── Services/ # Infrastructure Services
└── Migrations/ # Database Migrations
📡 API Endpoints
🔐 Authentication
Method Endpoint Description
POST /api/auth/register User registration
POST /api/auth/login User login
📦 Products Management
Method Endpoint Description
GET /api/products Get all products
GET /api/products/{id} Get product by ID
POST /api/products Create new product
PUT /api/products/{id} Update product
DELETE /api/products/{id} Delete product
🐳 Docker Setup
The project includes complete Docker support:

Multi-container setup with API and MySQL database

Optimized Dockerfile for .NET 8 applications

docker-compose.yml for service orchestration

Health checks and service dependencies

Volume persistence for database data

🧪 Testing Examples
bash

# Register a new user

curl -X POST http://localhost:5000/api/auth/register \
 -H "Content-Type: application/json" \
 -d '{"email":"user@example.com","password":"Password123!"}'

# Login and get JWT token

curl -X POST http://localhost:5000/api/auth/login \
 -H "Content-Type: application/json" \
 -d '{"email":"user@example.com","password":"Password123!"}'
🚀 Deployment Ready
The application is prepared for deployment to:

Kubernetes

Docker Swarm

Azure Container Instances

AWS ECS

Any Docker-supported platform

📈 Development Journey
This project showcases a complete development lifecycle:

🎯 Project Setup - Solution structure and clean architecture

📊 Domain Modeling - Entities and business contracts

💾 Data Access - Entity Framework Core with MySQL

🌐 API Development - RESTful endpoints with controllers

🔐 Authentication - JWT-based security implementation

🐳 Containerization - Docker setup for development and production

📚 Documentation - Professional README and code comments

🤝 Contributing
Fork the repository

Create a feature branch (git checkout -b feature/amazing-feature)

Commit your changes (git commit -m 'Add some amazing feature')

Push to the branch (git push origin feature/amazing-feature)

Open a Pull Request

📄 License
This project is licensed under the MIT License - see the LICENSE.md file for details.

🎯 Future Roadmap
🛒 Basket Service with Redis integration

📦 Order Service with event-driven architecture

🚪 API Gateway with Ocelot

🧪 Unit and Integration Tests

⚙️ CI/CD Pipeline setup

☸️ Kubernetes Deployment manifests

📊 Monitoring and Logging solutions

💳 Payment Integration

✉️ Email Notifications system
