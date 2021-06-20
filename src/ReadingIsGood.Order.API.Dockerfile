#ReadingIsGood.Order.API

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ReadingIsGood.Order.API/ReadingIsGood.Order.API.csproj", "ReadingIsGood.Order.API/"]
RUN dotnet restore "ReadingIsGood.Order.API/ReadingIsGood.Order.API.csproj"
COPY . .
WORKDIR "/src/ReadingIsGood.Order.API"
RUN dotnet build "ReadingIsGood.Order.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReadingIsGood.Order.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ReadingIsGood.Order.API.dll"]
# Use the following instead for Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ReadingIsGood.Order.API.dll