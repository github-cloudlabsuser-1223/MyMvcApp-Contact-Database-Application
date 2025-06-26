# MyMvcApp - Contact Database Application

## Overview
This is an ASP.NET Core MVC CRUD application for managing a simple contact database. It allows users to create, read, update, delete, and search for contacts by name or email. The app is ready for deployment to Azure App Services.

## Features
- Add, edit, view, and delete users (contacts)
- Search users by name or email
- Responsive UI using Bootstrap
- In-memory data storage (for demo purposes)

## Project Structure
- `Controllers/` - MVC controllers (main: `UserController`)
- `Models/` - Data models (`User`)
- `Views/` - Razor views for user CRUD and search
- `wwwroot/` - Static files (CSS, JS, Bootstrap, etc.)
- `deploy.json` & `deploy.parameters.json` - ARM templates for Azure deployment
- `.github/workflows/azure-webapp-deploy.yml` - GitHub Actions workflow for CI/CD

## Getting Started
### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (optional, for front-end tooling)

### Running Locally
1. Clone the repository
2. Restore dependencies:
   ```sh
   dotnet restore
   ```
3. Build and run the app:
   ```sh
   dotnet run --project MyMvcApp.csproj
   ```
4. Open your browser at `https://localhost:5001` or `http://localhost:5000`

## Deployment
### Azure App Service (ARM Template)
1. Edit `deploy.parameters.json` to set a unique `webAppName`.
2. Deploy using Azure CLI:
   ```sh
   az deployment group create --resource-group <your-resource-group> --template-file deploy.json --parameters deploy.parameters.json
   ```

### GitHub Actions (CI/CD)
1. Download your Azure Web App publish profile from the Azure Portal.
2. Add the following repository secrets:
   - `AZURE_WEBAPP_NAME` (your web app name)
   - `AZURE_WEBAPP_PUBLISH_PROFILE` (contents of the publish profile)
3. Push to `main` branch to trigger deployment.

## Customization
- To use a real database, replace the in-memory list in `UserController` with Entity Framework Core and update the model accordingly.
- Update views in `Views/User/` for custom UI/UX.

## License
MIT
