#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DefaultMessager.ChatAPI/DefaultMessager.ChatAPI/DefaultMessager.ChatAPI.csproj", "DefaultMessager.ChatAPI/DefaultMessager.ChatAPI/"]
RUN dotnet restore "DefaultMessager.ChatAPI/DefaultMessager.ChatAPI/DefaultMessager.ChatAPI.csproj"
COPY . .
WORKDIR "/src/DefaultMessager.ChatAPI/DefaultMessager.ChatAPI"
RUN dotnet build "DefaultMessager.ChatAPI.csproj" -c Release -o /app/build
RUN dotnet dev-certs https --trust

FROM build AS publish
RUN dotnet publish "DefaultMessager.ChatAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false
RUN dotnet dev-certs https --trust

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publish /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/
ENTRYPOINT ["dotnet", "DefaultMessager.ChatAPI.dll"]