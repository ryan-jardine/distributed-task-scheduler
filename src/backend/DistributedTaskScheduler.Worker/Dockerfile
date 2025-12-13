# ---------- build ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY DistributedTaskScheduler.slnx .
COPY DistributedTaskScheduler.Api/*.csproj DistributedTaskScheduler.Api/
COPY DistributedTaskScheduler.Worker/*.csproj DistributedTaskScheduler.Worker/
COPY DistributedTaskScheduler.Core/*.csproj DistributedTaskScheduler.Core/

RUN dotnet restore

COPY . .

RUN dotnet publish DistributedTaskScheduler.Worker/DistributedTaskScheduler.Worker.csproj \
    -c Release -o /app/publish

# ---------- runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DistributedTaskScheduler.Worker.dll"]
