FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["../1-Presentation/RendaFixaWebApi.csproj", "1-Presentation/"]
RUN dotnet restore "./1-Presentation/RendaFixaWebApi.csproj"
COPY . .
WORKDIR "/src/1-Presentation"
RUN dotnet build "./RendaFixaWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RendaFixaWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RendaFixaWebApi.dll"]