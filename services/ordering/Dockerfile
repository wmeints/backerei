FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY Backerei.Ordering.sln .
COPY Server/Backerei.Ordering.Server.csproj ./Server/
COPY Domain/Backerei.Ordering.Domain.csproj ./Domain/
COPY Infrastructure/Backerei.Ordering.Infrastructure.csproj ./Infrastructure/

RUN dotnet restore

ADD . .

RUN dotnet publish Server/Backerei.Ordering.Server.csproj -c Release -o /dist

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /app
COPY --from=build /dist /app

EXPOSE 80

CMD dotnet Backerei.Ordering.Server.dll