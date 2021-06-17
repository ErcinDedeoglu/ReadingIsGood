#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ReadingIsGood.Gateway.API/ReadingIsGood.Gateway.API.csproj", "ReadingIsGood.Gateway.API/"]
RUN dotnet restore "ReadingIsGood.Gateway.API/ReadingIsGood.Gateway.API.csproj"
COPY . .
WORKDIR "/src/ReadingIsGood.Gateway.API"
RUN dotnet build "ReadingIsGood.Gateway.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReadingIsGood.Gateway.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReadingIsGood.Gateway.API.dll"]