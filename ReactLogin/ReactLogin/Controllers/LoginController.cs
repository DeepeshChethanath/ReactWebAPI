using MongoDB.Bson;
using MongoDB.Driver;
using ReactLogin.ViewModel;
using ReactLogin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;

namespace ReactLogin.Controllers
{
    [RoutePrefix("Api/login")]
    public class LoginController : ApiController
    {
        private EmpRepository _employeeRepository;

        [Route("InsertEmployee")]
        [HttpPost]
        public async Task<Response> InsertEmployee(SignUp Reg)
        {
            try
            {
                _employeeRepository = new EmpRepository();
                if (_employeeRepository.CheckEmployee(Reg.EmployeeName) == null)
                {
                    await _employeeRepository.CreateEmployee(Reg);
                    return new Response
                    { Status = "Success" };
                }
                else
                    return new Response
                    { Status = "AlreadyExists" };


            }
            catch (Exception ex)
            {
                return new Response
                { Status = "Invalid" };
            }


        }

        [Route("Login")]
        [HttpPost]
        public async Task<Response> Login(Login login)
        {
            try
            {
                _employeeRepository = new EmpRepository();
                var employee = await _employeeRepository.GetEmployee(login.Email, login.Password);
                if (employee != null)
                    return new Response
                    { Status = "Success"};
                else
                    return new Response
                    { Status = "WrongCredentials" };
            }
            catch(Exception ex)
            {
                return new Response
                { Status = "Invalid" };
            }
            
            
        }
    }
}