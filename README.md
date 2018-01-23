# Microservices with .NET Core 2


## Init

```bash
# Create a new app in the current directory
$ dotnet new console

# Create a new app in the folder myApp
$ dotnet new console -o myApp
```

## Publish 

```bash
$ dotnet publish -o app
```

## Restore

```bash
$ dotnet restore
```

## Dockerize

Create a `.dockerignore`:

```
bin\
obj\
```

```Dockerfile
FROM microsoft/apsnetcore-build:2.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "microservice.dll"]
```


