FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

COPY clipboard-service app
WORKDIR app

EXPOSE 5000

VOLUME logs/

ENTRYPOINT ["dotnet", "clipboard-service.dll", "--urls", "http://0.0.0.0:5000"]