# Étape 1 : Construction de l'application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copier tous les fichiers et restaurer les dépendances
COPY . .
RUN dotnet restore

# Compiler et publier l’application en self-contained pour linux-x64
RUN dotnet publish -c Release -r linux-x64 -o /app --self-contained true

# Étape 2 : Création de l’image finale
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /Angular_API

# Copier le résultat de la build
COPY --from=build /Angular_API .

# Définir le point d’entrée (adaptez le nom de l’exécutable)
ENTRYPOINT ["./API"]
