# User API Dev Guide
User Api's
Get Users
GET- https://localhost:44350/api/Users/GetUsers

Get User By id
GET- https://localhost:44350/api/Users/GetUser/1

Create User
Post- https://localhost:44350/api/Users/CreateUser
	{
    		"Name":"abc",
    		"EmailAddress":"abc@lk.com",
    		"Salary":3000,
    		"Expenses": 2000
	}

Accounts API
GetAccounts
GET- https://localhost:44350/api/Accounts/GetAccounts

Create Account
POST- https://localhost:44350/api/Accounts/CreateAccount
{
    "FirstName":"abc",
    "LastName":"xyz",
    "UserName":"abc11",
    "Password": "abc11",
    "Mobile":"909090067",
    "EmailAddress": "abc@lk.com",   
    "IsActive":true
}


## Building

Create mysql database with name mysqltestdb

 create tables in mysqltestdb databse
CREATE TABLE accounts (
     Id INT NOT NULL AUTO_INCREMENT,
     FirstName VARCHAR(250) NOT NULL,
     LastName VARCHAR(250) NULL,
     EmailAddress  VARCHAR(250),
     MobileNo VARCHAR(50) NULL,
     UserName VARCHAR(50) NOT NULL,
     Password VARCHAR(50) NULL,
     IsActive BIT,
     PRIMARY KEY (Id)
)

CREATE TABLE users (
     Id INT NOT NULL AUTO_INCREMENT,
     Name VARCHAR(250) NOT NULL,    
     EmailAddress  VARCHAR(50) NULL,
     MonthlySalary INT NULL,
	 MonthlyExpenses INT NULL,   
     PRIMARY KEY (Id)
)

update correct connection string in appsettings 

Run the project TestProject.WebAPI

## Testing

Run the test cases from Test Explorer

## Deploying

## Additional Information