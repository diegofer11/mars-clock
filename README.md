# Mars Clock

A Blazor application that displays the current time on Mars alongside Earth time. The application uses a timer to update the displayed times every second.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Running the Application](#running-the-application)
- [Contributing](#contributing)
- [License](#license)

## Features

- Displays the current Earth date and time in UTC.
- Computes and displays various Mars time metrics, including:
  - Mars Sol Date (MSD)
  - Coordinated Mars Time (CMT)
  - Julian Date (UT and TT)
  - Days since J2000 Epoch
  - Mars Mean Anomaly and more.
- Updates every second using a timer.

## Technologies Used

- [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) - A framework for building interactive web UIs using C#.
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) - The programming language used to build the application.
- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet) - The web framework for building the application.

## Getting Started

### Prerequisites

Before you can run the application, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 5.0 or later)

### Clone the Repository

```bash
git clone https://github.com/diegofer11/mars-clock.git
cd mars-clock
