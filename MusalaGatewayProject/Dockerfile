FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY bin/release/net5.0/publish/ MusalaGatewayProject/
WORKDIR /MusalaGatewayProject
ENTRYPOINT ["dotnet", "MusalaGatewayProject.dll"]