FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY Server/Backerei.Frontend.Server.csproj Server/
COPY Client/Backerei.Frontend.Client.csproj Client/
COPY Shared/Backerei.Frontend.Shared.csproj Shared/
COPY Backerei.Frontend.sln .

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