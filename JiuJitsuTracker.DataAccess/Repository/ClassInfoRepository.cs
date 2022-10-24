using JiuJitsuTracker.DataAccess.Repository.IRepository;
using JiuJitsuTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuJitsuTracker.DataAccess.Repository
{
    public class ClassInfoRepository : Repository<ClassInfo>, IClassInfoRepository
    {
        private ApplicationDbContext _db;
        public ClassInfoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(ClassInfo obj)
        {
            _db.Classes.Update(obj);
        }
    }
}
