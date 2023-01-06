#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Blog.WebAPI/Blog.WebAPI.csproj", "Blog.WebAPI/"]
COPY ["Blog.Service/Blog.Service.csproj", "Blog.Service/"]
COPY ["Blog.Repository/Blog.Repository.csproj", "Blog.Repository/"]
COPY ["Blog.Model/Blog.Model.csproj", "Blog.Model/"]
COPY ["Blog.Common/Blog.Common.csproj", "Blog.Common/"]
RUN dotnet restore "Blog.WebAPI/Blog.WebAPI.csproj"
COPY . .
WORKDIR "/src/Blog.WebAPI"
RUN dotnet build "Blog.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Blog.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blog.WebAPI.dll"]