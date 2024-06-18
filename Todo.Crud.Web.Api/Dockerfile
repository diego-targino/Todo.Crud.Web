# Imagem base para o build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Copia o arquivo de solução e projetos para o contêiner
COPY Todo.Crud.Web.Api/*.csproj ./Todo.Crud.Web.Api/
COPY Todo.Crud.Web.Application/*.csproj ./Todo.Crud.Web.Application/
COPY Todo.Crud.Web.CrossCutting/*.csproj ./Todo.Crud.Web.CrossCutting/
COPY Todo.Crud.Web.Domain/*.csproj ./Todo.Crud.Web.Domain/
COPY Todo.Crud.Web.Infrastructure/*.csproj ./Todo.Crud.Web.Infrastructure/

# Restaura as dependências
RUN dotnet restore

# Copia todos os arquivos restantes e constrói o projeto
COPY . ./
RUN dotnet publish "Todo.Crud.Web.Api/Todo.Crud.Web.Api.csproj" -c Release -o /app/publish

# Imagem base para a execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copia os artefatos publicados da etapa de build
COPY --from=build-env /app/publish .

# Define o ponto de entrada
ENTRYPOINT ["dotnet", "Todo.Crud.Web.Api.dll"]
