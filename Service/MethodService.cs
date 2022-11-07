using Demo_Core_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Demo_Core_Api.Service
{
    public class MethodService
    {
        SqlConnection con;
        public MethodService(SqlConnection sqlConnection)
        {
            con = sqlConnection;
        }

        public IList<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM tbl_Emp";
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    employees.Add(new Employee
                    {
                        Id = Convert.ToInt32(sdr["Id"]),
                        Name = Convert.ToString(sdr["Name"]),
                        Age = Convert.ToInt32(sdr["Age"])
                    });
                }
            }
            finally
            {
                con.Close();
            }
            return employees;
        }
        public void AddMethod(Employee employee)
        {
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into tbl_Emp(Name, Age) values('" + employee.Name + "'," + employee.Age + ")";
                con.Open();
                cmd.ExecuteNonQuery();
                //return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return false;
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateMethod(int id,Employee employee)
        {
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update tbl_Emp Set Name='" + employee.Name + "', Age=" + employee.Age + "Where(ID=" + id + ");";
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteMethod(int id)
        {
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from tbl_Emp Where(ID=" + id + ");";
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
