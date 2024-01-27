FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ChronoClash_landingPage/ChronoClash_landingPage.csproj", "ChronoClash_landingPage/"]
RUN dotnet restore "ChronoClash_landingPage/ChronoClash_landingPage.csproj"
COPY . .
WORKDIR "/src/ChronoClash_landingPage"
RUN dotnet build "ChronoClash_landingPage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChronoClash_landingPage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChronoClash_landingPage.dll"]
