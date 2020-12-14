FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY src/Backerei.ShoppingCart.Api/Backerei.ShoppingCart.Api.csproj src/Backerei.ShoppingCart.Api/
COPY src/Backerei.ShoppingCart.Domain/Backerei.ShoppingCart.Domain.csproj src/Backerei.ShoppingCart.Domain/
COPY src/Backerei.ShoppingCart.Infrastructure/Backerei.ShoppingCart.Infrastructure.csproj src/Backerei.ShoppingCart.Infrastructure/
COPY tests/Backerei.ShoppingCart.Api.Tests/Backerei.ShoppingCart.Api.Tests.csproj tests/Backerei.ShoppingCart.Api.Tests/
COPY tests/Backerei.ShoppingCart.Domain.Tests/Backerei.ShoppingCart.Domain.Tests.csproj tests/Backerei.ShoppingCart.Domain.Tests/
COPY tests/Backerei.ShoppingCart.Infrastructure.Tests/Backerei.ShoppingCart.Infrastructure.Tests.csproj tests/Backerei.ShoppingCart.Infrastructure.Tests/
COPY Backerei.ShoppingCart.sln .

RUN dotnet restore

ADD src/Backerei.ShoppingCart.Api src/Backerei.ShoppingCart.Api
ADD src/Backerei.ShoppingCart.Domain src/Backerei.ShoppingCart.Domain
ADD src/Backerei.ShoppingCart.Infrastructure src/Backerei.ShoppingCart.Infrastructure

RUN dotnet build src/Backerei.ShoppingCart.Api -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /app
COPY --from=build /app .

EXPOSE 80
EXPOSE 443

CMD dotnet Backerei.ShoppingCart.Api.dll