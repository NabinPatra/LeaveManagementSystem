﻿using LeaveManagementSystem.Interface;
using LeaveManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveType entity)
        {
            _db.LeaveTypes.Add(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
        }

        public ICollection<LeaveType> FindAll()
        {
           var leaveTypes = _db.LeaveTypes.ToList();
            return leaveTypes;
        }

        public LeaveType FindById(int id)
        {
            var leaveType = _db.LeaveTypes.Find(id);
            return leaveType;
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExists(int id)
        {
            var exists = _db.LeaveTypes.Any(x => x.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes =_db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return Save();
        }
    }
}
