# Team-21
Welcome To the Tiger Tasks Project
For this Project we are using Visual Studio 2022, along with an Azure SQL database 
Follow the steps bellow after cloning the repostiory to run the project 
Note: Will not run correclty On MacOS because of the SQL database
--Must use a windows or linux OS

Download Visual Studio if you dont already have it: https://visualstudio.microsoft.com/downloads/

Before Checking for required packages clone and open the project in visual studio as most of the packages will automatically install

Required Packages:
Microsoft.AspNetCore.Identity.EntityFrameworkCore
Microsoft.AspNetCore.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
Microsoft.AspNetCore.Identity.UI
Microsoft.VisualStudio.Web.CodeGeneration.Design

In order to verify you have these packages:
After you have cloned the repositry and opened it in Visual Studio, open the tools menu and select Nuget Package manager and then select Manage Nuget Package for solutions
This will show you the packages you have installed
If you are missing any go back to tools and select Nuget Package Manager and then select Package Manager Console, Then run one of the following commands for whichever package youre missing

Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design
Install-Package Microsoft.AspNetCore.Identity.UI
Install-Package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore

1.) Once you have cloned the repository in Visual Studio, open the project 
2.) On the right side of the page there should be a window labeled Solution Explorer click on Tiger Tasks SLN file 
3.) If you do not see the soultuion explorer window, go to the top left and click View then click Solution Explorer
4.) After you have opened Tiger Tasks SLn, go to the bottom right of visual studio and click on the branch name
5.) This will pull up a small menu, select Remotes and type in origin/Master and select it from the list
6.) Once you are in the master branch go to the top left where it says Git
7.) Click on Git and select the option Pull
8.) Then in the solution explorer select the dropdown arrow next to Tiger Tasks Folder, this should unveil all of the folders and files of the project 
9.) Double click the folder labeled "Connected Services" 
10.) Once in this folder you will see a connection called "Secrets.json" click on the three dots to the right and select manage user secrets 
11.) Once inside the file copy and paste the following creditals inbetween the two curly braces, verify there is nothing else within this file
"ConnectionStrings:DatabaseConnection": "Data Source=tcp:tigertasks2.database.windows.net,1433;Initial Catalog=TigerTasks2Db;User Id=Tester@tigertasks2;Password=DucksAreCool25"
12.) At the top of visual studio there is a green run button with a dropdown, sleect the dropdown and either choose IIS Express or HTTP and then run the program 
13.) Once you have run the program you can create account and login, youll be able to view and create forum posts as well as view other user's profiles
14.) Under your own profile button located in the top right you will have access to create/edit your user profile as well as see all of your own Forum Posts
