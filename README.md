### Reserv3d

Reserv3d is mobile application created with React Native. It allows an end user to search for restaurants in their area and then view the interior of the restaurant. In this view the end user can choose which table they wish to book, this view was built using React360.

The back end for this project is a RESTful API built in the .Net Core framework. It serves up data from a PostgresSQL database and acts as a link between the react native and react360 elements of this project.

The hosted version of this API can be found at:
https://finalproject20190421104640.azurewebsites.net/swagger/index.html

### Running Locally

To run this API locally clone this repository and install PostgresSQL:
https://www.postgresql.org/download/

In the SQL shell that comes with PostgresSQL create a new database using `CREATE DATABASE your_database_name` and then step into this database using `\c your_database_name`

Run the two files in the DBsetup folder in order, change the below commands to match the directory you have saved the repository in:

```
\i C:/Users/Matthew/source/repos/FinalProject/DBsetup/tables.sql

\i C:/Users/Matthew/source/repos/FinalProject/DBsetup/seed.sql
```
Open the FinalProject solution in Visual Studio and in appsettings.Development.json change the below line to match the configuration of your database.

```
  "ConnectionStrings": {
    "Default": "Host=localhost;username=postgres;password=password;Database=bookings_db"
  },
```

Now run the solution in Visual Studio and the swagger user interface should automatically appear in your default browser.
