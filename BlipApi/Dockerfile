FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BlipApi/BlipApi.csproj", "BlipApi/"]
RUN dotnet restore "BlipApi/BlipApi.csproj"
COPY ./BlipApi ./BlipApi
WORKDIR "/src/BlipApi"
RUN dotnet build "BlipApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlipApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m myappuser
USER myappuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet BlipApi.dll
