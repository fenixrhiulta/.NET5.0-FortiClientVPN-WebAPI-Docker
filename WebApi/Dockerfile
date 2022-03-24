FROM mcr.microsoft.com/dotnet/sdk:5.0
EXPOSE 80
EXPOSE 443
EXPOSE 5002

ENV ASPNETCORE_URLS=http://+:5002
ENV ASPNETCORE_ENVIRONMENT=Development

RUN mkdir /app

COPY . /app

RUN mkdir /build

RUN cd /app && ls -l
RUN cd /app && dotnet publish WebApi.csproj --self-contained true -r linux-x64 -c $ASPNETCORE_ENVIRONMENT -o /build

RUN cd /build && ls -l
WORKDIR /build

ENTRYPOINT ["./WebApi"]