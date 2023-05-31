#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["DefaultMessager/DefaultMessager.csproj", "DefaultMessager/"]
COPY ["DefaultMessager.BLL/DefaultMessager.BLL.csproj", "DefaultMessager.BLL/"]
COPY ["DefaultMessager.DAL/DefaultMessager.DAL.csproj", "DefaultMessager.DAL/"]
COPY ["DefaultMessager.Domain/DefaultMessager.Domain.csproj", "DefaultMessager.Domain/"]
RUN dotnet restore "DefaultMessager/DefaultMessager.csproj"
RUN dotnet dev-certs https --trust

COPY . .
WORKDIR "/src/DefaultMessager"
RUN dotnet build "DefaultMessager.csproj" -c Release -o /app/build
RUN dotnet dev-certs https --trust

FROM build AS publish
RUN dotnet publish "DefaultMessager.csproj" -c Release -o /app/publish /p:UseAppHost=false
RUN dotnet dev-certs https --trust

FROM base AS final
ENV ConnectionStrings__NpgConnectionString="User Id=postgres; Password=Mqesz<\-3H-M%o`]; Server=34.27.29.90; Port=5432; Database=Messager; IntegratedSecurity=true; Pooling=true;"
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publish /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/
ENTRYPOINT ["dotnet", "DefaultMessager.dll"]
