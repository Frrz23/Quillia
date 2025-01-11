# Use the base image for ASP.NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Use the SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj file(s) and restore the dependencies
COPY Quillia.csproj ./ 
RUN dotnet restore

# Copy the rest of the code
COPY . ./
WORKDIR /src/
RUN dotnet build "Quillia.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Quillia.csproj" -c Release -o /app/publish

# Define the entry point for the container
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quillia.dll"]
