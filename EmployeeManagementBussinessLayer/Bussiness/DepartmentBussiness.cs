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
    public class DepartmentBussiness: DepartmentInterface
    {
        EmployeeManagementEntities _db = new EmployeeManagementEntities();
        public List<DepartmentModel> GetDepartmentList()
        {
            var list = new List<DepartmentModel>();
            try
            {
                list = (from a in _db.tblDepartments
                        select new DepartmentModel
                        {
                            ID = a.ID,
                            Name = a.Name,
                        }).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
        public List<DepartmentModel> GetDepartmentByID(int id)
        {
            var record = new List<DepartmentModel>();
            try
            {
                record = (from a in _db.tblDepartments
                          where a.ID == id
                          select new DepartmentModel
                          {
                              ID = a.ID,
                              Name = a.Name,
                          }).ToList();
            }
            catch (Exception ex)
            {

            }
            return record;
        }
        public DepartmentModel AddAndUpdateDepartment(DepartmentModel model)
        {
            try
            {
                if (model.ID > 0)
                {
                    var record = _db.tblDepartments.OrderByDescending(x => x.ID).Where(x => x.ID == model.ID).FirstOrDefault();
                    record.Name = model.Name;
                    _db.SaveChanges();

                }
                else
                {
                    tblDepartment _department = new tblDepartment();
                    _department.Name = model.Name;
                    _db.tblDepartments.Add(_department);
                    _db.SaveChanges();
                    model.ID = _department.ID;
                }
            }
            catch (Exception ex)
            {

            }
            return model;
        }
        public bool DeleteDepartment(int id)
        {
            bool isDeleted = false;
            try
            {
                var record = _db.tblDepartments.OrderByDescending(x => x.ID).Where(x => x.ID == id).FirstOrDefault();
                _db.tblDepartments.Remove(record);
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
