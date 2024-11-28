# Csharp-ORM

## Purpose

Csharp-ORM is a simple Object-Relational Mapping (ORM) project built in C# to enhance my skills and understanding of Object-Oriented Programming (OOP) concepts in C#. The project implements core ORM features like querying, inserting, updating, and deleting objects while providing a basic framework for interacting with data in an object-oriented manner. This project is a learning tool and does not use external database systems, but instead focuses on in-memory data management.

## Project Structure

This project is organized as follows:

```
├── src
    ├── Core
    │   └── Query.cs
    ├── Models
    │   ├── Model.cs
    │   ├── Models.cs
    │   └── User.cs
    ├── Program.cs
```

### Breakdown of the `src/` Folder:

- **Core/**  
  - `Query.cs`: Contains the `Query<T>` class, responsible for handling in-memory querying operations (like sorting, filtering, updating, etc.) for data objects. This is a core component of the ORM functionality.

- **Models/**  
  - `Model.cs`: The base class that all data models (such as `User`) inherit from. This can be expanded to include common properties or methods for all models.
  - `Models.cs`: A central class managing multiple models and their interactions with the ORM system.
  - `User.cs`: Represents a user model with properties such as `Name`, `Email`, and `Id`. This model is used to demonstrate how the ORM handles data objects.

- **Program.cs**  
  The entry point of the program, where the `Models` class and `Query<T>` operations (like `insert`, `update`, `delete`, and `sortBy`) are demonstrated with the `User` model.

## Features

- **Insert Data**: Add new objects to the in-memory store.
- **Delete Data**: Remove objects from the in-memory store by ID.
- **Update Data**: Modify objects by ID using provided actions.
- **Query Data**: Filter data using `where` clauses and sort the data with `sortBy`.
- **In-memory Data Storage**: The ORM operates entirely in memory for demonstration purposes, with no external database involved.

## Getting Started

1. Clone this repository to your local machine. `git clone https://github.com/whilmarbitoco/CSharp-ORM.git`
2. Open the project in your preferred C# IDE (e.g., Visual Studio or Visual Studio Code).
3. Build and run the project by executing the `Program.cs` file.

## Purpose of the Project

The primary purpose of this project is to:

- **Enhance My Skills in C# OOP**: To Gain hands-on experience with object-oriented programming concepts like inheritance, encapsulation, and polymorphism in C#.
- **Learn ORM Concepts**: To Implement basic ORM functionalities such as querying, updating, and deleting data objects in a simulated environment.
- **Strengthen My Understanding of Data Structures**: To Understand how to manage and manipulate data in memory through custom-built query methods.

## Tutorial: Using the `Query<T>` Class

In this section, we’ll break down the common query operations available in the `Query<T>` class.

### 1. Inserting Data

To insert data, we use the `insert()` method. This method adds a new object to the in-memory collection and automatically assigns it a unique ID.

```csharp
User u = new User("John", "john@john.com");
models.MUser.insert(u);
```

- **How it works**:  
  The `insert()` method sets a new `Id` for the `User` object and adds it to the `Data` list.

### 2. Deleting Data by ID

To delete a specific object by its ID, we use the `deleteById()` method.

```csharp
models.MUser.deleteById(1);
```

- **How it works**:  
  The `deleteById()` method searches for the object by its `Id`, and if found, it removes it from the list of objects.

### 3. Updating Data by ID

To update an object by its ID, we use the `updateById()` method. You provide an `Action<T>` that modifies the object.

```csharp
models.MUser.updateById(2, u => u.Name = "Updated Name");
```

- **How it works**:  
  The `updateById()` method finds the object by its `Id` and then applies the provided update action (e.g., changing the `Name` property).

### 4. Querying Data with `where`

The `where()` method allows you to filter the data based on a provided predicate (a condition).

```csharp
models.MUser.where(u => u.Name.StartsWith("J"));
```

- **How it works**:  
  The `where()` method filters the list based on the condition inside the predicate. In this case, it returns all `User` objects whose `Name` starts with "J".

### 5. Sorting Data with `sortBy`

The `sortBy()` method allows you to sort the data by a specific key. You can sort in ascending or descending order.

```csharp
models.MUser.sortBy(u => u.Name, ascending: true);
```

- **How it works**:  
  The `sortBy()` method sorts the data by the specified key (e.g., `Name`). If `ascending` is set to `true`, it sorts in ascending order; otherwise, it sorts in descending order.

### 6. Fetching All Data

To retrieve all the data from the collection, use the `findAll()` method.

```csharp
var allUsers = models.MUser.findAll();
```

- **How it works**:  
  The `findAll()` method simply returns all the objects currently in the `Data` collection.

### 7. Finding Data by ID

To find a specific object by its ID, use the `findById()` method.

```csharp
var user = models.MUser.findById(0);
```

- **How it works**:  
  The `findById()` method searches for an object by its `Id`. If found, it returns the object; otherwise, it returns `null`.

### 8. Using `getResult()` for Non-Persistent Operations

The `getResult()` method allows you to retrieve the results after performing any query operation like filtering or sorting. This method does not modify the original data and returns the processed data for use.

```csharp
var result = models.MUser.sortBy(u => u.Name).getResult();
```

- **How it works**:  
  The `getResult()` method returns the data as it stands after any query operations like `sortBy` or `where`. It doesn’t affect the underlying data in the ORM, making it a non-persistent operation. This is useful when you want to perform temporary operations on data without changing the original dataset.
