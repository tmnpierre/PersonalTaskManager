# PersonalTaskManager

PersonalTaskManager is a simple and intuitive task management application developed in C# and .NET, featuring a command-line interface (CLI). It enables users to create, update, delete, list, and search personal tasks, offering a clear and easy-to-use user experience.

## Features

- **Adding Tasks**: Allows users to add new tasks with details such as title, description, due date, and priority.
- **Updating Tasks**: Offers the ability to update the details of an existing task.
- **Deleting Tasks**: Enables the deletion of tasks from the list.
- **Listing Tasks**: Displays all recorded tasks with sorting options by due date or priority.
- **Searching Tasks**: Enables searching for tasks by keywords or specific dates.
- **Automatic Saving**: Automatically saves changes to a JSON file after each CRUD operation.

## Quick Start

1. **Installation**:
   Ensure that .NET 6.0 is installed on your machine.

2. **Running the Application**:
   - Clone the repository or download the source files.
   - Open a terminal and navigate to the project directory.
   - Run `dotnet run` to start the application.

## Using Docker

To run the application in a Docker container:

1. Build the Docker image using the command:
   ```
   docker build -t personaltaskmanager .
   ```
2. Run the application in a container:
   ```
   docker run --name personaltaskmanager-container -d personaltaskmanager
   ```