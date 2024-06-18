# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
# Etapa de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar arquivos de projeto e restaurar dependências
COPY ["Todo.Crud.Web.Api.csproj", "."]
RUN dotnet restore "Todo.Crud.Web.Api.csproj"

# Copiar todos os arquivos e construir a aplicação
COPY . .
RUN dotnet build "Todo.Crud.Web.Api.csproj" -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "Todo.Crud.Web.Api.csproj" -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todo.Crud.Web.Api.dll"]
