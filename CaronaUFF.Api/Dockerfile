FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CaronaUFF.Api/CaronaUFF.Api.csproj", "CaronaUFF.Api/"]
RUN dotnet restore "CaronaUFF.Api/CaronaUFF.Api.csproj"
COPY . .
WORKDIR "/src/CaronaUFF.Api"
RUN dotnet build "CaronaUFF.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CaronaUFF.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CaronaUFF.Api.dll"]
