using Practice_WebApp_MVC_Venkat_TT.Models;
using Practice_WebApp_MVC_Venkat_TT.ViewModels;

namespace Practice_WebApp_MVC_Venkat_TT.IRepositories
{
    public interface IEmployeeRepository
    {
        Employee EmployeeDetailById(int? id);

        IEnumerable<Employee> GetEmployeeDetails();

        public int AddEmployee(EmployeeViewModel model);

        public void UpdateEmployee(EmployeeEditViewModel model);

        public int DeleteEmployee (int id);
    }
}
