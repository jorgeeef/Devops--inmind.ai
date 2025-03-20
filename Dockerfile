# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the .csproj file from the Microservice-project folder and restore dependencies
COPY ["Microservice-devops/Microservice-devops.csproj", "./"]
RUN dotnet restore "Microservice-devops.csproj"

# Copy the rest of the files from the Microservice-project folder
COPY Microservice-devops/. .

WORKDIR "/src/"
RUN dotnet build "Microservice-devops.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Microservice-devops.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Use the .NET runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Copy the published app from the publish stage
FROM base AS final
COPY --from=publish /app/publish . 

# Define the entry point for the application
ENTRYPOINT ["dotnet", "Microservice-devops.dll"]
