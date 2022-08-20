#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
RUN dotnet tool install --global dotnet-ef
WORKDIR /src
RUN mkdir SnappTrip SnappTrip.BusinessLayer SnappTrip.DataAccessLayer
COPY ["SnappTrip/SnappTrip.csproj", "SnappTrip/"]
COPY ["SnappTrip.BusinessLayer/SnappTrip.BusinessLayer.csproj", "SnappTrip.BusinessLayer/"]
COPY ["SnappTrip.DataAccessLayer/SnappTrip.DataAccessLayer.csproj", "SnappTrip.DataAccessLayer/"]
RUN dotnet restore "SnappTrip/SnappTrip.csproj"
COPY . .
#RUN dotnet ef database update --project "SnappTrip.DataAccessLayer/SnappTrip.DataAccessLayer.csproj"
WORKDIR "/src/SnappTrip"
RUN dotnet build "SnappTrip.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SnappTrip.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SnappTrip.dll"]