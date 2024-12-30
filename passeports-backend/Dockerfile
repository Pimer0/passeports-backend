# Étape 1 : Image de base pour l'exécution
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Étape 2 : Image de construction
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copie du fichier .csproj et restore dans le bon dossier
COPY ["passeports-backend/passeports-backend.csproj", "."]
RUN dotnet restore "passeports-backend.csproj"

# Copie du reste des fichiers
COPY . .

# Compilation du projet dans le bon dossier
RUN dotnet build "passeports-backend.csproj" -c $BUILD_CONFIGURATION -o /app/build /p:UseAppHost=false

# Étape 3 : Publication
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "passeports-backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Étape 4 : Préparer l'image finale
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "passeports-backend.dll"]