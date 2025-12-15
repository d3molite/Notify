FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Notify/Notify.csproj", "Notify/"]
RUN dotnet restore "Notify/Notify.csproj"
COPY . .
WORKDIR "/src/Notify"
RUN dotnet build "./Notify.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Notify.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

RUN mkdir /app/config

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notify.dll"]
