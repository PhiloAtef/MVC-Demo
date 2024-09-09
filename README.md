All in .net 5
create PL, DAL AND BLL projects in solution 

add refrence in dependencies to the projects so DAL=referenced in=> BLL => referenced in PL

add Data, Models folders in DAL 

create BOCO class in models 

add folder in Data called configurations and create class configurations that inherits IEntityTypeConfiguration interface with type <targeted class>

then in Data, Add the database context
and do your onconfiguring and onmodelcreating overrides (subject to change later due to how cumbersome it is and that i know there is a different way to do this)
(dont forget to add dbsets)

business logic layer
============

can either use (generic) repository design pattern or unit of work

we will use non-generic repository design pattern for now

first step: interfaces and repositories folder in BLL

We have interfaces in repositories because what if we have more than 1 DB or more than 1 way
of communicating with the DB, so we would have only 1 interface with the 5 main actions (add,
delete, update .. etc.) and we could have multiple implementations to those interfaces.
We can add which implementation to use during dependency injection.

Dependency Injection (DI)
=======================

Dependency Injection is when we let the framework be responsible for creating the objects and
managing their life cycles rather than manually creating the objects and having to manage all of
the references on our own.

We have 3 functions to register dependencies, and they differ from each
other based on the lifecycle of the object

● AddSingleton => the object is created once and each object that requires a reference of
the created object we pass the same reference, lasts for the lifetime of the application
itself.
● AddScoped => lasts per request, meaning if one request for example has a lot of actions
(add, update, delete) we use the same object to do all of these actions.
● AddTransient => per operation, meaning if one request for example has a lot of actions
(add, update, delete) we use a new instance for each action.

Dynamic Connection String
========================
By Adding the “ConnectionStrings” object in the appsettings.json, we can define multiple DB
connection strings to connect to



