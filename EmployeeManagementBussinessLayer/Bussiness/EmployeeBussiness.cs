using EmployeeManagementBussinessLayer.Interface;
using EmployeeManagementBussinessLayer.Model;
using EmployeeManagementDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementBussinessLayer.Bussiness
{
    public class EmployeeBussiness: EmployeeInterface
    {
        EmployeeManagementEntities _db = new EmployeeManagementEntities();
        public List<EmployeeModel> GetEmployeeList()
        {
            var list = new List<EmployeeModel>();
            try
            {
                list = (from a in _db.tblEmployees
                        join b in _db.tblDepartments on a.tblDepartment equals b.ID
                        join c in _db.tblJobs on a.tblJobID equals c.ID
                        select new EmployeeModel
                        {
                            ID = a.ID,
                            tblJobID = a.tblJobID,
                            tblDepartment = a.tblDepartment,
                            Name = a.Name,
                            JobName = c.Job,
                            DepartmentName = b.Name,
                            PhoneNumber = a.PhoneNumber,
                            Salary = a.Salary,
                            Email= a.Email,
                            HireDate = a.HireDate,

                        }).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
        public List<EmployeeModel> GetEmployeeByID(int id)
        {
            var record = new List<EmployeeModel>();
            try
            {
                record = (from a in _db.tblEmployees
                          where a.ID == id
                          select new EmployeeModel
                          {
                              ID = a.ID,
                              tblJobID = a.tblJobID,
                              tblDepartment = a.tblDepartment,
                              Name = a.Name,
                              PhoneNumber = a.PhoneNumber,
                              Salary = a.Salary,
                              Email = a.Email,
                              HireDate = a.HireDate
                          }).ToList();
            }
            catch (Exception ex)
            {

            }
            return record;
        }
        public EmployeeModel AddAndUpdateEmployee(EmployeeModel model)
        {
            try
            {
                if (model.ID > 0)
                {
                    var record = _db.tblEmployees.OrderByDescending(x => x.ID).Where(x => x.ID == model.ID).FirstOrDefault();
                    record.tblJobID = model.tblJobID;
                    record.tblDepartment = model.tblDepartment;
                    record.Name = model.Name;
                    record.PhoneNumber = model.PhoneNumber;
                    record.Salary = model.Salary;
                    record.Email = model.Email;
                    record.HireDate = model.HireDate;
                    _db.SaveChanges();

                }
                else
                {
                    tblEmployee _Employee = new tblEmployee();
                    _Employee.tblJobID = model.tblJobID;
                    _Employee.tblDepartment = model.tblDepartment;
                    _Employee.Name = model.Name;
                    _Employee.PhoneNumber = model.PhoneNumber;
                    _Employee.Salary = model.Salary;
                    _Employee.Email = model.Email;
                    _Employee.HireDate = model.HireDate;
                    _db.tblEmployees.Add(_Employee);
                    _db.SaveChanges();
                    model.ID = _Employee.ID;
                }
            }
            catch (Exception ex)
            {

            }
            return model;
        }
        public bool DeleteEmployee(int id)
        {
            bool isDeleted = false;
            try
            {
                var record = _db.tblEmployees.OrderByDescending(x => x.ID).Where(x => x.ID == id).FirstOrDefault();
                _db.tblEmployees.Remove(record);
                _db.SaveChanges();
                isDeleted = true;
            }
            catch (Exception ex)
            {

            }
            return isDeleted;
        }
    }
}
