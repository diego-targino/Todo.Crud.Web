# Etapa base
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ARG Todo.Crud.Web.Api.csproj

WORKDIR /app
EXPOSE 8080
EXPOSE 8081
# Etapa de constru��o
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Copiar arquivos de projeto e restaurar depend�ncias

WORKDIR /src
COPY ["./Todo.Crud.Web.Api/Todo.Crud.Web.Api.csproj", "./Todo.Crud.Web.Api/"]

# Copiar todos os arquivos e construir a aplica��o

WORKDIR /src/
COPY [".", "."] 

RUN dotnet restore "./Todo.Crud.Web.Api/Todo.Crud.Web.Api.csproj"

RUN dotnet build "./Todo.Crud.Web.Api/Todo.Crud.Web.Api.csproj" -c Release -o /app/build

# Etapa de publica��o
FROM build AS publish
RUN dotnet publish "./Todo.Crud.Web.Api/Todo.Crud.Web.Api.csproj" -c Release -o /app/publish 

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todo.Crud.Web.Api.dll"]
