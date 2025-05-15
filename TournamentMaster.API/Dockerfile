# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TournamentMaster.API/TournamentMaster.API.csproj", "TournamentMaster.API/"]
COPY ["TournamentMaster.Application/TournamentMaster.Application.csproj", "TournamentMaster.Application/"]
COPY ["TournamentMaster.Domain/TournamentMaster.Domain.csproj", "TournamentMaster.Domain/"]
COPY ["TournamentMaster.Infrastructure/TournamentMaster.Infrastructure.csproj", "TournamentMaster.Infrastructure/"]
RUN dotnet restore "./TournamentMaster.API/TournamentMaster.API.csproj"
COPY . .
WORKDIR "/src/TournamentMaster.API"
RUN dotnet build "./TournamentMaster.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TournamentMaster.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TournamentMaster.API.dll"]