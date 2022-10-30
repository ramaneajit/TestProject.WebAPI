using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using TestProject.WebAPI.DataServices;
using TestProject.WebAPI.Models;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly DataAccess dataAccess;
        public AccountsController(IConfiguration _configuration)
        {
            _config = _configuration;
            dataAccess = new DataAccess(_config);
        }

        [HttpGet]
        [Route("GetAccounts")]
        public ActionResult GetAccounts()
        {
            string getAccounts = string.Format(Constants.GET_ALL_ACCOUNTS_CMD);
            DataTable dt = dataAccess.GetDataTable(getAccounts);

            return Ok(GetAccountsList(dt));
        }

        public List<AccountDetail> GetAccountsList(DataTable usersDt)
        {
            List<AccountDetail> users = new List<AccountDetail>();
            if (usersDt != null && usersDt.Rows.Count > 0)
            {
                users = (from DataRow dr in usersDt.Rows
                         select new AccountDetail()
                         {
                             Id = Convert.ToInt32(dr["Id"]),
                             UserName = dr["UserName"] != null ? Convert.ToString(dr["UserName"]) : string.Empty,
                             FirstName = dr["FirstName"] != null ? Convert.ToString(dr["FirstName"]) : string.Empty,
                             LastName = dr["LastName"] != null ? Convert.ToString(dr["LastName"]) : "",
                             EmailAddress = dr["EmailAddress"] != null ? Convert.ToString(dr["EmailAddress"]) : "",
                             Password = dr["Password"] != null ? Convert.ToString(dr["Password"]) : "",
                         }).ToList();
            }
            return users;
        }

        [HttpPost]
        [Route("CreateAccount")]
        public ActionResult CreateAccount([FromBody]  AccountDetail accountDetail)
        {
            try
            {
                string getUser = string.Format(Constants.GET_USER_BY_EMAILID_CMD, accountDetail.EmailAddress);
                DataTable dt = dataAccess.GetDataTable(getUser);
                User user = dataAccess.GetUsersList(dt).Count > 0 ? dataAccess.GetUsersList(dt)[0] : null;
                if (user != null)
                {
                    int remainingAmount = user.Salary - user.Expenses;
                    if (remainingAmount < 1000)
                    {
                        return Ok("Account cannot be created");
                    }
                }

                string createAccount = string.Format(Constants.INSERT_ACCOUNTS_CMD, accountDetail.FirstName, accountDetail.LastName, accountDetail.EmailAddress, accountDetail.Mobile, accountDetail.UserName, accountDetail.Password, accountDetail.IsActive);
                bool isUpdatedData = dataAccess.InsertOrUpdateOrDeleteData(createAccount);
                return Ok(isUpdatedData ? "Account created successfully" : "Failed to create a new account");
            }
            catch (System.Exception ex)
            {

            }
            return Ok("Failed to create a new account");
        }

    }
}
