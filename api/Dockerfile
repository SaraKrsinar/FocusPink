# build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY FocusPink.Core/FocusPink.Core.csproj FocusPink.Core/
COPY FocusPink.Infrastructure/FocusPink.Infrastructure.csproj FocusPink.Infrastructure/
COPY FocusPink.Api/FocusPink.Api.csproj FocusPink.Api/
RUN dotnet restore FocusPink.Api/FocusPink.Api.csproj
COPY . .
RUN dotnet publish FocusPink.Api/FocusPink.Api.csproj -c Release -o /app

# runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "FocusPink.Api.dll"]
