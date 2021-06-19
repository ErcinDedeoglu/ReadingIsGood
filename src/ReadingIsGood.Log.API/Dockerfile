#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ReadingIsGood.Log.API/ReadingIsGood.Log.API.csproj", "ReadingIsGood.Log.API/"]
RUN dotnet restore "ReadingIsGood.Log.API/ReadingIsGood.Log.API.csproj"
COPY . .
WORKDIR "/src/ReadingIsGood.Log.API"
RUN dotnet build "ReadingIsGood.Log.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReadingIsGood.Log.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReadingIsGood.Log.API.dll"]