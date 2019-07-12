using EmployeeManagementBussinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementBussinessLayer.Interface
{
    public interface DepartmentInterface
    {
        List<DepartmentModel> GetDepartmentList();
        List<DepartmentModel> GetDepartmentByID(int id);
        DepartmentModel AddAndUpdateDepartment(DepartmentModel model);
        bool DeleteDepartment(int id);
    }
}
