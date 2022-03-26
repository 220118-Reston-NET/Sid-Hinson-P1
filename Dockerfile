#Docker is a bit like a VM
# link from DockerHub, sets the image from image resgistry to use this environment as virtual OS
FROM mcr.microsoft.com/dotnet/sdk:latest AS build

#workdir docker instructions sets the working directory for this OS
#setting the working directory by creating a Folder called "app"
WORKDIR /app

#Copy the relevant solution and project files / CREATE DIRECTORY STRUCTURE
COPY *.sln ./
COPY StoreApi/*.csproj StoreApi/
COPY StoreBL/*.csproj StoreBL/
COPY StoreDL/*.csproj StoreDL/
COPY StoreModel/*.csproj StoreModel/
COPY StoreTest/*.csproj StoreTest/
#Copy all the cs files
COPY . ./

#Create the publish folder by run CLI Comand
RUN dotnet publish -c Release -o publish

# AFter building and publishing app, we need to set environment to runtime to indicate how to run now that its built and published
FROM mcr.microsoft.com/dotnet/aspnet:latest AS runtime
COPY --from=build app/publish ./

# cmd docker instruction for the assembly file needed to run the entry point
CMD ["dotnet", "StoreApi.dll"]

#80 is a good default because kubernetes uses 80 too, 80 is good to remember
EXPOSE 80