FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RecipeCostControl.API/RecipeCostControl.API.csproj", "RecipeCostControl.API/"]
COPY ["RecipeCostControl.Data/RecipeCostControl.Data.csproj", "RecipeCostControl.Data/"]
COPY ["RecipeCostControl.Data.Dto/RecipeCostControl.Data.Dto.csproj", "RecipeCostControl.Data.Dto/"]
COPY ["RecipeCostControl.Services/RecipeCostControl.Services.csproj", "RecipeCostControl.Services/"]
RUN dotnet restore "./RecipeCostControl.API/RecipeCostControl.API.csproj"

COPY . .
WORKDIR "/src/RecipeCostControl.API"
RUN dotnet build "RecipeCostControl.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "RecipeCostControl.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN chmod +x /app/entrypoint.sh

ENTRYPOINT ["/entrypoint.sh"]

CMD ["dotnet", "RecipeCostControl.API.dll"]