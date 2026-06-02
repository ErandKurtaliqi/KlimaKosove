FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ClimateAPI/ClimateAPI.csproj ClimateAPI/
RUN dotnet restore ClimateAPI/ClimateAPI.csproj

COPY ClimateAPI/ ClimateAPI/
RUN dotnet publish ClimateAPI/ClimateAPI.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ClimateAPI.dll"]
