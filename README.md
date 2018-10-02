Requirements:

Visual Studio 2017 SQL Server 2014 LocalDB (to run locally) or atached database on Server from this Project Folder: "Databases" mdf and ldf file To run the sample locally from Visual Studio:

Firt Edit Web.config file in Project:
  <connectionStrings>
    <add name="MyConnectionString" 
         connectionString="Data Source=SULJO-PC;Initial Catalog=Blog;Integrated Security=true;MultipleActiveResultSets=true" 
         providerName="System.Data.SqlClient" />
  </connectionStrings>
  
  Data Source= Your database server name
  Catalog = Blog

Build the from Visual Studio solution. 

Open the Package Manager Console (Tools > NuGet Package Manager > Package Manager Console) 
In the Package Manager Console window, enter the following command:

Update-Database or 
DELET FROM Project folder Migration and from database all table and run:
enable-migration
add-migration Initial
update-database

Press F5 to debug.
