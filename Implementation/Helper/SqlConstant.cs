using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Helper
{
    public static class SqlConstant
    {
        public static string CreateUser = @"insert into Authenticate(UserName,Password,CreatedBy) values (@UserName,@Password,1);";
        
        public static string IsAuthenticate = @"select COUNT(1) from Authenticate Where UserName=@UserName and Password=@Password and IsActive=1 and IsDeleted=0";

        public static string CreateEmployee = @"insert into Employee(EmpName, EmpCode, Gender, Department, Salary) 
                                              values(@name, @code, @gender, @department, @salary)";
        public static string UpdateEmployee = @"Update Employee set EmpName=@name, EmpCode=@code, Gender=@gender, 
                                               DepartmentName=@department, Salary=@salary where EmpId=@id";
        public static string DeleteEmployee  = @"Delete from Employee where EmpId=@Id";

        public static string GetEmployee = @"select EmpId , EmpName , EmpCode , Department , Salary , Gender from Employee ";
    
    }
}
