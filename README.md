Steps To follow
===============

1. The link to the project code can be found in below GitHub link. The solution file resides there. You may download the full folder and open the solution.
https://github.com/SHANIW/TasksRestApi

2. In the above Gitlab repository, please find the SQL script inside the folder DBScripts. 
https://github.com/SHANIW/TasksRestApi/tree/master/DBScripts

First, please run the script  FULL_DB SCRIPT  in SQL server (This script will create the Database, Table, and all StoredProcedures required)
If you wish to insert sample data, you may use the script in the Data_Insert.txt file.

3. Open the project and update the Database Connection String at the appsettings.json file (please replace the existing string value for "TasksDBConnection" )

4. This project was built on .Net 6.0, therefore please make sure you have .Net 6.0 or above.
    You may simply build and run the project on local machine using Visual Studio.

5. When you run the project, the browser will be opened with the Swagger for you to test the api routes easily. Anyway, you may use any other prefered method to test the routs.
