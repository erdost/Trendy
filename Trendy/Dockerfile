FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY Trendy/Trendy.csproj Trendy/
RUN dotnet restore
COPY . .
WORKDIR /src/Trendy
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
COPY SEED_DATA.json /SEED_DATA.json
COPY CreateTrendyDatabase.sql /CreateTrendyDatabase.sql
COPY CreateTableProducts.sql /CreateTableProducts.sql
COPY InsertProducts.sql /InsertProducts.sql
ENTRYPOINT ["dotnet", "Trendy.dll"]
