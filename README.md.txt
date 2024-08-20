# KrispyKreme1

KrispyKreme1 is an ASP.NET MVC application that manages donut sales. This project demonstrates the use of MVC architecture, Entity Framework, and various other ASP.NET features.

## Table of Contents

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)

## Getting Started

These instructions will help you set up the project on your local machine for development and testing purposes.

## Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/)
- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Run the attached database scripts to create the database and tables to be used by the app.

## Installation

1. **Clone the repository:**

2. **Open the solution in Visual Studio:**

    Open `KrispyKreme1.sln` in Visual Studio.

3. **Restore NuGet packages:**

    Visual Studio should automatically restore the required NuGet packages. If not, go to `Tools` > `NuGet Package Manager` > `Manage NuGet Packages for Solution...` and restore the packages.

4. **Update the database connection string:**

    Update the connection string in `Web.config` to point to your SQL Server instance.


5. **Run the application:**

    Press `F5` to build and run the application.

## Usage

- **Home Page:** Displays the home page.
- **Store Page:** Allows users to submit a sale.
- **Dashboard:** Displays sales data.
- **Successful Sale Page:** Displays a confirmation message after a successful sale.

## Project Structure

- **Controllers:** Contains the controllers for handling HTTP requests.
- **Models:** Contains the data models and view models.
- **Views:** Contains the Razor views for rendering HTML.
- **Scripts:** Contains JavaScript files.
- **Content:** Contains CSS files.
