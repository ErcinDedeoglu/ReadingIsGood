#ReadingIsGood.Customer.API

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ReadingIsGood.Customer.API/ReadingIsGood.Customer.API.csproj", "ReadingIsGood.Customer.API/"]
RUN dotnet restore "ReadingIsGood.Customer.API/ReadingIsGood.Customer.API.csproj"
COPY . .
WORKDIR "/src/ReadingIsGood.Customer.API"
RUN dotnet build "ReadingIsGood.Customer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReadingIsGood.Customer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ReadingIsGood.Customer.API.dll"]
# Use the following instead for Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ReadingIsGood.Customer.API.dll