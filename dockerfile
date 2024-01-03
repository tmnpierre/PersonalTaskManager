# Use the official .NET SDK image to compile the source code
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy the csproj file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the project files
COPY . ./

# Compile the application
RUN dotnet publish -c Release -o out

# Use the .NET runtime base image to run the application
FROM mcr.microsoft.com/dotnet/runtime:6.0
WORKDIR /app
COPY --from=build /app/out .

# Set the command to start the application
ENTRYPOINT ["dotnet", "PersonalTaskManager.dll"]
