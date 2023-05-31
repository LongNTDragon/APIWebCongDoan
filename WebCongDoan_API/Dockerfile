FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebCongDoan_API.csproj", "."]
RUN dotnet restore "./WebCongDoan_API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WebCongDoan_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebCongDoan_API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebCongDoan_API.dll"]