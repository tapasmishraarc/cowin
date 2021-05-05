FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY CowinTracker/CowinTracker.csproj CowinTracker/
RUN dotnet restore CowinTracker/CowinTracker.csproj
COPY . .
WORKDIR /src/CowinTracker
RUN dotnet build CowinTracker.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CowinTracker.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CowinTracker.dll"]
