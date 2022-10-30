using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TestProject.WebAPI.Controllers;
using TestProject.WebAPI.Models;
using Xunit;

namespace TestProject.Tests
{
    public class UserUnitTest
    {
        [Fact]
        public void UserGetById()
        {
            var userController = new UsersController();
            // Act on Test  
            var response = userController.GetUser(1);
            // Assert the result  
            var result = ((OkObjectResult)response).Value as User;

            Assert.True(((OkObjectResult)response).StatusCode == 200);
            Assert.Equal("John", result.Name);
        }

        [Fact]
        public void GetAllUsers()
        {
            var userController = new UsersController();
            // Act on Test  
            var response = userController.GetUsers();
            // Assert the result  

            Assert.True(((OkObjectResult)response).StatusCode == 200);
        }

        [Fact]
        public void AddUser()   
        {
            var userController = new UsersController();
            // Act on Test  
            User user = new User();
            user.Name = "John";
            user.EmailAddress = "John@ab.com";
            user.Salary = 10000;
            user.Expenses = 5000;

            var response = userController.CreateUser(user);
            // Assert the result  

            Assert.True(((OkObjectResult)response).StatusCode == 200);
            Assert.True(((OkObjectResult)response).StatusCode == 200);
            Assert.True(((OkObjectResult)response).Value.ToString() == "User added successfully");
        }
    }
}
