
## Name of Project:
Virtual Pet Adoption Center

## Description:
The Virtual Pet Adoption Center is an online platform where users can adopt and care for digital pets virtually. Users can interact with their pets by feeding, grooming, and engaging in various activities. The platform aims to provide a realistic and engaging experience for users who want to experience the joys of pet ownership without the responsibilities of a physical pet.

## Author
Yana Mykhailova 
yanamyh2005@gmail.com
https://t.me/@xupqlxbs

## Project Documentation

## Prerequisites

- Windows operating system
- Visual Studio or any other IDE that supports C# and JavaScript
- A GitHub account

## Installation

1. Clone the repository from GitHub. Open your terminal and run:

git clone https://github.com/REPS0LL/Mykhailova.University.VirtualPetAdoptionCenter.git

2. Open the project in Visual Studio or your preferred IDE.
3. Build the project. In Visual Studio, you can do this by clicking `Build > Build Solution`.

## Running the Application

1. Set `VirtualPetAdoptionCenter.Web` as the startup project.
2. Run the application. In Visual Studio, you can do this by clicking `Run > Start Debugging`.

# Project Architecture

The project is structured into two main parts: the front-end and the back-end.

## Front-End

The front-end is built with Razor Pages, HTML, and CSS. The CSS files are located in the `VirtualPetAdoptionCenter.Web/wwwroot/css` directory. The main CSS file is `Site.css`, which contains the styles for the entire application.

## Back-End

The back-end is built with C#. It follows a service-oriented architecture, with services handling the business logic of the application. The services are located in the `VirtualPetAdoptionCenter.Core/Services` directory.

The `AccountService` is responsible for user registration and authentication. It uses an `IEncryption` service for password encryption and an `IEmailService` for sending registration emails.

The `PetService` is responsible for managing the pets in the application. It handles operations such as creating, updating, and deleting pets, as well as retrieving pet information.

The `Groomservice` is responsible for managing the grooming activities of pets in the Virtual Pet Adoption Center application.


## Database

The application uses a relational database managed by Entity Framework. The `VirtualPetAdoptionCenterDbContext` class is responsible for interacting with the database. The database schema is defined by the `UserModel` class.


![333333](https://github.com/REPS0LL/Mykhailova.University.VirtualPetAdoptionCenter/assets/161017521/e795244a-2770-4eac-81b7-13e4be51df83)



## Project Task Decomposition

### Week 1:
- Implement user registration and authentication with Google account.✔️
- Set up basic project structure and environment in Azure.✔️
- Create initial database schema for user accounts and pet information.✔️
- Develop landing page and user dashboard UI components.✔️
- Write unit tests for user authentication functionality.

### Week 2:
- Implement virtual pet adoption feature.✔️
- Integrate email sending functionality for welcome messages upon successful registration.✔️
- Design and implement feeding and nutrition features for virtual pets.✔️
- Set up continuous integration and continuous delivery pipeline in Azure DevOps.
- Write unit tests for virtual pet adoption and feeding functionality. ✔️

### Week 3:
- Develop grooming and care features for virtual pets. ✔️
- Implement interactive activities such as playing, walking, and teaching tricks.
- Create UI components for pet health monitoring and status display.
- Write unit tests for grooming and interactive activity features.
- Begin documentation for getting started and project architecture.✔️

### Week 4:
- Implement virtual environment customization options. ✔️
- Develop community interaction features, including forums and chat functionality.
- Integrate achievement and rewards system based on user interactions. ✔️
- Write unit tests for virtual environment customization and community interaction features.
- Continue documentation for project architecture and tasks decomposition. ✔️

### Week 5:
- Implement notification system for users to receive updates and alerts. ✔️
- Develop support center with ticketing system for user assistance.
- Design and implement admin panel for managing pet listings and user accounts.
- Write unit tests for notification system and support center features.
- Complete documentation for project architecture and tasks decomposition. ✔️

### Week 6:
- Perform integration testing for all implemented features.
- Conduct user acceptance testing to gather feedback and identify any necessary improvements.
- Address any bugs or issues discovered during testing phase.
- Finalize documentation for getting started and project architecture.✔️
- Prepare for project deployment to production environment.

### Week 7:
- Deploy project to Azure production environment. ✔️
- Perform final testing and validation in production environment.
- Monitor system performance and address any deployment-related issues.
- Prepare for project launch and promotion.
- Begin planning for future feature enhancements and updates. ✔

