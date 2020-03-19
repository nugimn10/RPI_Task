FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS build-user
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["UserServices.csproj", "./"]
RUN dotnet restore "./UserServices.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "UserServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserServices.csproj" -c Release -o /app/publish

FROM build-user AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserServices.dll"]
