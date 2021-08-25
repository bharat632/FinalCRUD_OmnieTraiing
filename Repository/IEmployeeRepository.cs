using Core.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IEmployeeRepository
    {
        Task<bool> CreateUser(AuthenticateModel model);
        Task<bool> IsAuthenticate(AuthenticateModel model);
        Task<bool> CreateEmployee(Employee model);
        Task<bool> DeleteEmployee(int id);
        Task<bool> UpdateEmployee(Employee model);
        Task<IEnumerable<Employee>> GetEmployee();
        Task<Employee> GetEmployeeById(int id);
    }
}
