#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 32775

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/RetornoTaxa/RetornoTaxa.API/RetornoTaxa.API.csproj", "src/RetornoTaxa/RetornoTaxa.API/"]
COPY ["src/RetornoTaxa/RetornoTaxa.Domain/RetornoTaxa.Domain.csproj", "src/RetornoTaxa/RetornoTaxa.Domain/"]
COPY ["src/RetornoTaxa/RetornoTaxa.Infra/RetornoTaxa.Infra.csproj", "src/RetornoTaxa/RetornoTaxa.Infra/"]
RUN dotnet restore "src/RetornoTaxa/RetornoTaxa.API/RetornoTaxa.API.csproj"
COPY . .
WORKDIR "/src/src/RetornoTaxa/RetornoTaxa.API"
RUN dotnet build "RetornoTaxa.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RetornoTaxa.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RetornoTaxa.API.dll"]
