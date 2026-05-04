
# LABAPI — Simple ASP.NET Core Web API

Small ASP.NET Core Web API demonstrating a User CRUD API with middleware and Swagger.

Repository: https://github.com/jetchadaphon/labapi.git

Features
- CRUD endpoints for `User` (GET all, GET by id, POST, PUT, DELETE)
- Validation using DataAnnotations
- Request logging middleware and global error handling
- Swagger/OpenAPI UI for interactive testing

Quick run

```powershell
dotnet restore
dotnet run
```

Open Swagger UI at the URL printed by `dotnet run` (commonly `https://localhost:5001/swagger`). Use the UI to exercise the CRUD endpoints.

Sample curl commands

```bash
# Create a user
curl -k -H "Content-Type: application/json" -d '{"name":"Tom","email":"tom@example.com","age":28}' https://localhost:5001/api/users

# Get all users
curl -k https://localhost:5001/api/users

# Get user by id
curl -k https://localhost:5001/api/users/<id>

# Update user
curl -k -X PUT -H "Content-Type: application/json" -d '{"name":"Tom Updated","email":"tom@example.com","age":29}' https://localhost:5001/api/users/<id>

# Delete user
curl -k -X DELETE https://localhost:5001/api/users/<id>
```

Prepare and push to GitHub

If you want to push this folder to the repository above, run:

```bash
git init
git add .
git commit -m "Initial: Simple User API with middleware and Swagger"
git branch -M main
git remote add origin https://github.com/jetchadaphon/labapi.git
git push -u origin main
```

Notes about Copilot

- I used Microsoft Copilot to help debug middleware and controller validation, improve error-handling responses, and tidy ModelState checks. Suggestions were reviewed and adjusted manually.

Next steps you may want
- Add a Unit Test project to demonstrate tests (optional)
- Add authentication middleware if restricted access is required

