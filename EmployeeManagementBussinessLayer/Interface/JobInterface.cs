using EmployeeManagementBussinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementBussinessLayer.Interface
{
    public interface JobInterface
    {
        List<JobModel> GetJobList();
        List<JobModel> GetJobByID(int id);
        JobModel AddAndUpdateJob(JobModel model);
        bool DeleteJob(int id);
    }
}
