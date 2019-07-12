using EmployeeManagementBussinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementBussinessLayer.Interface
{
    public interface EmployeeInterface
    {
        List<EmployeeModel> GetEmployeeList();
        List<EmployeeModel> GetEmployeeByID(int id);
        EmployeeModel AddAndUpdateEmployee(EmployeeModel model);
        bool DeleteEmployee(int id);
    }
}
