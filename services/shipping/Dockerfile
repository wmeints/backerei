FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY src/Backerei.Shipping.Api/Backerei.Shipping.Api.csproj src/Backerei.Shipping.Api/
COPY src/Backerei.Shipping.Domain/Backerei.Shipping.Domain.csproj src/Backerei.Shipping.Domain/
COPY src/Backerei.Shipping.Infrastructure/Backerei.Shipping.Infrastructure.csproj src/Backerei.Shipping.Infrastructure/
COPY tests/Backerei.Shipping.Api.Tests/Backerei.Shipping.Api.Tests.csproj tests/Backerei.Shipping.Api.Tests/
COPY tests/Backerei.Shipping.Domain.Tests/Backerei.Shipping.Domain.Tests.csproj tests/Backerei.Shipping.Domain.Tests/
COPY tests/Backerei.Shipping.Infrastructure.Tests/Backerei.Shipping.Infrastructure.Tests.csproj tests/Backerei.Shipping.Infrastructure.Tests/
COPY Backerei.Shipping.sln .

RUN dotnet restore

ADD src/Backerei.Shipping.Api src/Backerei.Shipping.Api
ADD src/Backerei.Shipping.Domain src/Backerei.Shipping.Domain
ADD src/Backerei.Shipping.Infrastructure src/Backerei.Shipping.Infrastructure

RUN dotnet build src/Backerei.Shipping.Api -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /app
COPY --from=build /app .

EXPOSE 80
EXPOSE 443

CMD dotnet Backerei.Shipping.Api.dll