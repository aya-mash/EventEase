# EventEase Admin

This is an admin dashboard for managing Venues, Events, Bookings, and Customers.

<img width="3840" height="3376" alt="ST10499520" src="https://github.com/user-attachments/assets/154a35a0-376e-497c-bd83-9afd61bcc99e" />


## Getting Started

1. **Clone the repository:**
   ```
   git clone https://github.com/aya-mash/EventEase.git
   ```
2. **Configure the database connection:**
   - Edit `EventEaseAdmin/appsettings.json` and update the `DefaultConnection` string with your Azure SQL Database credentials.

3. **Apply migrations and update the database:**
   - Open a terminal in the project directory and run:
     ```
     dotnet ef database update --project EventEaseAdmin/EventEaseAdmin.csproj --startup-project EventEaseAdmin/EventEaseAdmin.csproj
     ```

4. **Run the application:**
   - In the project directory, run:
     ```
     dotnet run --project EventEaseAdmin/EventEaseAdmin.csproj
     ```
   - Or use Visual Studio to start debugging.

5. **Access the admin dashboard:**
   - Open your browser and go to `https://localhost:5001` (or the port shown in your terminal).
   - Use the navigation links on the homepage to manage Venues, Events, Bookings, and Customers.

## Features
- Full CRUD (Create, Read, Update, Delete) for Venues, Events, Bookings, and Customers
- Entity Framework Core with Azure SQL Database
- Razor Pages UI

## Troubleshooting
- If you cannot connect to the database, verify your connection string and Azure SQL firewall settings.
- Make sure you have run all migrations before starting the app.

## Requirements
- .NET 8 SDK
- Access to an Azure SQL Database

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
This project is licensed under the MIT License.
