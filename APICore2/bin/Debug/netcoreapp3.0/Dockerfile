FROM microsoft/dotnet:latest #所需依赖latest 是最新的  也可以写成  microsoft/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app  #容器中系统工作空间
#拷贝当前文件夹下的文件到容器中系统的工作空间（注意：“.”后面有空格）
COPY . ./ 

EXPOSE 80   #对外提供的端口号

#容器中使用 ["dotnet","系统启动的dll"] 来运行应用程序
ENTRYPOINT ["dotnet", "APICore.dll"]

#docker文件必须要与 程序所发布的地址在同级目录；





