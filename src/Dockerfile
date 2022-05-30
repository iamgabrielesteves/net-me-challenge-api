FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Set the workdir for the application
WORKDIR /app

# Copy csproj and restore
COPY . /app

# Install Cake, and compile the Cake build script
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# Copy the production artifacts to the workdir
COPY --from=build-env /app/out .

# Set the port that the application will run on
ENV ASPNETCORE_URLS=http://+:80

# Set the command that will run the API
ENTRYPOINT ["dotnet", "MeChallenge.API.dll"]

# Expose the port that the application will run on
EXPOSE 80