namespace TestProject.WebAPI
{
    public class Constants
    {
        //public static string GET_ALL_USERS_CMD = "SELECT * FROM Users ORDER BY Id ASC";
        public static string GET_ALL_USERS_CMD = "SELECT Id, Name, EmailAddress, MonthlySalary, MonthlyExpenses FROM Users ORDER BY Id ASC";
        public static string GET_USER_BY_ID_CMD = "SELECT  Id,Name,EmailAddress,MonthlySalary,MonthlyExpenses FROM Users WHERE Id={0} ORDER BY Id ASC";
        public static string GET_USER_BY_EMAILID_CMD = "SELECT  Id,Name,EmailAddress,MonthlySalary,MonthlyExpenses FROM Users WHERE EmailAddress='{0}' ORDER BY Id ASC";
        public static string INSERT_USER_CMD = "INSERT INTO `users`(`Name`, `EmailAddress`, `MonthlySalary`, `MonthlyExpenses`) VALUES('{0}','{1}','{2}','{3}')";
        
        public static string GET_ALL_ACCOUNTS_CMD = "SELECT Id, FirstName, LastName, EmailAddress, MobileNo,MobileNo,UserName,Password,IsActive FROM accounts ORDER BY Id ASC";
        public static string INSERT_ACCOUNTS_CMD = "INSERT INTO `accounts`(`FirstName`, `LastName`, `EmailAddress`, `MobileNo`, `UserName`, `Password`, `IsActive`) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
    }
}
