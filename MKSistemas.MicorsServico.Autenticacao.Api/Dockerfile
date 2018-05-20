FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY MKSistemas.MicrosServico.Autenticacao.Api/MKSistemas.MicrosServico.Autenticacao.Api.csproj MKSistemas.MicrosServico.Autenticacao.Api/
RUN dotnet restore MKSistemas.MicrosServico.Autenticacao.Api/MKSistemas.MicrosServico.Autenticacao.Api.csproj
COPY . .
WORKDIR /src/MKSistemas.MicrosServico.Autenticacao.Api
RUN dotnet build MKSistemas.MicrosServico.Autenticacao.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MKSistemas.MicrosServico.Autenticacao.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MKSistemas.MicrosServico.Autenticacao.Api.dll"]
