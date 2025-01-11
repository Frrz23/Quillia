# Use the official .NET SDK image to build the app (use .NET 8 SDK to match the build version)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the .csproj file and restore the dependencies (use COPY for specific files to avoid unnecessary files)
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application and publish it
COPY . ./
RUN dotnet publish -c Release -o /app/out

# Use the official ASP.NET runtime image to run the app (use .NET 8 runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Copy the published output from the build stage
COPY --from=build /app/out ./

# Command to run the application (ensure 'Quillia.dll' matches your app's actual DLL name)
ENTRYPOINT ["dotnet", "Quillia.dll"]
