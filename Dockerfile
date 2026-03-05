FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file
COPY PlanService.sln .

# Copy project files
COPY PlanService/PlanService.csproj PlanService/
COPY PlanService.Application/PlanService.Application.csproj PlanService.Application/
COPY PlanService.Domain/PlanService.Domain.csproj PlanService.Domain/
COPY PlanService.Infrastructure/PlanService.Infrastructure.csproj PlanService.Infrastructure/

# Restore dependencies
RUN dotnet restore PlanService/PlanService.csproj

# Copy the rest of the code
COPY . .

# Build and publish
WORKDIR /src/PlanService
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PlanService.dll"]

