#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Doctor Entinity Boris Marinov/Doctor Entinity Boris Marinov.csproj", "Doctor Entinity Boris Marinov/"]
RUN dotnet restore "Doctor Entinity Boris Marinov/Doctor Entinity Boris Marinov.csproj"
COPY . .
WORKDIR "/src/Doctor Entinity Boris Marinov"
RUN dotnet build "Doctor Entinity Boris Marinov.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Doctor Entinity Boris Marinov.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Doctor Entinity Boris Marinov.dll"]