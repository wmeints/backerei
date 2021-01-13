FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY Backerei.Catalog.sln .
COPY Server/Backerei.Catalog.Server.csproj ./Server/
COPY Domain/Backerei.Catalog.Domain.csproj ./Domain/
COPY Infrastructure/Backerei.Catalog.Infrastructure.csproj ./Infrastructure/

RUN dotnet restore

ADD . .

RUN dotnet publish Server/Backerei.Catalog.Server.csproj -c Release -o /dist

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /app
COPY --from=build /dist /app

EXPOSE 80

CMD dotnet Backerei.Catalog.Server.dll