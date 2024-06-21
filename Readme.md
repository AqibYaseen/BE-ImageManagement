Project Name
This project is a .NET Core application that [briefly describe what the project does].

Prerequisites
Before running this project, ensure you have the following installed on your machine:

.NET Core SDK version 8.0 or higher
Visual Studio (recommended) or any other IDE of your choice
Getting Started
Follow these steps to get the project up and running on your local machine:

Step 1: Clone the Repository
Clone the repository to your local machine using Git:

git clone https://github.com/AqibYaseen/BE-ImageManagement
cd yourproject

Step 2: Open the Solution
Open the solution file (YourSolution.sln) in Visual Studio.

Step 3: Set the Startup Project
Set the startup project to the desired project in your solution (usually the one with the .csproj file).

Step 4: Check Port Configuration
Ensure the port number configured in your application matches the port number expected by your Angular project. This configuration is typically found in the environment settings (appsettings.json, launchSettings.json, etc.).

Step 5: Run the Project
Press F5 or click on the "Start" button in Visual Studio to build and run the project.

The application will start, and you will see output in the Visual Studio console.

Step 6: Access the Application
Open your web browser and navigate to http://localhost:{port_number} to view the running application.

Additional Notes
This project uses .NET Core version 8.0.
Data is saved locally using a JSON file.
Modify app settings or connection strings in appsettings.json or launchSettings.json as needed.
Ensure compatibility of port numbers between this backend and your Angular frontend for seamless integration.