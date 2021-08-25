using Core.Entity;
using Implementation.Helper;
using Microsoft.Extensions.Configuration;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Implementation
{
    public class EmployeeImplementation : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeImplementation(IConfiguration configuration) {
            _connectionString = configuration.GetSection("ConnectionStrings:dbConnection").Value;
        }

        public async Task<bool> CreateUser(AuthenticateModel model)
        {
            SqlParameter[] parameters =
                {
                new SqlParameter("@UserName",model.UserName),
                new SqlParameter("@Password",model.Password)
            };
            var response = await SqlHelper.ExecuteNonQuery(_connectionString, SqlConstant.CreateUser, System.Data.CommandType.Text, parameters);
            return Convert.ToInt32(response) > 0;
        }

        public async Task<bool> IsAuthenticate(AuthenticateModel model)
        {
            SqlParameter[] parameters =
                {
                new SqlParameter("@UserName",model.UserName),
                new SqlParameter("@Password",model.Password)
            };
            var response = await SqlHelper.ExecuteScalar(_connectionString, SqlConstant.IsAuthenticate, System.Data.CommandType.Text, parameters);
            return Convert.ToInt32(response) > 0;
        }

        public async Task<bool> CreateEmployee(Employee model)
        {
            SqlParameter[] parameters =
             {
                new SqlParameter("@name", model.EmpName),
                new SqlParameter("@code", model.EmpCode),
                new SqlParameter("@gender", model.Gender),
                new SqlParameter("@department", model.DepartmentName),
                new SqlParameter("@salary", model.Salary),
            };

            var response = await SqlHelper.ExecuteNonQuery(_connectionString,
                SqlConstant.CreateEmployee, System.Data.CommandType.Text, parameters);

            return Convert.ToInt32(response) > 0;

        }

        public async Task<bool> DeleteEmployee(int id)
        {
           
            SqlParameter[] parameters = { 
                new SqlParameter("@Id", id) };

            var response = await SqlHelper.ExecuteNonQuery(_connectionString, SqlConstant.DeleteEmployee,
                System.Data.CommandType.Text, parameters);

            return Convert.ToInt32(response) > 0;

        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            var models = new List<Employee>();
            var reader = await SqlHelper.ExecuteReader(_connectionString, SqlConstant.GetEmployee ,
                System.Data.CommandType.Text, null);

            while (reader.Read())
            {
                Employee model = new Employee();
                model.Id = Convert.ToInt32(reader["EmpId"]);
                model.EmpName = reader["EmpName"].ToString();
                model.EmpCode = reader["EmpCode"].ToString();
                model.DepartmentName = reader["Department"].ToString();
                model.Gender = reader["Gender"].ToString();
                model.Salary = Convert.ToInt32(reader["Salary"]);

                models.Add(model);

            }

            return models;
            
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public  async Task<bool> UpdateEmployee(Employee model)
        {
            throw new NotImplementedException();
            //SqlParameter[] parameter = {
            //    new SqlParameter("@name", model.EmpName);
            //    new SqlParameter("@code", model.EmpCode);
            //    new SqlParameter("@gender", model.Gender);
            //    new SqlParameter("@department", model.DepartmentName);
            //    new SqlParameter("@salary", model.Salary);
            //}
            //var response = await SqlHelper.ExecuteNonQuery(_connectionString, SqlConstant.UpdateEmployee, 
            //    System.Data.CommandType.Text, parameter);

            //return Convert.ToInt32(response) > 0;
        }

       
    }
}
