FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-notification
WORKDIR /src
COPY ["RPI_Task.csproj", "./"]
RUN dotnet restore "./RPI_Task.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "RPI_Task.csproj" -c Release -o /app/build

FROM build-notification AS publish
RUN dotnet publish "RPI_Task.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RPI_Task.dll"]
