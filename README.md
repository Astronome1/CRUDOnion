# MinimalApi with onion architecture Template Project 

## A fully template project written in c# and the dotnet Framework demonstrating and being a starting point for creating projects with the Onion architecture

This project is a template that was created by refactoring an existing [project](https://github.com/Astronome1/CRUDMinimalApi) to make sure the backend adheres to the onion architecture[check link](https://codewithmukesh.com/blog/onion-architecture-in-aspnet-core/). Simple CRUD operations are performed on a User object using the Dapper ORM.

## How to get started with this template project 

It is recommended that you use Visual Studio for this project but feel free to use any IDE you are comfortable with

1. Clone this project 
2. Open the project in visual studio 
3. Publish the database project to your database of choice(MSSQL, MySQL, Postgres)
4. Set the MinimalApi project in the solution as your startup project.
5. Add your connection string to appsettings.json under Default  ![appsettingsfile](https://github.com/Astronome1/CRUDOnion/blob/master/appsettings.PNG)
6. Run the project by using the "dotnet run" command or click the run button on your IDE.
7. Click on the different REST operations in the swagger UI and try it out to see operations happening.

## The logic behind this refactoring and more explanation on the project

* The project is refactored to make sure there is minimal coupling between the different parts of the project.
You can see that the project is divided into different parts following the onion architecture. The Core folder contains your Domain and service layer while the Infrustructure folder contains your Persistence layer(and if you had a normal API project the Presentation layer would also be here).
<br />

* In the Core you have different class libraries: Contracts, Domain, Service, Service.Abstractions. 
The Domain class library is the innermost layer of the onion and this contains your most important entities(models), commonly referred to as core models. The Domain class also has the Repository folder which has the interfaces with the definition of the methods which can make changes to the core entity. In this repository that is the IUserCrudOperationsRepository. The Repository folder under the Domain layer also has the IRepositoryManager whose function is to create an instance of an object that implements the interface which in this case is the IUserCrudOperationsRepository.
<br />

* The Contracts class library contains a dto(similar to our user model) which we will use to pass data to our frontend, thus not exposing our domain model to the frontend.
<br />

* The Services.Abstractions library contains the interfaces that define methods which are going to be exposed to the frontend(our minimalApi project). The IUserService contains these methods and uses the UserInfoDto and not the UserModel to avoid making changes to our core model. The IService Manager serves the same purpose as the IRepositoryManager which is to create an object of an instance of the IUserService interface when needed.
<br />

* The Services folder implements the interfaces which were defined in the Service.Abstraction library and clearly defines the logic of the methods. In this case what this does is Adapt(map) the logic(methods) that will be accessed by the frontend to the logic(methods) that actually make changes to the core models. They also map the UserInfoDto to the UserModel.
<br />

* The Persistence Library under the Infrustructure layer allows for changes that you make to actually persist to the core domains. This is where database calls are made and queries are actually run. The RepositoryManager is also here and that implements the IRepositoryManager repo and now defines a few additional things to do when creating an instance of the IUserCrudOperationsRepository. First it lazily creates an instance of the Repository as a field. There is also a constructor that takes in a configurations(To be able to get the connection string in the Repository when it is called). The value of the UserCrudOperationsRepository is then set to the field _userCrudOperationsRepostitory.
<br />

* The MinimalApi contains the logic needed to see the User Object and contains all the necessary methods: GET, POST, DELETE, PUT. At the onset of the project we inject the service manager and the repository manager interfaces with their corresponding types to be able to access the backend. 
