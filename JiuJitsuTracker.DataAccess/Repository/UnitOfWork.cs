using JiuJitsuTracker.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuJitsuTracker.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ClassInfo = new ClassInfoRepository(_db);
        }
        public IClassInfoRepository ClassInfo { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
