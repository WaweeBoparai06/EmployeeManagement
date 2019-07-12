using EmployeeManagementBussinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementBussinessLayer.Interface
{
    public interface UserInterface
    {
        bool LoginUser(UserModel model);
        List<UserModel> GetUserList();
        UserModel GetUserByID(int id);
        UserModel AddAndUpdateUser(UserModel model);
        bool DeleteUser(int id);
    }
}
