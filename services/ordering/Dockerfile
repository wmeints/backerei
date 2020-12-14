FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY src/Backerei.Ordering.Api/Backerei.Ordering.Api.csproj src/Backerei.Ordering.Api/
COPY src/Backerei.Ordering.Domain/Backerei.Ordering.Domain.csproj src/Backerei.Ordering.Domain/
COPY src/Backerei.Ordering.Infrastructure/Backerei.Ordering.Infrastructure.csproj src/Backerei.Ordering.Infrastructure/
COPY tests/Backerei.Ordering.Api.Tests/Backerei.Ordering.Api.Tests.csproj tests/Backerei.Ordering.Api.Tests/
COPY tests/Backerei.Ordering.Domain.Tests/Backerei.Ordering.Domain.Tests.csproj tests/Backerei.Ordering.Domain.Tests/
COPY tests/Backerei.Ordering.Infrastructure.Tests/Backerei.Ordering.Infrastructure.Tests.csproj tests/Backerei.Ordering.Infrastructure.Tests/
COPY Backerei.Ordering.sln .

RUN dotnet restore

ADD src/Backerei.Ordering.Api src/Backerei.Ordering.Api
ADD src/Backerei.Ordering.Domain src/Backerei.Ordering.Domain
ADD src/Backerei.Ordering.Infrastructure src/Backerei.Ordering.Infrastructure

RUN dotnet build src/Backerei.Ordering.Api -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /app
COPY --from=build /app .

EXPOSE 80
EXPOSE 443

CMD dotnet Backerei.Ordering.Api.dll