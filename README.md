# EntrantsApi
.NET REST API with the following functions:

- GET routes
- - Local: https://localhost:9002/Entrant
- - Azure: https://entrantsapi.azurewebsites.net/Entrant
- POST, PUT, and DELETE routes
- - Local: https://localhost:9002/Entrant
- - Azure: https://entrantsapi.azurewebsites.net/Entrant

There are example POSTMAN collections stored under Resources/, which you can import into your POSTMAN application to test the HTTP requests.

# Prerequisites 

- Visual Studio Code
- C# for Visual Studio Code
- .NET 5.0 SDK

# Run locally

- Shortcut to run the project in Visual Studio Code is Control + F5

# How to deploy to Azure?

- Make Azure account
- Install Azure App Service extension in Visual Studio Code
- In terminal in project folder, generate a release package using: dotnet publish -c Release -o ./publish
- Right click the newly created publish folder and select 'Deploy to Azure'
