# Birth_Clinic


The project is a C# Console Application, using a class library that holds all the models required for the project. 
Made for the DAB course by Jakob, Marius and Emil. 

## Overview of the project ## 

The solution has 2 projects, the Application and Library. They hold all the classes, methods and context, to provide the end result. 


Below, a quick guide will walk you through set-up and interaction with the solution.

## How to use the solution ##
1. Clone the project using git clone <project-.path.git> OR open it after downloading the zip
2. Open the solution in visual studio. 
3. Replace the string at the bottom of "Program.cs", with your connection string. 
4. Run the application, remember to set "Application" as Start-up project.
5. Using the ASCII-menu, navigate through to the desired point of information.
6. Press "esc" to exit from sub-menu to the front-menu.
7. Look through the data, until done.



## Notes on the solution ##
Please note that running the program generates the dummy data for the database. 
This can result in some births not being planned within the next 5 days, as the days generated are set randomly. 
To combat this, delete the database and tables, and run the program again.

Use this command to do it quick-and-easy:  
USE master;  
GO  
ALTER DATABASE myDb  
SET SINGLE_USER  
WITH ROLLBACK IMMEDIATE;  
GO  
DROP DATABASE myDb;  
