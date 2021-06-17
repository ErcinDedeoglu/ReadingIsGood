#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ReadingIsGood.Authorization.API/ReadingIsGood.Authorization.API.csproj", "ReadingIsGood.Authorization.API/"]
RUN dotnet restore "ReadingIsGood.Authorization.API/ReadingIsGood.Authorization.API.csproj"
COPY . .
WORKDIR "/src/ReadingIsGood.Authorization.API"
RUN dotnet build "ReadingIsGood.Authorization.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReadingIsGood.Authorization.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReadingIsGood.Authorization.API.dll"]