# CitizenReportingApp

## Table of Contents
1. [Introduction](#introduction)
2. [Features](#features)
3. [System Requirements](#system-requirements)
4. [Installation](#installation)
5. [Usage](#usage)
6. [Application Workflow](#application-workflow)
7. [Troubleshooting](#troubleshooting)
8. [Contributing](#contributing)
9. [License](#license)

---

## Introduction

The **Citizen Reporting App** is a WPF (Windows Presentation Foundation) desktop application that allows citizens to report issues to their local municipality. This application provides a streamlined interface for users to submit reports on infrastructure problems, sanitation issues, and other service-related requests. It enables a strong engagement between citizens and their local government by making it easy for users to submit reports and receive feedback.

The app is built with C# and WPF, with reports stored in individual text files, allowing municipalities to access and handle each report efficiently.

---

## Features

- **Report Issues**: Citizens can submit issues by entering details such as location, category, and a description. Media files (e.g., images) can be attached to support the report.
- **Back to Main Menu**: Users can navigate back to the main menu after submitting their report.
- **Issue Summary**: After submitting a report, a summary of the submission is displayed on the screen.
- **File-Based Storage**: Each report is saved as an individual text file with a unique name for easy identification and future processing.

---

## System Requirements

- **Operating System**: Windows 7 or later
- **.NET Core SDK**: Version 3.1 or later
- **Visual Studio**: Any recent version with WPF and .NET Core support (e.g., Visual Studio 2019 or 2022)
- **Memory**: At least 4GB of RAM
- **Disk Space**: At least 100MB of free space

---

## Installation

### Prerequisites
1. **.NET Core SDK**: Install from the official .NET website: https://dotnet.microsoft.com/download/dotnet/3.1
2. **Visual Studio**: Ensure WPF development support is enabled in your Visual Studio installation.

### Steps to Set Up and Compile
1. **Clone the repository**:

   https://github.com/SamuelNkomo/CitizenReportingApp.git
   
3. **Open the solution in Visual Studio**:
   - Open **Visual Studio**, and go to **File > Open > Project/Solution**.
   - Navigate to the folder where the project is located, and open the `.sln` file.

4. **Build the solution**:
   - In **Visual Studio**, press **Ctrl + Shift + B** to build the solution.
   - Ensure there are no errors before running the application.

5. **Run the application**:
   - Press **F5** or click **Debug > Start Debugging** to run the app.

---

## Usage

### Main Menu
Upon starting the application, the user is presented with the main menu:
- **Report Issues**: Takes you to the page where you can submit a new issue report.
- **Local Events** and **Service Request Status** are disabled in this version but can be implemented in future releases.

### Reporting an Issue
1. **Click "Report Issues"** to navigate to the issue reporting page.
2. **Fill in the details**:
   - **Location**: Enter the location where the issue occurred.
   - **Category**: Choose a category from the dropdown (e.g., Sanitation, Roads, Utilities).
   - **Description**: Provide a detailed description of the issue.
   - **Attach Media**: Attach any relevant media (such as photos) to the report.
3. **Submit the Report**: Click the **Submit** button to send the report.
4. **Confirmation**: A summary of the submitted report will be displayed on the screen.
5. **Return to Main Menu**: After submitting, you can click the **Back to Main Menu** button to return to the main menu.

### Report Storage
- Each submitted report is saved as a text file in the application’s working directory.
- The files are named based on timestamps for uniqueness (e.g., `Issue_637489302541235679.txt`).

---

## Application Workflow

1. **Start the Application**: The main menu appears, offering a choice to report an issue.
2. **Navigate to "Report Issues"**: Users can provide details about the issue and attach media if necessary.
3. **Submit the Report**: After submitting, the details are saved in a `.txt` file.
4. **Display Summary**: The app shows a summary of the submission for the user to review.
5. **Return to Main Menu**: Users can go back to the main menu and submit additional reports.

---

## Troubleshooting

### Common Issues
1. **Application Fails to Start**:
   - Ensure that .NET Core SDK is installed properly.
   - Rebuild the solution in Visual Studio.

2. **Unable to Attach Media**:
   - Ensure the file type is supported (JPEG, PNG, etc.).
   - Try using smaller files if the problem persists.

3. **Report Not Saving**:
   - Check your disk permissions to ensure the application can write files.
   - Verify that there’s enough disk space available on your system.

---

## Contributing

We encourage contributions to improve the Citizen Reporting App! Feel free to fork the repository, make feature suggestions, or submit pull requests for bug fixes and enhancements.

---

## License

This application is licensed under the [MIT License](https://opensource.org/licenses/MIT).

---

### Author's Note
This application is aimed at improving communication between citizens and municipalities. By allowing easy reporting and tracking of issues, we hope to contribute to more responsive and transparent local governance. We welcome feedback from both users and developers to make this tool even better.
