FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore Lab13-YoselinCcapera/Lab13-YoselinCcapera.csproj
RUN dotnet publish Lab13-YoselinCcapera/Lab13-YoselinCcapera.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000
ENTRYPOINT ["dotnet", "Lab13-YoselinCcapera.dll"]
