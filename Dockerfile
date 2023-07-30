#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/WebApi/CefetPark.WebApi/CefetPark.WebApi.csproj", "src/WebApi/CefetPark.WebApi/"]
COPY ["src/Application/CefetPark.Application/CefetPark.Application.csproj", "src/Application/CefetPark.Application/"]
COPY ["src/CrossCutting/Utils/CefetPark.Utils/CefetPark.Utils.csproj", "src/CrossCutting/Utils/CefetPark.Utils/"]
COPY ["src/Domain/CefetPark.Domain/CefetPark.Domain.csproj", "src/Domain/CefetPark.Domain/"]
COPY ["src/CrossCutting/Ioc/CefetPark.Ioc/CefetPark.Ioc.csproj", "src/CrossCutting/Ioc/CefetPark.Ioc/"]
COPY ["src/Infra/CefetPark.Infra/CefetPark.Infra.csproj", "src/Infra/CefetPark.Infra/"]
RUN dotnet restore "src/WebApi/CefetPark.WebApi/CefetPark.WebApi.csproj"
COPY . .
WORKDIR "/src/src/WebApi/CefetPark.WebApi"
RUN dotnet build "CefetPark.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CefetPark.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CefetPark.WebApi.dll"]