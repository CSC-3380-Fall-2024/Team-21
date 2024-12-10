# Team-21
Welcome To the Tiger Tasks Project
For this Project we are using Visual Studio 2022, along with an Azure SQL database 
Follow the steps bellow after cloning the repostiory to run the project 

1.) Once you have cloned the repository in Visual Studio, open the project 
2.) On the right side of the page there should be a window labeled Solution Explorer click on Tiger Tasks SLN file 
3.) If you do not see the soultuion explorer window, go to the top left and click View then click Solution Explorer
4.) After you have opened Tiger Tasks SLn, go to the bottom right of visual studio and click on the bracnh name
5.) This will pull up a small menu, select Remotes and type in origin/Master and select it from the list
6.) Once you are in the master branch go to the top left where it says Git
7.) Click on Git and select the option Pull
8.) Then in the soultion explorer select the Tiger Tasks File, this should unveil all of the folders and files of the project 
9.) Double click the folder labeled "Connected Services" 
10.) Once in this folder you will see a connection called "Secrets.json" click on the three dots to the right and select manage user secrets 
11.) Once inside the file  copy and paste the following creditals inbetween the two curly braces, verify there is nothing else within this file
"ConnectionStrings:DatabaseConnection": "Data Source=tcp:tigertasks2.database.windows.net,1433;Initial Catalog=TigerTasks2Db;User Id=Tester@tigertasks2;Password=DucksAreCool25"
12.) At the top of visual studio there is a green run button with a dropdown, sleect the dropdown and either choose IIS Express or HTTP and then run the program 
13.) Once you have run the program you can create account and login, youll be able to view and create forum posts as well as view others user profiles
14.) Under your own profile button located in the top right you will have access to create/edit your user profile as well as see all of your own Forum Posts
