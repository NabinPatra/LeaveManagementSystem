using LeaveManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Interface
{
    public interface ILeaveTypeRepository : IRepositoryBase<LeaveType>
    {
        ICollection<LeaveType> GetEmployeesByLeaveType(int id);

    }
}
