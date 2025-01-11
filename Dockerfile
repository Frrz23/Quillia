# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the .csproj file(s) and restore the dependencies
COPY Quillia/Quillia.csproj ./ 

RUN dotnet restore

# Copy the rest of the application files
COPY . ./ 

# Publish the app
RUN dotnet publish -c Release -o out

# Use the official ASP.NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Copy the built application
COPY --from=build /app/out .

# Command to run the application
ENTRYPOINT ["dotnet", "Quillia.dll"]  # Replace 'Quillia.dll' with your actual DLL file name
