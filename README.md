# Tavern

Tavern is the start of an RPG tracking system for board games and tabletop RPGs. Partially an experiment in architecture design. 

### Dependencies

- AdventureWorks2016 Database
  - [Github Source](https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/adventure-works)
  - [Documentation](https://dataedo.com/download/AdventureWorks.pdf)
- [Automapper](https://github.com/AutoMapper/AutoMapper)
- .NET Core 2.1

### Terms

Term | Meaning |
--- | --- |
Domain | For this example, synonymous with Database. Contains the Database Tables as DomainEntities |
Entity / DomainEntity | Synonymous with the Database Table. Ex: `Customer` and `Address` Entities and Tables are separate |
Model | The data as it is needed by a consumer of the data, usually a service. Ex: A combined `CustomerWithAddressModel` |
Repository | A wrapper around the Domain. Provides ETL / Mapping logic for Entity <-> Domain translations. |
Service | Contains Business Logic about a specific Model. Potentially composited of multiple Repositories. |



## Architecture Layers

This pattern is loosely based on [this article.](https://www.c-sharpcorner.com/article/onion-architecture-in-asp-net-core-mvc/)

### Domain Layer
#### Responsible For: Defining the Tables/Entities (Data At-Rest)

The Source of Truth or System of Record. The database definition. For the purpose of this project, it is an EntityFrameworkCore DbContext with each SQL Schema represented by an associated folder and namespace. This enables Code-First to be used going forward, or you can continue with Database-First. This layer is similar to the traditional DAL or Data Access Layer, though stripped down.

- Only define _what_ the Database Entities (tables) look like
- _Do not_ define how the database interacts with data (BLL)
- Only the Repository Layer should know about anything in this layer.

### Repository Layer
#### Responsible For: Transforming the Data from At-Rest Entity to In-Use Models

This layer provides an abstraction between the data at rest (in the Database) and in use (in the Application Services layer). AutoMapper is used to provide a streamlined way of defining data projections of Entities over Models. 

- Provide a repository pattern over the Domain Layer
- Handle mapping or ETL logic
  - Transform data form "At-Rest" to "In-Use" formats, and vice-versa
- Dependent on Domain Layer
- Only the Services Layer should be dependent on this layer.

### Service Layer
#### Responsible For: Data Mutation / Business Logic

Provides services that map one-for-one to business use cases. This layer may use compositional inheritance to provide a facade to multiple Repositories. This layer is synonymous with the traditional BLL or Business Logic Layer. 

- Isolate Business Logic (how something is done)
- Provide a flexible extension point for additional business logic / requirements
- Provide a generic fallback service with simple CRUD operations
- ToDo: Explore functional programming concepts in this layer particularly

### UI Layer
#### Responsible For: Data Presentation and User Input

Currently targeting a RESTful API, following these guidline documents:

- [API Design Cheat Sheet](https://github.com/RestCheatSheet/api-cheat-sheet#api-design-cheat-sheet)
- [Platform Building Cheatsheet](https://github.com/RestCheatSheet/platform-cheat-sheet#platform-building-cheat-sheet)

