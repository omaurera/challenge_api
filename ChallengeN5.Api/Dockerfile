FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

WORKDIR /app

EXPOSE 80

EXPOSE 443

 

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

COPY ["ChallengeN5/ChallengeN5.Api/ChallengeN5.Api.csproj", "ChallengeN5/ChallengeN5.Api/"]

COPY ["ChallengeN5/ChallengeN5.Application/ChallengeN5.Application.csproj", "ChallengeN5/ChallengeN5.Application/"]

COPY ["ChallengeN5/ChallengeN5.Domain/ChallengeN5.Domain.csproj", "ChallengeN5/ChallengeN5.Domain/"]

COPY ["ChallengeN5/ChallengeN5.Infrastructure/ChallengeN5.Infrastructure.csproj", "ChallengeN5/ChallengeN5.Infrastructure/"]

RUN dotnet restore "ChallengeN5/ChallengeN5.Api/ChallengeN5.Api.csproj"

COPY . .

WORKDIR "/src/ChallengeN5/ChallengeN5.Api"

RUN dotnet build "ChallengeN5.Api.csproj" -c Release -o /app/build

 

FROM build AS publish

RUN dotnet publish "ChallengeN5.Api.csproj" -c Release -o /app/publish

 

FROM base AS final

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "ChallengeN5.Api.dll"]