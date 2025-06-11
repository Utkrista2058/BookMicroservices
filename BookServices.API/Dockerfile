# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER $APP_UID
WORKDIR /app
EXPOSE 80
EXPOSE 443


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BookServices.API/BookServices.API.csproj", "BookServices.API/"]
COPY ["BookServices.Application/BookServices.Application.csproj", "BookServices.Application/"]
COPY ["BookServices.Domain/BookServices.Domain.csproj", "BookServices.Domain/"]
COPY ["BookServices.Infrastructure/BookServices.Infrastructure.csproj", "BookServices.Infrastructure/"]
RUN dotnet restore "./BookServices.API/BookServices.API.csproj"
COPY . .
WORKDIR "/src/BookServices.API"
RUN dotnet build "./BookServices.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BookServices.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookServices.API.dll"]