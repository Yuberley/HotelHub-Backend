﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/HotelHub.WebAPI/HotelHub.WebAPI.csproj", "src/HotelHub.WebAPI/"]
RUN dotnet restore "src/HotelHub.WebAPI/HotelHub.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/HotelHub.WebAPI"
RUN dotnet build "HotelHub.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "HotelHub.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotelHub.WebAPI.dll"]
