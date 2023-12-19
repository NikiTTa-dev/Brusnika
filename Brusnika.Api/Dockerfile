FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Brusnika.Api/Brusnika.Api.csproj", "Brusnika.Api/"]
COPY ["Brusnika.Domain/Brusnika.Domain.csproj", "Brusnika.Domain/"]
COPY ["Brusnika.Contracts/Brusnika.Contracts.csproj", "Brusnika.Contracts/"]
COPY ["Brusnika.Infrastructure/Brusnika.Infrastructure.csproj", "Brusnika.Infrastructure/"]
COPY ["Brusnika.Application/Brusnika.Application.csproj", "Brusnika.Application/"]
RUN dotnet restore "Brusnika.Api/Brusnika.Api.csproj"
COPY . .
WORKDIR "/src/Brusnika.Api"
RUN dotnet build "Brusnika.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Brusnika.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src /src
ENTRYPOINT ["dotnet", "Brusnika.Api.dll"]
