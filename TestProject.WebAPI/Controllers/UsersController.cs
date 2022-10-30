using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TestProject.WebAPI.DataServices;
using TestProject.WebAPI.Models;
using System.Linq;

namespace TestProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IConfiguration _config;
        private readonly DataAccess dataAccess;
        public UsersController(IConfiguration _configuration)
        {
            _config = _configuration;
            dataAccess = new DataAccess(_config);
        }

        [HttpGet]
        [Route("GetUsers")]
        public ActionResult GetUsers()
        {
            List<User> users = new List<User>();
            string getUsers = string.Format(Constants.GET_ALL_USERS_CMD);
            DataTable dt = dataAccess.GetDataTable(getUsers);
            
            return Ok(dataAccess.GetUsersList(dt));
        }

        [HttpGet]
        [Route("GetUser/{id}")]
        public ActionResult GetUser(int id)
        {
            string getUser = string.Format(Constants.GET_USER_BY_ID_CMD, id);
            DataTable dt = dataAccess.GetDataTable(getUser);
            User user = dataAccess.GetUsersList(dt).Count > 0 ? dataAccess.GetUsersList(dt)[0] : null;
            return Ok(user);
        }

        [HttpPost]
        [Route("CreateUser")]
        public ActionResult CreateUser([FromBody] User user)
        {
            try
            {
                string getUser = string.Format(Constants.GET_USER_BY_EMAILID_CMD, user.EmailAddress);
                DataTable dt = dataAccess.GetDataTable(getUser);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok("User with emailaddress " + user.EmailAddress + " is already exists");
                }
                if (user.Salary <= 0)
                {
                    return Ok("Monthly Salary Must be a positive number");
                }
                if (user.Expenses <= 0)
                {
                    return Ok("Monthly Expenses Must be a positive number");
                }
                string addUser = string.Format(Constants.INSERT_USER_CMD, user.Name, user.EmailAddress, user.Salary, user.Expenses);
                bool isUpdatedData = dataAccess.InsertOrUpdateOrDeleteData(addUser);
                return Ok(isUpdatedData ? "User added successfully" : "Failed to add new user");
            }
            catch (Exception ex)
            {

            }

            return Ok("Failed to add new user");
        }

    }
}
