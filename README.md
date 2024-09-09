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
