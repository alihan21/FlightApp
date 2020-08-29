# FlightApp
This flight app is made by Dean and Alihan
## Requirements

Local SQL Server (Management Studio)

Visual Studio 2017 (With an emulator installed)

### Initiliaze project

This project is best run with Visual Studio 2017

### Backend project

1) Once unzipped make sure the devConnection in appsettings.json is set to your local SQL server
2) in the StartUp.cs file, uncomment the last line flightAppInit.Init(); to seed your local database
3) When the application has runned once, you can put this back into comment to speed up the startup process.


### Frontend project

1) In the Package.appxmanifest navigate to the Capabilities and make sure the Location capability is checked.
2) Deploy the frontend application 


## Login Credentials

| Name    | LoginCode (Staff) - Seatnumber (Passenger)    | Flightnumber                        | Role                               |
| :---     | :---     | :---                          | :---                                |
| Dean | 5678 | AT1000 | Staff |
| Alihan | 1234 | BG0800 | Staff |
| Liam | 02A | AT1000 | Passenger |
| Lucas | 04A | AT1000 | Passenger - Traveling together with Jules |
| Jules | 06A | AT1000 | Passenger - Traveling together with Lucas |
| Adam | 05B | BG0800 | Passenger |


