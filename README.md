# Drones Service

## Developer Instalation Guide

1. Clone this repository

2. Download and install Visual Studio version 17.5.5 or superior
    - Select and install the workloads:
        - ASP.Net and web development
        - .Net Core cross-plataform development

### Build and Run

#### In Visual Studio

- Open the **Drones.sln** file
- Set project Drones.csproj as startup project
- Press **F5** key

#### Outside Visual Studio

- Go to the folder that contains the **Drones.csproj** file
- Open a command console in this folder **(./Drones/Drones/Drones.csproj)**
- Run the command:

     ``` 
     dotnet run .\Drones.csproj
     ```


You should see the following after dotnet run
 ``` 
    Hosting starting
    Now listening on: "http://localhost:5133"
    Loaded hosting startup assembly "Drones"
    Hosting environment: "Development"
    Hosting started
```

### Usage

To communicate with the service you can use **Postman** or **Swagger**

#### Postman

- Download the latest version Postman
- Open Postman app and go to **File -> Import** and select the file: **DronesTest.postman_collection.json**
    - This file contains the expamples to test the service

#### Swagger

- Open the url http://localhost:5133/Swagger on the browser

## API
The solution has 2 projects: Drones and Drones.Model

### Drones
- ASP.Net Core Web Api Service that contains the bussiness logic

#### Structure
- Controllers: Contains the service endpoints
    - RegisterDrone: register a drone
    - GetDronBatteryLevel: gets the battery level for a drone
    - ChangeDroneState: change state for a drone
    - GetAvailableDronesForLoading: gets the available drones for loading
    - GetDrones: gets all the drones
    - RegisterMedication: register a medication
    - RegisterLoad: register a load for a drone
    - GetDroneLoadedMedications: gets the loads for a drone
- Extensions: Contains the drone and medication classess extensions
- Jobs: Contains a periodic task that is executed in background
    - CheckDronesBatteryLevelHostedService: checks the battery level of all drones and create a history/audit event log
- Logs: Contains the logs files generated by the service
- Mapper: Contains the mapper between the database entities and service models
- Models: Contains the models service
- Services: Contains the service that execute the controller logic
- Upload: Contains the uploaded files for medication
- Validations: Contains the custom validations for specific properties
- appsettings.json: Contains the service logs setting 
- Program.cs: Contains the startups logics


### Drones.Model
- Class library that contains the database logic
- Database: Microsoft.EntityFrameworkCore.InMemory

#### Structure
- Context: Contains the DronesDbContext for access to the database
- Entities: Contains the models in the database (Drone, Medication, Load, EntityBase)
- Repository: Contains the repository pattern logic


## Author

Diana Cardoso Abio / <cardosodiana6@gmail.com>
