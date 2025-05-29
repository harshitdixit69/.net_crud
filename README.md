# .NET 6 MySQL CRUD Application

This is a .NET 6 Web API project that demonstrates CRUD operations using MySQL as the database. The application includes user authentication using JWT tokens and provides endpoints for managing notes.

## Features

- 🔐 JWT Authentication
- 📝 CRUD operations for Notes
- 🔄 Entity Framework Core with MySQL
- 🌐 Cross-Origin Resource Sharing (CORS) support
- 🛠️ Auto Mapper for object mapping
- 🐍 Snake case naming convention for database
- ⚠️ Global error handling middleware

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) (version 8.0 or higher)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

## Project Setup

1. Clone the repository:
```bash
git clone https://github.com/harshitdixit69/.net_crud.git
cd dotnet-6-mysql-crud-application
```

2. Update the database connection string in `appsettings.json`:
```json
"ConnectionStrings": {
    "ApiDatabase": "server=localhost; port=3308; database=apyflux; user={DB_USERNAME}; password={DBPASSWORD}"
}
```

3. Install required NuGet packages:
```bash
dotnet restore
```

4. Apply database migrations:
```bash
dotnet ef database update
```

5. Run the application:
```bash
dotnet run
```

The API will be available at `http://localhost:9080`

## Project Structure

- `Controllers/` - API endpoints and route definitions
- `Services/` - Business logic implementation
- `Models/` - Data transfer objects (DTOs)
- `Entities/` - Database models
- `Helpers/` - Utility classes and middleware
- `Migrations/` - Database migration files

## Authentication

The application uses JWT (JSON Web Token) for authentication. To access protected endpoints:

1. Register a new user
2. Login to get the JWT token
3. Include the token in the Authorization header: `Bearer {your-token}`

## API Endpoints

### Authentication
- POST `/api/Auth/register` - Register a new user
- POST `/api/Auth/login` - Login and get JWT token

### Notes (Protected Routes)
- GET `/api/Notes` - Get all notes
- GET `/api/Notes/{id}` - Get note by ID
- POST `/api/Notes` - Create a new note
- PUT `/api/Notes/{id}` - Update an existing note
- DELETE `/api/Notes/{id}` - Delete a note

## Security

- JWT token secret key is configured in `appsettings.json`
- CORS is enabled for all origins (can be restricted in production)
- Password hashing is implemented for user security
- Authentication middleware validates JWT tokens

## Error Handling

The application includes a global error handler middleware that catches and formats all exceptions into a consistent response format.

## Development

To run the application in development mode:

```bash
dotnet watch run
```

This will enable hot reload and automatic browser refresh when changes are made.

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

This project is licensed under the MIT License. 