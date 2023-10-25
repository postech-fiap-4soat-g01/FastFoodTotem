#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Adapters/Driver/FastFoodTotem.Api/FastFoodTotem.Api.csproj", "src/Adapters/Driver/FastFoodTotem.Api/"]
COPY ["src/Core/FastFoodTotem.Application/FastFoodTotem.Application.csproj", "src/Core/FastFoodTotem.Application/"]
COPY ["src/Core/FastFoodTotem.Domain/FastFoodTotem.Domain.csproj", "src/Core/FastFoodTotem.Domain/"]
COPY ["src/Adapters/Driven/FastFoodTotem.Infra.IoC/FastFoodTotem.Infra.IoC.csproj", "src/Adapters/Driven/FastFoodTotem.Infra.IoC/"]
COPY ["src/Adapters/Driven/FastFoodTotem.Infra.SqlServer/FastFoodTotem.Infra.SqlServer.csproj", "src/Adapters/Driven/FastFoodTotem.Infra.SqlServer/"]
COPY ["src/Adapters/Driven/FastFoodTotem.MercadoPago/FastFoodTotem.MercadoPago.csproj", "src/Adapters/Driven/FastFoodTotem.MercadoPago/"]
RUN dotnet restore "src/Adapters/Driver/FastFoodTotem.Api/FastFoodTotem.Api.csproj"
COPY . .
WORKDIR "/src/src/Adapters/Driver/FastFoodTotem.Api"
RUN dotnet build "FastFoodTotem.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FastFoodTotem.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FastFoodTotem.Api.dll"]