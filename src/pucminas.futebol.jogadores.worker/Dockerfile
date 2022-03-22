#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/pucminas.futebol.jogadores.worker/pucminas.futebol.jogadores.worker.csproj", "src/pucminas.futebol.jogadores.worker/"]
RUN dotnet restore "src/pucminas.futebol.jogadores.worker/pucminas.futebol.jogadores.worker.csproj"
COPY . .
WORKDIR "/src/src/pucminas.futebol.jogadores.worker"
RUN dotnet build "pucminas.futebol.jogadores.worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "pucminas.futebol.jogadores.worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "pucminas.futebol.jogadores.worker.dll"]