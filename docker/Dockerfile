FROM mcr.microsoft.com/dotnet/aspnet:5.0

COPY clipboard-service app
WORKDIR app

EXPOSE 5000

VOLUME logs/

ENTRYPOINT ["dotnet", "clipboard-service.dll", "--urls", "http://0.0.0.0:5000"]