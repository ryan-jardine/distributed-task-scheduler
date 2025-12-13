# ---------- build ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy solution + csproj first (better caching)
COPY DistributedTaskScheduler.slnx .
COPY DistributedTaskScheduler.Api/*.csproj DistributedTaskScheduler.Api/
COPY DistributedTaskScheduler.Worker/*.csproj DistributedTaskScheduler.Worker/
COPY DistributedTaskScheduler.Core/*.csproj DistributedTaskScheduler.Core/

RUN dotnet restore

# Copy everything else
COPY . .

# Publish API
RUN dotnet publish DistributedTaskScheduler.Api/DistributedTaskScheduler.Api.csproj \
    -c Release -o /app/publish

# ---------- runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DistributedTaskScheduler.Api.dll"]
