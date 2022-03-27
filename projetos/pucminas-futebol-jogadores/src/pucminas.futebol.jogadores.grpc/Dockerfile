#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/pucminas.futebol.jogadores.grpc/pucminas.futebol.jogadores.grpc.csproj", "src/pucminas.futebol.jogadores.grpc/"]
RUN dotnet restore "src/pucminas.futebol.jogadores.grpc/pucminas.futebol.jogadores.grpc.csproj"
COPY . .
WORKDIR "/src/src/pucminas.futebol.jogadores.grpc"
RUN dotnet build "pucminas.futebol.jogadores.grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "pucminas.futebol.jogadores.grpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "pucminas.futebol.jogadores.grpc.dll"]