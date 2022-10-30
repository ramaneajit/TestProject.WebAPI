using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.WebAPI.Controllers;
using TestProject.WebAPI.Models;
using Xunit;

namespace TestProject.Tests
{
    public class AccountsUnitTest
    {
        [Fact]
        public void GetAllAccounts()
        {
            var userController = new AccountsController();
            // Act on Test  
            var response = userController.GetAccounts();
            // Assert the result  

            Assert.True(((OkObjectResult)response).StatusCode == 200);
        }

        [Fact]
        public void CreateUserAccount()
        {
            var userController = new AccountsController();
            // Act on Test  
            AccountDetail accountDetail = new AccountDetail();
            accountDetail.FirstName = "John";
            accountDetail.LastName = "troy";
            accountDetail.EmailAddress = "John@ab.com";
            accountDetail.Mobile = "998899889";
            accountDetail.UserName = "John";
            accountDetail.Password = "Paswd";
            accountDetail.IsActive = true;
            var response = userController.CreateAccount(accountDetail);
            // Assert the result  

            Assert.True(((OkObjectResult)response).StatusCode == 200);
            Assert.True(((OkObjectResult)response).Value.ToString() == "Account created successfully");
        }
    }
}
