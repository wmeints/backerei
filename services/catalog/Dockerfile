FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY src/Backerei.Catalog.Api/Backerei.Catalog.Api.csproj src/Backerei.Catalog.Api/
COPY src/Backerei.Catalog.Domain/Backerei.Catalog.Domain.csproj src/Backerei.Catalog.Domain/
COPY src/Backerei.Catalog.Infrastructure/Backerei.Catalog.Infrastructure.csproj src/Backerei.Catalog.Infrastructure/
COPY tests/Backerei.Catalog.Api.Tests/Backerei.Catalog.Api.Tests.csproj tests/Backerei.Catalog.Api.Tests/
COPY tests/Backerei.Catalog.Domain.Tests/Backerei.Catalog.Domain.Tests.csproj tests/Backerei.Catalog.Domain.Tests/
COPY tests/Backerei.Catalog.Infrastructure.Tests/Backerei.Catalog.Infrastructure.Tests.csproj tests/Backerei.Catalog.Infrastructure.Tests/
COPY Backerei.Catalog.sln .

RUN dotnet restore

ADD src/Backerei.Catalog.Api src/Backerei.Catalog.Api
ADD src/Backerei.Catalog.Domain src/Backerei.Catalog.Domain
ADD src/Backerei.Catalog.Infrastructure src/Backerei.Catalog.Infrastructure

RUN dotnet build src/Backerei.Catalog.Api -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /app
COPY --from=build /app .

EXPOSE 80
EXPOSE 443

CMD dotnet Backerei.Catalog.Api.dll