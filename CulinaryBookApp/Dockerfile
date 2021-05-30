FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CulinaryBookApp/CulinaryBookApp.csproj", "CulinaryBookApp/"]
RUN dotnet restore "CulinaryBookApp/CulinaryBookApp.csproj"
COPY . .
WORKDIR "/src/CulinaryBookApp"
RUN dotnet build "CulinaryBookApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CulinaryBookApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CulinaryBookApp.dll"]
