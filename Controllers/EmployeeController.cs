using Microsoft.AspNetCore.Mvc;
using Demo_Core_Api.Models;
using System.Data.SqlClient;
using System.Net.WebSockets;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Data;
using Demo_Core_Api.Service;
// For more information on enabling Web API fo
// r empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo_Core_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IConfiguration _configuration { get; }
        
        SqlConnection con;
        
        MethodService service;
        
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
             con= new SqlConnection(_configuration.GetConnectionString("DefaultParkingConnection"));
             service = new MethodService(con);
        }


        [HttpGet]
        public JsonResult GetAllEmployee()
        {
            try
            {
                return new JsonResult(service.GetAll());
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost]
        public Boolean AddEmployee(Employee employee)
        {
            try
            {
                service.AddMethod(employee);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpPut]
        public Boolean UpdateEmployee(int id,Employee employee)
        {
            try
            {
                service.UpdateMethod(id,employee);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpDelete]
        public Boolean DeleteEmployee(int id)
        {
            try
            {
                service.DeleteMethod(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}