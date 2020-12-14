FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY src/Backerei.Production.Api/Backerei.Production.Api.csproj src/Backerei.Production.Api/
COPY src/Backerei.Production.Domain/Backerei.Production.Domain.csproj src/Backerei.Production.Domain/
COPY src/Backerei.Production.Infrastructure/Backerei.Production.Infrastructure.csproj src/Backerei.Production.Infrastructure/
COPY tests/Backerei.Production.Api.Tests/Backerei.Production.Api.Tests.csproj tests/Backerei.Production.Api.Tests/
COPY tests/Backerei.Production.Domain.Tests/Backerei.Production.Domain.Tests.csproj tests/Backerei.Production.Domain.Tests/
COPY tests/Backerei.Production.Infrastructure.Tests/Backerei.Production.Infrastructure.Tests.csproj tests/Backerei.Production.Infrastructure.Tests/
COPY Backerei.Production.sln .

RUN dotnet restore

ADD src/Backerei.Production.Api src/Backerei.Production.Api
ADD src/Backerei.Production.Domain src/Backerei.Production.Domain
ADD src/Backerei.Production.Infrastructure src/Backerei.Production.Infrastructure

RUN dotnet build src/Backerei.Production.Api -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /app
COPY --from=build /app .

EXPOSE 80
EXPOSE 443

CMD dotnet Backerei.Production.Api.dll