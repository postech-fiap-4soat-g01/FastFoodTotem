FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .

RUN dotnet publish -c Release src/Presentation/FastFoodTotem.Api/FastFoodTotem.Api.csproj -o /publish

FROM base AS final
WORKDIR /app
COPY --from=build /publish ./

ENTRYPOINT ["dotnet", "FastFoodTotem.Api.dll"]