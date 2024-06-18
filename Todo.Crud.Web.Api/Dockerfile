# Etapa base
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ARG Todo.Crud.Web.Api.csproj

WORKDIR /app
EXPOSE 8080
EXPOSE 8081
# Etapa de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar arquivos de projeto e restaurar dependências
COPY ["Todo.Crud.Web.Api.csproj", "./Todo.Crud.Web.Api/"]
COPY ["../Todo.Crud.Web.CrossCutting/.", "./Todo.Crud.Web.CrossCutting/"]
COPY ["../Todo.Crud.Web.Infrastructure/.", "./Todo.Crud.Web.Infrastructure/"]
COPY ["../Todo.Crud.Web.Application/.", "./Todo.Crud.Web.Application/"]
COPY ["../Todo.Crud.Web.Domain/.", "./Todo.Crud.Web.Domain/"]

RUN dotnet restore "./Todo.Crud.Web.Domain/Todo.Crud.Web.Domain.csproj"
RUN dotnet restore "./Todo.Crud.Web.Application/Todo.Crud.Web.Application.csproj"
RUN dotnet restore "./Todo.Crud.Web.Infrastructure/Todo.Crud.Web.Infrastructure.csproj"
RUN dotnet restore "./Todo.Crud.Web.CrossCutting/Todo.Crud.Web.CrossCutting.csproj"
RUN dotnet restore "./Todo.Crud.Web.Api/Todo.Crud.Web.Api.csproj"
 
# Copiar todos os arquivos e construir a aplicação
WORKDIR "/src/Todo.Crud.Web.Api/"
COPY . .
WORKDIR /src
RUN dotnet build "./Todo.Crud.Web.Api/Todo.Crud.Web.Api.csproj" -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "./Todo.Crud.Web.Api/Todo.Crud.Web.Api.csproj" -c Release -o /app/publish 

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todo.Crud.Web.Api.dll"]
